using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
	*@{*/
    /// <summary>
    /// Cервис для работы с аспектами параметров персонажа.
    /// </summary>
    public class PersonParameterAspectService : ILotusPersonParameterAspectService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public PersonParameterAspectService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusPersonParameterAspectService methods
        /// <inheritdoc/>
        public async Task<Response<PersonParameterAspectDto>> CreateAsync(PersonParameterAspectCreateRequest personParameterAspectCreate,
        CancellationToken token)
        {
            var entity = personParameterAspectCreate.Adapt<PersonParameterAspect>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PersonParameterAspectDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PersonParameterAspectDto>> UpdateAsync(PersonParameterAspectDto personParameterAspectUpdate,
            CancellationToken token)
        {
            var entity = personParameterAspectUpdate.Adapt<PersonParameterAspect>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PersonParameterAspectDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PersonParameterAspectDto>> GetAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<PersonParameterAspect, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<PersonParameterAspectDto>(XPersonParameterAspectErrors.NotFound);
            }

            var result = entity.Adapt<PersonParameterAspectDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<PersonParameterAspectDto>> GetAllAsync(PersonParameterAspectsRequest personParameterAspectRequest,
            CancellationToken token)
        {
            var query = _dataStorage.Query<PersonParameterAspect>();

            if (personParameterAspectRequest.PersonId.HasValue)
            {
                query = query.Where(x => x.PersonId == personParameterAspectRequest.PersonId);
            }

            query = query.Filter(personParameterAspectRequest.Filtering);

            var queryOrder = query.Sort(personParameterAspectRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<PersonParameterAspect, PersonParameterAspectDto>(personParameterAspectRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<PersonParameterAspect, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XPersonParameterAspectErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}