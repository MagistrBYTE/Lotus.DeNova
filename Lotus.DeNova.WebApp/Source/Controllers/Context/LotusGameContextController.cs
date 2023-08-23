//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusGameContextController.cs
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
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class GameContextController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusGameContextService _gameContextService;
			private readonly ILogger<GameContextController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="gameContextService">Интерфейс сервиса для работы с  контекстами игры</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public GameContextController(ILotusGameContextService gameContextService, ILogger<GameContextController> logger)
			{
				_gameContextService = gameContextService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание контекста игры по указанным данным
			/// </summary>
			/// <param name="gameContextCreate">Параметры для создания контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Контекст игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<GameContextDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] GameContextCreateDto gameContextCreate, CancellationToken token)
			{
				var result = await _gameContextService.CreateAsync(gameContextCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного контекста игры
			/// </summary>
			/// <param name="gameContextUpdate">Параметры обновляемого контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Контекст игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<GameContextDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] GameContextDto gameContextUpdate, CancellationToken token)
			{
				var result = await _gameContextService.UpdateAsync(gameContextUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного контекста игры
			/// </summary>
			/// <param name="id">Идентификатор контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Контекст игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<GameContextDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _gameContextService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка контекстов игр
			/// </summary>
			/// <param name="gameContextRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок контекстов игр</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<GameContextDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] GameContextsDto gameContextRequest, CancellationToken token)
			{
				var result = await _gameContextService.GetAllAsync(gameContextRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление контекста игры
			/// </summary>
			/// <param name="id">Идентификатор контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _gameContextService.DeleteAsync(id, token);
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