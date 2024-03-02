using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPlacementState
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с местоположением персонажа.
    /// </summary>
    public interface ILotusPlacementStateService
    {
        /// <summary>
        /// Создание местоположения персонажа по указанным данным.
        /// </summary>
        /// <param name="placementInfoCreate">Параметры для создания местоположения персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Местоположение персонажа.</returns>
        Task<Response<PlacementStateDto>> CreateAsync(PlacementStateCreateRequest placementInfoCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных о местоположении персонажа.
        /// </summary>
        /// <param name="placementInfoUpdate">Параметры обновляемого местоположения персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Местоположение персонажа.</returns>
        Task<Response<PlacementStateDto>> UpdateAsync(PlacementStateDto placementInfoUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного местоположения персонажа.
        /// </summary>
        /// <param name="placementInfoId">Идентификатор местоположения персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Местоположение персонажа.</returns>
        Task<Response<PlacementStateDto>> GetAsync(Guid placementInfoId, CancellationToken token);

        /// <summary>
        /// Получение списка местоположений персонажа.
        /// </summary>
        /// <param name="placementInfoRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список местоположений персонажа.</returns>
        Task<ResponsePage<PlacementStateDto>> GetAllAsync(PlacementStatesDto placementInfoRequest, CancellationToken token);

        /// <summary>
        /// Удаление местоположения персонажа.
        /// </summary>
        /// <param name="placementInfoId">Идентификатор местоположения персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid placementInfoId, CancellationToken token);
    }
    /**@}*/
}