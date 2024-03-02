using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
	*@{*/
    /// <summary>
    /// Cервис для работы с параметрами персонажа.
    /// </summary>
    public class PersonParameterService : ILotusPersonParameterService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public PersonParameterService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusPersonParameterService methods
        /// <inheritdoc/>
        public async Task<Response<PersonParameterDto>> CreateAsync(PersonParameterCreateRequest personParameterCreate, CancellationToken token)
        {
            var entity = personParameterCreate.Adapt<PersonParameter>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PersonParameterDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PersonParameterDto>> UpdateAsync(PersonParameterDto personParameterUpdate, CancellationToken token)
        {
            var entity = personParameterUpdate.Adapt<PersonParameter>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PersonParameterDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PersonParameterDto>> GetAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<PersonParameter, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<PersonParameterDto>(XPersonParameterErrors.NotFound);
            }

            var result = entity.Adapt<PersonParameterDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<PersonParameterDto>> GetAllAsync(PersonParametersRequest personParameterRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<PersonParameter>();

            if (personParameterRequest.PersonId.HasValue)
            {
                query = query.Where(x => x.PersonId == personParameterRequest.PersonId);
            }

            query = query.Filter(personParameterRequest.Filtering);

            var queryOrder = query.Sort(personParameterRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<PersonParameter, PersonParameterDto>(personParameterRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<PersonParameter, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XPersonParameterErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}