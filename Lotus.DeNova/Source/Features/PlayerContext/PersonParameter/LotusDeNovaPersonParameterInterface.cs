using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с параметрами персонажа.
    /// </summary>
    public interface ILotusPersonParameterService
    {
        /// <summary>
        /// Создание параметра персонажа по указанным данным.
        /// </summary>
        /// <param name="personParameterCreate">Данные для создания параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр персонажа.</returns>
        Task<Response<PersonParameterDto>> CreateAsync(PersonParameterCreateRequest personParameterCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанного параметра персонажа.
        /// </summary>
        /// <param name="personParameterUpdate">Данные обновляемого параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр персонажа.</returns>
        Task<Response<PersonParameterDto>> UpdateAsync(PersonParameterDto personParameterUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного параметра персонажа.
        /// </summary>
        /// <param name="id">Идентификатор параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр персонажа.</returns>
        Task<Response<PersonParameterDto>> GetAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Получение списка параметров персонажа.
        /// </summary>
        /// <param name="personParameterRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок параметров персонажа.</returns>
        Task<ResponsePage<PersonParameterDto>> GetAllAsync(PersonParametersRequest personParameterRequest, CancellationToken token);

        /// <summary>
        /// Удаление параметра персонажа.
        /// </summary>
        /// <param name="id">Идентификатор параметра персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid id, CancellationToken token);
    }
    /**@}*/
}