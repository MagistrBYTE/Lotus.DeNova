using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAstrologyType
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с данными по астрологии.
    /// </summary>
    public interface ILotusAstrologyTypeService
    {
        /// <summary>
        /// Создание данных по астрологии по указанным данным.
        /// </summary>
        /// <param name="astrologyCreate">Параметры для создания данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные по астрологии.</returns>
        Task<Response<AstrologyTypeDto>> CreateAsync(AstrologyTypeCreateRequest astrologyCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанных данных по астрологии.
        /// </summary>
        /// <param name="astrologyUpdate">Параметры обновляемых данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные по астрологии.</returns>
        Task<Response<AstrologyTypeDto>> UpdateAsync(AstrologyTypeDto astrologyUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанных данных по астрологии.
        /// </summary>
        /// <param name="id">Идентификатор данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные по астрологии.</returns>
        Task<Response<AstrologyTypeDto>> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Получение списка данных по астрологии.
        /// </summary>
        /// <param name="astrologyRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок данных по астрологии.</returns>
        Task<ResponsePage<AstrologyTypeDto>> GetAllAsync(AstrologyTypesRequest astrologyRequest, CancellationToken token);

        /// <summary>
        /// Удаление данных по астрологии.
        /// </summary>
        /// <param name="id">Идентификатор данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(int id, CancellationToken token);
    }
    /**@}*/
}