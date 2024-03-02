using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с аспектами параметров персонажа.
    /// </summary>
    public interface ILotusPersonParameterAspectService
    {
        /// <summary>
        /// Создание аспекта параметра персонажа по указанным данным.
        /// </summary>
        /// <param name="personParameterAspectCreate">Данные для создания аспекта параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аспект параметра персонажа.</returns>
        Task<Response<PersonParameterAspectDto>> CreateAsync(PersonParameterAspectCreateRequest personParameterAspectCreate,
            CancellationToken token);

        /// <summary>
        /// Обновление данных указанного аспекта параметра персонажа.
        /// </summary>
        /// <param name="personParameterAspectUpdate">Данные обновляемого аспекта параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аспект параметра персонажа.</returns>
        Task<Response<PersonParameterAspectDto>> UpdateAsync(PersonParameterAspectDto personParameterAspectUpdate,
        CancellationToken token);

        /// <summary>
        /// Получение указанного аспекта параметра персонажа.
        /// </summary>
        /// <param name="id">Идентификатор аспекта параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аспект параметра персонажа.</returns>
        Task<Response<PersonParameterAspectDto>> GetAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Получение списка аспектов параметров персонажа.
        /// </summary>
        /// <param name="personParameterAspectRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок аспектов параметров персонажа.</returns>
        Task<ResponsePage<PersonParameterAspectDto>> GetAllAsync(PersonParameterAspectsRequest personParameterAspectRequest,
            CancellationToken token);

        /// <summary>
        /// Удаление аспекта параметра персонажа.
        /// </summary>
        /// <param name="id">Идентификатор аспекта параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid id, CancellationToken token);
    }
    /**@}*/
}