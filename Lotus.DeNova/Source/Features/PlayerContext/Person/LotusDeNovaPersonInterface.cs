using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с персонажами.
    /// </summary>
    public interface ILotusPersonService
    {
        /// <summary>
        /// Создание персонажа по указанным данным.
        /// </summary>
        /// <param name="personCreate">Параметры для создания персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Персонаж.</returns>
        Task<Response<PersonDto>> CreateAsync(PersonCreateRequest personCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанного персонажа.
        /// </summary>
        /// <param name="personUpdate">Параметры обновляемой персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Персонаж.</returns>
        Task<Response<PersonDto>> UpdateAsync(PersonDto personUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного персонажа.
        /// </summary>
        /// <param name="id">Идентификатор персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Персонаж.</returns>
        Task<Response<PersonDto>> GetAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Получение списка персонажей.
        /// </summary>
        /// <param name="personRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок персонажей.</returns>
        Task<ResponsePage<PersonDto>> GetAllAsync(PersonsRequest personRequest, CancellationToken token);

        /// <summary>
        /// Удаление персонажа.
        /// </summary>
        /// <param name="id">Идентификатор персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid id, CancellationToken token);
    }
    /**@}*/
}