using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaScenarioType
	*@{*/
    /// <summary>
    /// Cервис для работы со сценариями.
    /// </summary>
    public class ScenarioTypeService : ILotusScenarioTypeService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public ScenarioTypeService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusScenarioTypeService methods
        /// <summary>
        /// Создание сценария по указанным данным.
        /// </summary>
        /// <param name="scenarioCreate">Параметры для создания сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сценарий.</returns>
        public async Task<Response<ScenarioTypeDto>> CreateAsync(ScenarioTypeCreateRequest scenarioCreate, CancellationToken token)
        {
            var entity = scenarioCreate.Adapt<ScenarioType>();

            _dataStorage.Add(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<ScenarioTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <summary>
        /// Обновление данных указанной сценария.
        /// </summary>
        /// <param name="scenarioUpdate">Параметры обновляемой сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сценарий.</returns>
        public async Task<Response<ScenarioTypeDto>> UpdateAsync(ScenarioTypeDto scenarioUpdate, CancellationToken token)
        {
            var entity = scenarioUpdate.Adapt<ScenarioType>();

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<ScenarioTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <summary>
        /// Получение указанной сценария.
        /// </summary>
        /// <param name="id">Идентификатор сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сценарий.</returns>
        public async Task<Response<ScenarioTypeDto>> GetAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<ScenarioType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<ScenarioTypeDto>(XScenarioTypeErrors.NotFound);
            }

            var result = entity.Adapt<ScenarioTypeDto>();

            return XResponse.Succeed(result);
        }

        /// <summary>
        /// Получение списка сценариев.
        /// </summary>
        /// <param name="scenarioRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок рас.</returns>
        public async Task<ResponsePage<ScenarioTypeDto>> GetAllAsync(ScenarioTypesRequest scenarioRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<ScenarioType>();

            if (scenarioRequest.GameSettingTypeId.HasValue)
            {
                query = query.Where(x => x.GameSettingTypeId == scenarioRequest.GameSettingTypeId);
            }

            query = query.Filter(scenarioRequest.Filtering);

            var queryOrder = query.Sort(scenarioRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<ScenarioType, ScenarioTypeDto>(scenarioRequest, token);

            return result;
        }

        /// <summary>
        /// Удаление сценария.
        /// </summary>
        /// <param name="id">Идентификатор сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        public async Task<Response> DeleteAsync(int id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<ScenarioType, int>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XScenarioTypeErrors.NotFound);
            }

            if (entity.Id < 8)
            {
                return XResponse.Failed(XScenarioTypeErrors.NotDeleteConst);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}