using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с параметрами существ.
    /// </summary>
    public interface ILotusParameterTypeService
    {
        /// <summary>
        /// Создание параметра существа по указанным данным.
        /// </summary>
        /// <param name="personParamsCreate">Данные для создания параметра существа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр существа.</returns>
        Task<Response<ParameterTypeDto>> CreateAsync(ParameterTypeCreateRequest personParamsCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанного параметра существа.
        /// </summary>
        /// <param name="personParamsUpdate">Данные обновляемого параметра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр существа.</returns>
        Task<Response<ParameterTypeDto>> UpdateAsync(ParameterTypeDto personParamsUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного параметра существа.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр существа.</returns>
        Task<Response<ParameterTypeDto>> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Получение списка параметров существ.
        /// </summary>
        /// <param name="parameterRequest">Запрос для получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок параметров существ.</returns>
        Task<ResponsePage<ParameterTypeDto>> GetAllAsync(ParameterTypesRequest parameterRequest, CancellationToken token);

        /// <summary>
        /// Удаление параметра существа.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(int id, CancellationToken token);
    }
    /**@}*/
}