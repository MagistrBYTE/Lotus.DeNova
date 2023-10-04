//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusPersonParameterController.cs
*		Контролёр для работы с параметрами персонажа.
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
		/// Контролёр для работы с параметрами персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class PersonParameterController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusPersonParameterService _personParameterService;
			private readonly ILogger<PersonParameterController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="personParameterService">Интерфейс сервиса для работы с параметрами персонажа</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public PersonParameterController(ILotusPersonParameterService personParameterService, ILogger<PersonParameterController> logger)
			{
				_personParameterService = personParameterService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание параметра персонажа по указанным данным
			/// </summary>
			/// <param name="personParameterCreate">Данные для создания параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<PersonParameterDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] PersonParameterCreateRequest personParameterCreate, CancellationToken token)
			{
				var result = await _personParameterService.CreateAsync(personParameterCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного параметра персонажа
			/// </summary>
			/// <param name="personParameterUpdate">Данные обновляемого параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<PersonParameterDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] PersonParameterDto personParameterUpdate, CancellationToken token)
			{
				var result = await _personParameterService.UpdateAsync(personParameterUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<PersonParameterDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _personParameterService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка параметров персонажа
			/// </summary>
			/// <param name="personParameterRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок параметров персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAll")]
			[ProducesResponseType(typeof(ResponsePage<PersonParameterDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] PersonParametersRequest personParameterRequest, CancellationToken token)
			{
				var result = await _personParameterService.GetAllAsync(personParameterRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _personParameterService.DeleteAsync(id, token);
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