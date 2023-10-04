//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusPersonParameterAspectController.cs
*		Контролёр для работы с аспектами параметров персонажа.
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
		/// Контролёр для работы с аспектами параметров персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PersonParameterAspectController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusPersonParameterAspectService _personParameterAspectService;
			private readonly ILogger<PersonParameterAspectController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="personParameterAspectService">Интерфейс сервиса для работы с аспектами параметров персонажа</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public PersonParameterAspectController(ILotusPersonParameterAspectService personParameterAspectService, ILogger<PersonParameterAspectController> logger)
			{
				_personParameterAspectService = personParameterAspectService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание аспекта параметра персонажа по указанным данным
			/// </summary>
			/// <param name="personParameterAspectCreate">Данные для создания аспекта параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<PersonParameterAspectDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] PersonParameterAspectCreateRequest personParameterAspectCreate, CancellationToken token)
			{
				var result = await _personParameterAspectService.CreateAsync(personParameterAspectCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного аспекта параметра персонажа
			/// </summary>
			/// <param name="personParameterAspectUpdate">Данные обновляемого аспекта параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<PersonParameterAspectDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] PersonParameterAspectDto personParameterAspectUpdate, CancellationToken token)
			{
				var result = await _personParameterAspectService.UpdateAsync(personParameterAspectUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аспекта параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<PersonParameterAspectDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _personParameterAspectService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аспектов параметров персонажа
			/// </summary>
			/// <param name="personParameterAspectRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок аспектов параметров персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAll")]
			[ProducesResponseType(typeof(ResponsePage<PersonParameterAspectDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] PersonParameterAspectsRequest personParameterAspectRequest, CancellationToken token)
			{
				var result = await _personParameterAspectService.GetAllAsync(personParameterAspectRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аспекта параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _personParameterAspectService.DeleteAsync(id, token);
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