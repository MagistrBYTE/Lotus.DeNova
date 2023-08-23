//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusGameSaveController.cs
*		Контролёр для работы с сохранением/загрузкой контекста игры.
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
		/// Контролёр для работы с сохранением/загрузкой контекста игры
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class GameSaveController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusGameSaveService _gameSaveService;
			private readonly ILogger<GameSaveController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="gameSaveService">Интерфейс сервиса для сохранения контекста игры</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public GameSaveController(ILotusGameSaveService gameSaveService, ILogger<GameSaveController> logger)
			{
				_gameSaveService = gameSaveService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение текущего контекста игры
			/// </summary>
			/// <param name="saveCreate">Параметры для создания сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сохранение контекста игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("save")]
			[ProducesResponseType(typeof(Response<GameSaveDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Save([FromBody] GameSaveCreateDto saveCreate, CancellationToken token)
			{
				var result = await _gameSaveService.SaveAsync(saveCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка указанного сохранения контекста игры
			/// </summary>
			/// <param name="load">Параметры для загрузки сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("load")]
			public async Task<IActionResult> Load([FromBody] GameLoadDto load, CancellationToken token)
			{
				var result = await _gameSaveService.LoadAsync(load, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление сохранения контекста игры
			/// </summary>
			/// <param name="saveUpdate">Параметры обновляемого сохранения контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сохранение контекста игры</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<GameSaveDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] GameSaveDto saveUpdate, CancellationToken token)
			{
				var result = await _gameSaveService.UpdateAsync(saveUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление сохранения контекста игры
			/// </summary>
			/// <param name="id">Идентификатор сохранения контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _gameSaveService.DeleteAsync(id, token);
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