using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Cервис для работы с параметрами персонажа.
    /// </summary>
    public class ParameterTypeService : ILotusParameterTypeService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public ParameterTypeService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusParameterTypeService methods
        /// <inheritdoc/>
        public async Task<Response<ParameterTypeDto>> CreateAsync(ParameterTypeCreateRequest personParamsCreate, CancellationToken token)
        {
            var entity = personParamsCreate.Adapt<ParameterType>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<ParameterTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<ParameterTypeDto>> UpdateAsync(ParameterTypeDto personParamsUpdate, CancellationToken token)
        {
            var entity = personParamsUpdate.Adapt<ParameterType>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<ParameterTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<ParameterTypeDto>> GetAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<ParameterType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<ParameterTypeDto>(XParameterTypeErrors.NotFound);
            }

            var result = entity.Adapt<ParameterTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<ParameterTypeDto>> GetAllAsync(ParameterTypesRequest parameterRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<ParameterType>();

            if (parameterRequest.GameSettingTypeId.HasValue)
            {
                query = query.Where(x => x.GameSettingTypeId == parameterRequest.GameSettingTypeId);
            }

            query = query.Filter(parameterRequest.Filtering);

            var queryOrder = query.Sort(parameterRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<ParameterType, ParameterTypeDto>(parameterRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<ParameterType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XParameterTypeErrors.NotFound);
            }

            if (entity.Id < 12)
            {
                return XResponse.Failed(XParameterTypeErrors.NotDeleteConst);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}