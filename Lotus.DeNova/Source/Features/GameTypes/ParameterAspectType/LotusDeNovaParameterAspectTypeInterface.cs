using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с аспектами параметров существ.
    /// </summary>
    public interface ILotusParameterAspectTypeService
    {
        /// <summary>
        /// Создание аспекта параметра существа по указанным данным.
        /// </summary>
        /// <param name="parameterAspectCreate">Данные для создания аспекта параметра существа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аспект параметра существа.</returns>
        Task<Response<ParameterAspectTypeDto>> CreateAsync(ParameterAspectTypeCreateRequest parameterAspectCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанного аспекта параметра существа.
        /// </summary>
        /// <param name="parameterAspectUpdate">Данные обновляемого аспекта параметра существа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аспект параметра существа.</returns>
        Task<Response<ParameterAspectTypeDto>> UpdateAsync(ParameterAspectTypeDto parameterAspectUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанного аспекта параметра существа.
        /// </summary>
        /// <param name="id">Идентификатор аспекта параметра существа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аспект параметра существа.</returns>
        Task<Response<ParameterAspectTypeDto>> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Получение списка аспектов параметров существ.
        /// </summary>
        /// <param name="parameterAspectRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок аспектов параметров существ.</returns>
        Task<ResponsePage<ParameterAspectTypeDto>> GetAllAsync(ParameterAspectTypesRequest parameterAspectRequest, CancellationToken token);

        /// <summary>
        /// Удаление аспекта параметра существа.
        /// </summary>
        /// <param name="id">Идентификатор аспекта параметра существа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(int id, CancellationToken token);
    }
    /**@}*/
}