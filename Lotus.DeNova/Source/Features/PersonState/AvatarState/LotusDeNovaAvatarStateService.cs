using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAvatarState
	*@{*/
    /// <summary>
    /// Cервис для работы с аватаром персонажа.
    /// </summary>
    public class AvatarStateService : ILotusAvatarStateService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public AvatarStateService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusAvatarStateService methods
        /// <inheritdoc/>
        public async Task<Response<AvatarStateDto>> CreateAsync(AvatarStateCreateRequest avatarInfoCreate, CancellationToken token)
        {
            var entity = avatarInfoCreate.Adapt<AvatarState>();

            entity.AvatarStateId = Guid.NewGuid();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<AvatarStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<AvatarStateDto>> UpdateAsync(AvatarStateDto avatarInfoUpdate, CancellationToken token)
        {
            var entity = avatarInfoUpdate.Adapt<AvatarState>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<AvatarStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<AvatarStateDto>> GetAsync(Guid avatarInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<AvatarState>()
                .FirstOrDefaultAsync(x => (x.AvatarStateId == avatarInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed<AvatarStateDto>(XAvatarStateErrors.NotFound);
            }

            var result = entity.Adapt<AvatarStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<AvatarStateDto>> GetAllAsync(AvatarStatesDto avatarInfoRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<AvatarState>();

            query = query
                .Where(x => x.GameId == avatarInfoRequest.GameId &&
                            x.PersonId == avatarInfoRequest.PersonId &&
                            x.GameSaveId == null);

            query = query.Filter(avatarInfoRequest.Filtering);

            var queryOrder = query.Sort(avatarInfoRequest.Sorting, x => x.BeginPeriod);

            var result = await queryOrder.ToResponsePageAsync<AvatarState, AvatarStateDto>(avatarInfoRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid avatarInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<AvatarState>()
            .FirstOrDefaultAsync(x => (x.AvatarStateId == avatarInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed(XAvatarStateErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}