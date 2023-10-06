//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusAddressStateController.cs
*		Контролёр для работы с местом жительства персонажа.
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
		/// Контролёр для работы с местом жительства персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
        public class AddressStateController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusAddressStateService _addressInfoService;
			private readonly ILogger<AddressStateController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="addressInfoService">Интерфейс сервиса для работы с местом жительства персонажа</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public AddressStateController(ILotusAddressStateService addressInfoService, ILogger<AddressStateController> logger)
			{
				_addressInfoService = addressInfoService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание место жительства персонажа по указанным данным
			/// </summary>
			/// <param name="addressInfoCreate">Параметры для создания место жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Место жительства персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<AddressStateDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] AddressStateCreateRequest addressInfoCreate, CancellationToken token)
			{
				var result = await _addressInfoService.CreateAsync(addressInfoCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного место жительства персонажа
			/// </summary>
			/// <param name="addressInfoUpdate">Параметры обновляемого место жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Место жительства персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<AddressStateDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] AddressStateDto addressInfoUpdate, CancellationToken token)
			{
				var result = await _addressInfoService.UpdateAsync(addressInfoUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного место жительства персонажа
			/// </summary>
			/// <param name="id">Идентификатор место жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Место жительства персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<AddressStateDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _addressInfoService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка мест жительства персонажа
			/// </summary>
			/// <param name="addressInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок мест жительства персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getAll")]
			[ProducesResponseType(typeof(ResponsePage<AddressStateDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] AddressStatesRequest addressInfoRequest, CancellationToken token)
			{
				var result = await _addressInfoService.GetAllAsync(addressInfoRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление место жительства персонажа
			/// </summary>
			/// <param name="id">Идентификатор место жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _addressInfoService.DeleteAsync(id, token);
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