﻿//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusParameterAspectTypeController.cs
*		Контролёр для работы с аспектами параметров существ.
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
		/// Контролёр для работы с аспектами параметров существ
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class ParameterAspectTypeController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusParameterAspectTypeService _parameterAspectService;
			private readonly ILogger<ParameterAspectTypeController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="parameterAspectService">Интерфейс сервиса для работы с аспектами параметров существ</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public ParameterAspectTypeController(ILotusParameterAspectTypeService parameterAspectService, ILogger<ParameterAspectTypeController> logger)
			{
				_parameterAspectService = parameterAspectService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание аспекта параметра существа по указанным данным
			/// </summary>
			/// <param name="parameterAspectCreate">Данные для создания аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра существа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<ParameterAspectTypeDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] ParameterAspectTypeCreateRequest parameterAspectCreate, CancellationToken token)
			{
				var result = await _parameterAspectService.CreateAsync(parameterAspectCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного аспекта параметра существа
			/// </summary>
			/// <param name="parameterAspectUpdate">Данные обновляемого аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра существа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<ParameterAspectTypeDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] ParameterAspectTypeDto parameterAspectUpdate, CancellationToken token)
			{
				var result = await _parameterAspectService.UpdateAsync(parameterAspectUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аспекта параметра существа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра существа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<ParameterAspectTypeDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _parameterAspectService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аспектов параметров существ
			/// </summary>
			/// <param name="parameterAspectRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок аспектов параметров существ</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAll")]
			[ProducesResponseType(typeof(ResponsePage<ParameterAspectTypeDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] ParameterAspectTypesRequest parameterAspectRequest, CancellationToken token)
			{
				var result = await _parameterAspectService.GetAllAsync(parameterAspectRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аспекта параметра существа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _parameterAspectService.DeleteAsync(id, token);
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