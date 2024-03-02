using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddressState
	*@{*/
    /// <summary>
    /// Cервис для работы с местом жительства персонажа.
    /// </summary>
    public class AddressStateService : ILotusAddressStateService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public AddressStateService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusAddressStateService methods
        /// <inheritdoc/>
        public async Task<Response<AddressStateDto>> CreateAsync(AddressStateCreateRequest addressInfoCreate, CancellationToken token)
        {
            var entity = addressInfoCreate.Adapt<AddressState>();

            entity.AddressStateId = Guid.NewGuid();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<AddressStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<AddressStateDto>> UpdateAsync(AddressStateDto addressInfoUpdate, CancellationToken token)
        {
            var entity = addressInfoUpdate.Adapt<AddressState>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<AddressStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<AddressStateDto>> GetAsync(Guid addressInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<AddressState>().
                FirstOrDefaultAsync(x => (x.AddressStateId == addressInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed<AddressStateDto>(XAddressStateErrors.NotFound);
            }

            var result = entity.Adapt<AddressStateDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<AddressStateDto>> GetAllAsync(AddressStatesRequest addressInfoRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<AddressState>();

            query = query
                .Where(x => x.GameId == addressInfoRequest.GameId &&
                            x.PersonId == addressInfoRequest.PersonId &&
                            x.GameSaveId == null);

            query = query.Filter(addressInfoRequest.Filtering);

            var queryOrder = query.Sort(addressInfoRequest.Sorting, x => x.BeginPeriod);

            var result = await queryOrder.ToResponsePageAsync<AddressState, AddressStateDto>(addressInfoRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid addressInfoId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<AddressState>()
            .FirstOrDefaultAsync(x => (x.AddressStateId == addressInfoId && x.GameSaveId == null), token);
            if (entity == null)
            {
                return XResponse.Failed(XAddressStateErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}