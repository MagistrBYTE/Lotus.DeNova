//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusAstrologyController.cs
*		Контролёр для работы с астрологическими данными.
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
		/// Контролёр для работы с астрологическими данными
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class AstrologyController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusAstrologyService _astrologyService;
			private readonly ILogger<AstrologyController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="astrologyService">Интерфейс сервиса для работы с астрологическими данными</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public AstrologyController(ILotusAstrologyService astrologyService, ILogger<AstrologyController> logger)
			{
				_astrologyService = astrologyService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание астрологических данных по указанным данным
			/// </summary>
			/// <param name="astrologyCreate">Параметры для создания астрологических данных</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Астрологические данные</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<AstrologyDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] AstrologyCreateDto astrologyCreate, CancellationToken token)
			{
				var result = await _astrologyService.CreateAsync(astrologyCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанных астрологических данных
			/// </summary>
			/// <param name="astrologyUpdate">Параметры обновляемой астрологических данных</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Астрологические данные</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<AstrologyDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] AstrologyDto astrologyUpdate, CancellationToken token)
			{
				var result = await _astrologyService.UpdateAsync(astrologyUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанных астрологических данных
			/// </summary>
			/// <param name="id">Идентификатор астрологических данных</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Астрологические данные</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<AstrologyDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _astrologyService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка астрологических данных
			/// </summary>
			/// <param name="astrologyRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок астрологических данных</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<AstrologyDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] AstrologiesDto astrologyRequest, CancellationToken token)
			{
				var result = await _astrologyService.GetAllAsync(astrologyRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление астрологических данных
			/// </summary>
			/// <param name="id">Идентификатор астрологических данных</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _astrologyService.DeleteAsync(id, token);
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