using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
	*@{*/
    /// <summary>
    /// Интерфейс сервиса для работы с контекстом игры.
    /// </summary>
    public interface ILotusGameService
    {
        /// <summary>
        /// Создание игры по указанным данным.
        /// </summary>
        /// <remarks>
        /// Созданная игра становиться актуальная.
        /// </remarks>
        /// <param name="gameCreate">Параметры для создания игры.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Игра.</returns>
        Task<Response<GameDto>> CreateAsync(GameCreateRequest gameCreate, CancellationToken token);

        /// <summary>
        /// Сохранение текущей игры.
        /// </summary>
        /// <param name="saveCreate">Параметры для создания сохранения.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сохранение игры.</returns>
        Task<Response<GameSaveDto>> SaveAsync(GameSaveCreateRequest saveCreate, CancellationToken token);

        /// <summary>
        /// Загрузка указанного сохранения игры.
        /// </summary>
        /// <param name="loadRequest">Параметры для загрузки сохранения.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> LoadAsync(GameLoadRequest loadRequest, CancellationToken token);

        /// <summary>
        /// Получение игры.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Игра.</returns>
        Task<Response<GameDto>> GetAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Получение текущей (актуальной) игры для указанного игрока.
        /// </summary>
        /// <param name="playerId">Идентификатор игрока.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Игра.</returns>
        Task<Response<GameDto>> GetCurrentAsync(Guid playerId, CancellationToken token);

        /// <summary>
        /// Получение списка игр.
        /// </summary>
        /// <param name="gameRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок игр.</returns>
        Task<ResponsePage<GameDto>> GetAllAsync(GamesRequest gameRequest, CancellationToken token);

        /// <summary>
        /// Получение списка сохранений игры.
        /// </summary>
        /// <param name="saveRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок сохранений игры.</returns>
        Task<ResponsePage<GameSaveDto>> GetAllSaveAsync(GameSavesRequest saveRequest, CancellationToken token);

        /// <summary>
        /// Удаление игры.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Удаление сохранения игры.
        /// </summary>
        /// <param name="id">Идентификатор сохранения игры.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        Task<Response> DeleteSaveAsync(Guid id, CancellationToken token);
    }
    /**@}*/
}