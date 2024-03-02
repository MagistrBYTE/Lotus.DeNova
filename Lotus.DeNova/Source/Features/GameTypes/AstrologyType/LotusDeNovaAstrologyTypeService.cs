using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAstrologyType
	*@{*/
    /// <summary>
    /// Cервис для работы с данными по астрологии.
    /// </summary>
    public class AstrologyTypeService : ILotusAstrologyTypeService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public AstrologyTypeService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusAstrologyTypeService methods
        /// <inheritdoc/>
        public async Task<Response<AstrologyTypeDto>> CreateAsync(AstrologyTypeCreateRequest astrologyCreate, CancellationToken token)
        {
            var entity = astrologyCreate.Adapt<AstrologyType>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<AstrologyTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<AstrologyTypeDto>> UpdateAsync(AstrologyTypeDto astrologyUpdate, CancellationToken token)
        {
            var entity = astrologyUpdate.Adapt<AstrologyType>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<AstrologyTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<AstrologyTypeDto>> GetAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<AstrologyType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<AstrologyTypeDto>(XAstrologyTypeErrors.NotFound);
            }

            var result = entity.Adapt<AstrologyTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<AstrologyTypeDto>> GetAllAsync(AstrologyTypesRequest astrologyRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<AstrologyType>();

            if (astrologyRequest.GameSettingTypeId.HasValue)
            {
                query = query.Where(x => x.GameSettingTypeId == astrologyRequest.GameSettingTypeId);
            }

            query = query.Filter(astrologyRequest.Filtering);

            var queryOrder = query.Sort(astrologyRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<AstrologyType, AstrologyTypeDto>(astrologyRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<AstrologyType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XAstrologyTypeErrors.NotFound);
            }

            if (entity.Id < 4)
            {
                return XResponse.Failed(XAstrologyTypeErrors.NotDeleteConst);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}