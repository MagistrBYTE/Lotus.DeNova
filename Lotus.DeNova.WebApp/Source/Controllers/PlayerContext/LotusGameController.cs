//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusGameController.cs
*		Контролёр для работы с контекстами игры.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Microsoft.AspNetCore.Mvc;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Web;
using Lotus.Repository;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup DeNovaWebAppController
        *@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Контролёр для работы с контекстами игры
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
        public class GameController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusGameService _gameService;
			private readonly ILogger<GameController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="gameService">Интерфейс сервиса для работы с  контекстами игры</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public GameController(ILotusGameService gameService, ILogger<GameController> logger)
			{
				_gameService = gameService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание игры по указанным данным
			/// </summary>
			/// <remarks>
			/// Созданная игра становиться актуальная
			/// </remarks>
			/// <param name="gameCreate">Параметры для создания игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Игра</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<GameDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] GameCreateRequest gameCreate, CancellationToken token)
			{
				var result = await _gameService.CreateAsync(gameCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение текущей игры
			/// </summary>
			/// <param name="saveCreate">Параметры для создания сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сохранение игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("save")]
			[ProducesResponseType(typeof(Response<GameSaveDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Save([FromBody] GameSaveCreateRequest saveCreate, CancellationToken token)
			{
				var result = await _gameService.SaveAsync(saveCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка указанного сохранения игры
			/// </summary>
			/// <param name="loadRequest">Параметры для загрузки сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("load")]
			public async Task<IActionResult> Load([FromBody] GameLoadRequest loadRequest, CancellationToken token)
			{
				var result = await _gameService.LoadAsync(loadRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение текущей (актуальной) игры
			/// </summary>
			/// <param name="playerId">Идентификатор игрока</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Игра</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getCurrent")]
			[ProducesResponseType(typeof(Response<GameDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetCurrent([FromQuery] Guid playerId, CancellationToken token)
			{
				var result = await _gameService.GetCurrentAsync(playerId, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка игр
			/// </summary>
			/// <param name="gameRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок игр</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAll")]
			[ProducesResponseType(typeof(ResponsePage<GameDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] GamesRequest gameRequest, CancellationToken token)
			{
				var result = await _gameService.GetAllAsync(gameRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка сохранений игры
			/// </summary>
			/// <param name="saveRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок сохранений игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAllSave")]
			[ProducesResponseType(typeof(ResponsePage<GameSaveDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAllSave([FromQuery] GameSavesRequest saveRequest, CancellationToken token)
			{
				var result = await _gameService.GetAllSaveAsync(saveRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление игры
			/// </summary>
			/// <param name="id">Идентификатор игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _gameService.DeleteAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление сохранения игры
			/// </summary>
			/// <param name="id">Идентификатор сохранения игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("deleteSave")]
			public async Task<IActionResult> DeleteSave([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _gameService.DeleteSaveAsync(id, token);
				return SendResponse(result);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================