using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPlacementState
	*@{*/
    /// <summary>
    /// Cервис для работы с местоположением персонажа.
    /// </summary>
    public class PlacementStateService : ILotusPlacementStateService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public PlacementStateService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusPlacementStateService methods
        /// <inheritdoc/>
        public async Task<Response<PlacementStateDto>> CreateAsync(PlacementStateCreateRequest placementInfoCreate, CancellationToken token)
        {
            var entity = placementInfoCreate.Adapt<PlacementState>();

            entity.PlacementStateId = Guid.NewGuid();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PlacementStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PlacementStateDto>> UpdateAsync(PlacementStateDto placementInfoUpdate, CancellationToken token)
        {
            var entity = placementInfoUpdate.Adapt<PlacementState>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PlacementStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PlacementStateDto>> GetAsync(Guid placementInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<PlacementState>()
                .FirstOrDefaultAsync(x => (x.PlacementStateId == placementInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed<PlacementStateDto>(XPlacementStateErrors.NotFound);
            }

            var result = entity.Adapt<PlacementStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<PlacementStateDto>> GetAllAsync(PlacementStatesDto placementInfoRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<PlacementState>();

            query = query
                .Where(x => x.GameId == placementInfoRequest.GameId &&
                            x.PersonId == placementInfoRequest.PersonId &&
                            x.GameSaveId == null);

            query = query.Filter(placementInfoRequest.Filtering);

            var queryOrder = query.Sort(placementInfoRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<PlacementState, PlacementStateDto>(placementInfoRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid placementInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<PlacementState>()
            .FirstOrDefaultAsync(x => (x.PlacementStateId == placementInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed(XPlacementStateErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}