﻿//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusPlacementInfoController.cs
*		Контролёр для работы с местоположением персонажа.
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
		/// Контролёр для работы с местоположением персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class PlacementInfoController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusPlacementInfoService _placementInfoService;
			private readonly ILogger<PlacementInfoController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="placementInfoService">Интерфейс сервиса для работы с местоположением персонажа</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public PlacementInfoController(ILotusPlacementInfoService placementInfoService, 
				ILogger<PlacementInfoController> logger)
			{
				_placementInfoService = placementInfoService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание местоположение персонажа по указанным данным
			/// </summary>
			/// <param name="placementInfoCreate">Параметры для создания местоположение персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Местоположение персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<PlacementInfoDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] PlacementInfoCreateDto placementInfoCreate, CancellationToken token)
			{
				var result = await _placementInfoService.CreateAsync(placementInfoCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного местоположение персонажа
			/// </summary>
			/// <param name="placementInfoUpdate">Параметры обновляемого местоположение персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Местоположение персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<PlacementInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] PlacementInfoDto placementInfoUpdate, CancellationToken token)
			{
				var result = await _placementInfoService.UpdateAsync(placementInfoUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного местоположение персонажа
			/// </summary>
			/// <param name="id">Идентификатор местоположение персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Местоположение персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<PlacementInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _placementInfoService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аватаров персонажа
			/// </summary>
			/// <param name="placementInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок аватаров персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<PlacementInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] PlacementInfosDto placementInfoRequest, CancellationToken token)
			{
				var result = await _placementInfoService.GetAllAsync(placementInfoRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление местоположение персонажа
			/// </summary>
			/// <param name="id">Идентификатор местоположение персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _placementInfoService.DeleteAsync(id, token);
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