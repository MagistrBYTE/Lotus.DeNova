using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaScenarioType
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы со сценариями.
    /// </summary>
    public interface ILotusScenarioTypeService
    {
        /// <summary>
        /// Создание сценария по указанным данным.
        /// </summary>
        /// <param name="scenarioCreate">Параметры для создания сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сценарий.</returns>
        Task<Response<ScenarioTypeDto>> CreateAsync(ScenarioTypeCreateRequest scenarioCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанной сценария.
        /// </summary>
        /// <param name="scenarioUpdate">Параметры обновляемой сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сценарий.</returns>
        Task<Response<ScenarioTypeDto>> UpdateAsync(ScenarioTypeDto scenarioUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанной сценария.
        /// </summary>
        /// <param name="id">Идентификатор сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сценарий.</returns>
        Task<Response<ScenarioTypeDto>> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Получение списка сценариев.
        /// </summary>
        /// <param name="scenarioRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок рас.</returns>
        Task<ResponsePage<ScenarioTypeDto>> GetAllAsync(ScenarioTypesRequest scenarioRequest, CancellationToken token);

        /// <summary>
        /// Удаление сценария.
        /// </summary>
        /// <param name="id">Идентификатор сценария.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(int id, CancellationToken token);
    }
    /**@}*/
}