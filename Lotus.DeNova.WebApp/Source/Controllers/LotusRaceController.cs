//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusAuthorizeController.cs
*		Контролёр для авторизации и аутентификации пользователя.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System.Security.Claims;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Web;
using Lotus.Core;
using Lotus.Repository;
using Lotus.Account;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
	{
		//-------------------------------------------------------------------------------------------------------------
		/**
         * \defrace DeNovaWebAppController Подсистема контролеров
         * \inrace DeNovaWebApp
         * \brief Подсистема контролеров.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Контролёр для работы с расами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class RaceController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusRaceService _raceService;
			private readonly ILogger<RaceController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="raceService">Интерфейс сервиса для работы с расами</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public RaceController(ILotusRaceService raceService, ILogger<RaceController> logger)
			{
				_raceService = raceService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание расы по указанным данным
			/// </summary>
			/// <param name="raceCreate">Параметры для создания расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<RaceDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] RaceCreateDto raceCreate, CancellationToken token)
			{
				var result = await _raceService.CreateAsync(raceCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанной расы
			/// </summary>
			/// <param name="raceUpdate">Параметры обновляемой расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<RaceDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] RaceDto raceUpdate, CancellationToken token)
			{
				var result = await _raceService.UpdateAsync(raceUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанной расы
			/// </summary>
			/// <param name="id">Идентификатор расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<RaceDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _raceService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка рас
			/// </summary>
			/// <param name="raceRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок рас</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<RaceDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] RacesDto raceRequest, CancellationToken token)
			{
				var result = await _raceService.GetAllAsync(raceRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление расы
			/// </summary>
			/// <param name="id">Идентификатор расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _raceService.DeleteAsync(id, token);
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