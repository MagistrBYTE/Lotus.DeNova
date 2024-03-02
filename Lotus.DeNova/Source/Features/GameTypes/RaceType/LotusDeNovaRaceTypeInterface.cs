using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaRaceType
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с расами.
    /// </summary>
    public interface ILotusRaceTypeService
    {
        /// <summary>
        /// Создание расы по указанным данным.
        /// </summary>
        /// <param name="raceCreate">Параметры для создания расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        Task<Response<RaceTypeDto>> CreateAsync(RaceTypeCreateRequest raceCreate, CancellationToken token);

        /// <summary>
        /// Обновление данных указанной расы.
        /// </summary>
        /// <param name="raceUpdate">Параметры обновляемой расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        Task<Response<RaceTypeDto>> UpdateAsync(RaceTypeDto raceUpdate, CancellationToken token);

        /// <summary>
        /// Получение указанной расы.
        /// </summary>
        /// <param name="id">Идентификатор расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        Task<Response<RaceTypeDto>> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Получение списка рас.
        /// </summary>
        /// <param name="raceRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок рас.</returns>
        Task<ResponsePage<RaceTypeDto>> GetAllAsync(RaceTypesRequest raceRequest, CancellationToken token);

        /// <summary>
        /// Удаление расы.
        /// </summary>
        /// <param name="id">Идентификатор расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(int id, CancellationToken token);
    }
    /**@}*/
}