//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusPersonController.cs
*		Контролёр для работы с персонажами.
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
		/// Контролёр для работы с персонажами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class PersonController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusPersonService _personService;
			private readonly ILogger<PersonController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="personService">Интерфейс сервиса для работы с персонажами</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public PersonController(ILotusPersonService personService, ILogger<PersonController> logger)
			{
				_personService = personService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание персонажа по указанным данным
			/// </summary>
			/// <param name="personCreate">Параметры для создания персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<PersonDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] PersonCreateDto personCreate, CancellationToken token)
			{
				var result = await _personService.CreateAsync(personCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанной персонажа
			/// </summary>
			/// <param name="personUpdate">Параметры обновляемой персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<PersonDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] PersonDto personUpdate, CancellationToken token)
			{
				var result = await _personService.UpdateAsync(personUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного персонажа
			/// </summary>
			/// <param name="id">Идентификатор персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Персонаж</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<PersonDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _personService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка персонажей
			/// </summary>
			/// <param name="personRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок персонажей</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<PersonDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] PersonsDto personRequest, CancellationToken token)
			{
				var result = await _personService.GetAllAsync(personRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление персонажа
			/// </summary>
			/// <param name="id">Идентификатор персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _personService.DeleteAsync(id, token);
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