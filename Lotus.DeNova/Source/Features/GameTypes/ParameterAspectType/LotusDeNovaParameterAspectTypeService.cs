using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Cервис для работы с аспектов параметров существами.
    /// </summary>
    public class ParameterAspectTypeService : ILotusParameterAspectTypeService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public ParameterAspectTypeService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusParameterAspectTypeService methods
        /// <inheritdoc/>
        public async Task<Response<ParameterAspectTypeDto>> CreateAsync(ParameterAspectTypeCreateRequest parameterAspectCreate, CancellationToken token)
        {
            var entity = parameterAspectCreate.Adapt<ParameterAspectType>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<ParameterAspectTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<ParameterAspectTypeDto>> UpdateAsync(ParameterAspectTypeDto parameterAspectUpdate, CancellationToken token)
        {
            var entity = parameterAspectUpdate.Adapt<ParameterAspectType>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<ParameterAspectTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<ParameterAspectTypeDto>> GetAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<ParameterAspectType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<ParameterAspectTypeDto>(XParameterAspectTypeErrors.NotFound);
            }

            var result = entity.Adapt<ParameterAspectTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<ParameterAspectTypeDto>> GetAllAsync(ParameterAspectTypesRequest parameterAspectRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<ParameterAspectType>();

            if (parameterAspectRequest.GameSettingTypeId.HasValue)
            {
                query = query.Where(x => x.GameSettingTypeId == parameterAspectRequest.GameSettingTypeId);
            }

            query = query.Filter(parameterAspectRequest.Filtering);

            var queryOrder = query.Sort(parameterAspectRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<ParameterAspectType, ParameterAspectTypeDto>(parameterAspectRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<ParameterAspectType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XParameterAspectTypeErrors.NotFound);
            }

            if (entity.Id < 8)
            {
                return XResponse.Failed(XParameterAspectTypeErrors.NotDeleteConst);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}