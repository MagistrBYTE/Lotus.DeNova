//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusScenarioTypeController.cs
*		Контролёр для работы с расами.
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
		/// Контролёр для работы с расами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class ScenarioTypeController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusScenarioTypeService _scenarioService;
			private readonly ILogger<ScenarioTypeController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="scenarioService">Интерфейс сервиса для работы с расами</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public ScenarioTypeController(ILotusScenarioTypeService scenarioService, ILogger<ScenarioTypeController> logger)
			{
				_scenarioService = scenarioService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание сценария по указанным данным
			/// </summary>
			/// <param name="scenarioCreate">Параметры для создания сценария</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сценарий</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<ScenarioTypeDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] ScenarioTypeCreateRequest scenarioCreate, CancellationToken token)
			{
				var result = await _scenarioService.CreateAsync(scenarioCreate, token);
				return SendResponse(result);
			}
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанной сценария
			/// </summary>
			/// <param name="scenarioUpdate">Параметры обновляемой сценария</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сценарий</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<ScenarioTypeDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] ScenarioTypeDto scenarioUpdate, CancellationToken token)
			{
				var result = await _scenarioService.UpdateAsync(scenarioUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанной сценария
			/// </summary>
			/// <param name="id">Идентификатор сценария</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сценарий</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<ScenarioTypeDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _scenarioService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка сценариев
			/// </summary>
			/// <param name="scenarioRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок рас</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAll")]
			[ProducesResponseType(typeof(ResponsePage<ScenarioTypeDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] ScenarioTypesRequest scenarioRequest, CancellationToken token)
			{
				var result = await _scenarioService.GetAllAsync(scenarioRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление сценария
			/// </summary>
			/// <param name="id">Идентификатор сценария</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _scenarioService.DeleteAsync(id, token);
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