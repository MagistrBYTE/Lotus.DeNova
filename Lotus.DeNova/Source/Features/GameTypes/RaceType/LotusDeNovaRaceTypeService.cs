using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaRaceType
	*@{*/
    /// <summary>
    /// Cервис для работы с расами.
    /// </summary>
    public class RaceTypeService : ILotusRaceTypeService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public RaceTypeService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusRaceTypeService methods
        /// <inheritdoc/>
        public async Task<Response<RaceTypeDto>> CreateAsync(RaceTypeCreateRequest raceCreate, CancellationToken token)
        {
            var entity = raceCreate.Adapt<RaceType>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<RaceTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<RaceTypeDto>> UpdateAsync(RaceTypeDto raceUpdate, CancellationToken token)
        {
            var entity = raceUpdate.Adapt<RaceType>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<RaceTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<RaceTypeDto>> GetAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<RaceType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<RaceTypeDto>(XRaceTypeErrors.NotFound);
            }

            var result = entity.Adapt<RaceTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<RaceTypeDto>> GetAllAsync(RaceTypesRequest raceRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<RaceType>();

            if (raceRequest.GameSettingTypeId.HasValue)
            {
                query = query.Where(x => x.GameSettingTypeId == raceRequest.GameSettingTypeId);
            }

            query = query.Filter(raceRequest.Filtering);

            var queryOrder = query.Sort(raceRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<RaceType, RaceTypeDto>(raceRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<RaceType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XRaceTypeErrors.NotFound);
            }

            if (entity.Id < 8)
            {
                return XResponse.Failed(XRaceTypeErrors.NotDeleteConst);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}