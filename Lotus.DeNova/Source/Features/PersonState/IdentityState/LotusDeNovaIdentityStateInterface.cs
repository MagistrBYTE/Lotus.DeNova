using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaIdentityState
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с идентификационными сведениями о персонаже.
    /// </summary>
    public interface ILotusIdentityStateService
    {
        /// <summary>
        /// Создание идентификационных сведений о персонаже по указанным данным.
        /// </summary>
        /// <param name="identityInfoCreate">Параметры для создания идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификационные сведения о персонаже.</returns>
        Task<Response<IdentityStateDto>> CreateAsync(IdentityStateCreateRequest identityInfoCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="identityInfoUpdate">Параметры обновляемых идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификационные сведения о персонаже.</returns>
        Task<Response<IdentityStateDto>> UpdateAsync(IdentityStateDto identityInfoUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанных идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="identityInfoId">Идентификатор идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификационные сведения о персонаже.</returns>
        Task<Response<IdentityStateDto>> GetAsync(Guid identityInfoId, CancellationToken token);

        /// <summary>
        /// Получение списка идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="identityInfoRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список идентификационных сведений о персонаже.</returns>
        Task<ResponsePage<IdentityStateDto>> GetAllAsync(IdentityStatesDto identityInfoRequest, CancellationToken token);

        /// <summary>
        /// Удаление идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="identityInfoId">Идентификатор идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid identityInfoId, CancellationToken token);
    }
    /**@}*/
}