using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAvatarState
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с аватаром персонажа.
    /// </summary>
    public interface ILotusAvatarStateService
    {
        /// <summary>
        /// Создание аватара персонажа по указанным данным.
        /// </summary>
        /// <param name="avatarInfoCreate">Параметры для создания аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аватар персонажа.</returns>
        Task<Response<AvatarStateDto>> CreateAsync(AvatarStateCreateRequest avatarInfoCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных аватара персонажа.
        /// </summary>
        /// <param name="avatarInfoUpdate">Параметры обновляемой аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аватар персонажа.</returns>
        Task<Response<AvatarStateDto>> UpdateAsync(AvatarStateDto avatarInfoUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного аватара персонажа.
        /// </summary>
        /// <param name="avatarInfoId">Идентификатор аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аватар персонажа.</returns>
        Task<Response<AvatarStateDto>> GetAsync(Guid avatarInfoId, CancellationToken token);

        /// <summary>
        /// Получение списка аватаров персонажа.
        /// </summary>
        /// <param name="avatarInfoRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список аватаров персонажа.</returns>
        Task<ResponsePage<AvatarStateDto>> GetAllAsync(AvatarStatesDto avatarInfoRequest, CancellationToken token);

        /// <summary>
        /// Удаление аватара персонажа.
        /// </summary>
        /// <param name="avatarInfoId">Идентификатор аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid avatarInfoId, CancellationToken token);
    }
    /**@}*/
}