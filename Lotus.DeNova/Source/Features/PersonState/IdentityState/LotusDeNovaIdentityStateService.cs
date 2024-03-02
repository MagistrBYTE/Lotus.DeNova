using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaIdentityState
	*@{*/
    /// <summary>
    /// Cервис для работы с идентификационными сведениями о персонаже.
    /// </summary>
    public class IdentityStateService : ILotusIdentityStateService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public IdentityStateService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusIdentityStateService methods
        /// <inheritdoc/>
        public async Task<Response<IdentityStateDto>> CreateAsync(IdentityStateCreateRequest identityInfoCreate, CancellationToken token)
        {
            var entity = identityInfoCreate.Adapt<IdentityState>();
            entity.IdentityStateId = Guid.NewGuid();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<IdentityStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<IdentityStateDto>> UpdateAsync(IdentityStateDto identityInfoUpdate, CancellationToken token)
        {
            var entity = identityInfoUpdate.Adapt<IdentityState>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<IdentityStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<IdentityStateDto>> GetAsync(Guid identityInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<IdentityState>()
                .FirstOrDefaultAsync(x => (x.IdentityStateId == identityInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed<IdentityStateDto>(XIdentityStateErrors.NotFound);
            }

            var result = entity.Adapt<IdentityStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<IdentityStateDto>> GetAllAsync(IdentityStatesDto identityInfoRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<IdentityState>();

            query = query
                .Where(x => x.GameId == identityInfoRequest.GameId &&
                            x.PersonId == identityInfoRequest.PersonId &&
                            x.GameSaveId == null);

            query = query.Filter(identityInfoRequest.Filtering);

            var queryOrder = query.Sort(identityInfoRequest.Sorting, x => x.BeginPeriod);

            var result = await queryOrder.ToResponsePageAsync<IdentityState, IdentityStateDto>(identityInfoRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid identityInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<IdentityState>()
            .FirstOrDefaultAsync(x => (x.IdentityStateId == identityInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed(XIdentityStateErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}