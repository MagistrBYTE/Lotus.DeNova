using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddressState
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с местом жительства персонажа.
    /// </summary>
    public interface ILotusAddressStateService
    {
        /// <summary>
        /// Создание места жительства персонажа по указанным данным.
        /// </summary>
        /// <param name="addressInfoCreate">Параметры для создания места жительства персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Место жительства персонажа.</returns>
        Task<Response<AddressStateDto>> CreateAsync(AddressStateCreateRequest addressInfoCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных места жительства персонажа.
        /// </summary>
        /// <param name="addressInfoUpdate">Параметры обновляемой места жительства персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Место жительства персонажа.</returns>
        Task<Response<AddressStateDto>> UpdateAsync(AddressStateDto addressInfoUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного места жительства персонажа.
        /// </summary>
        /// <param name="addressInfoId">Идентификатор места жительства персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Место жительства персонажа.</returns>
        Task<Response<AddressStateDto>> GetAsync(Guid addressInfoId, CancellationToken token);

        /// <summary>
        /// Получение списка мест жительств персонажа.
        /// </summary>
        /// <param name="addressInfoRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок мест жительств персонажа .</returns>
        Task<ResponsePage<AddressStateDto>> GetAllAsync(AddressStatesRequest addressInfoRequest, CancellationToken token);

        /// <summary>
        /// Удаление места жительства персонажа.
        /// </summary>
        /// <param name="addressInfoId">Идентификатор места жительства персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid addressInfoId, CancellationToken token);
    }
    /**@}*/
}