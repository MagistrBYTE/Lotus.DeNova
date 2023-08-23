//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusIdentityInfoController.cs
*		Контролёр для работы с идентификационными сведениями о персонаже.
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
		/// Контролёр для работы с идентификационными сведениями о персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class IdentityInfoController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusIdentityInfoService _identityInfoService;
			private readonly ILogger<IdentityInfoController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="identityInfoService">Интерфейс сервиса для работы с идентификационными сведениями о персонаже</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public IdentityInfoController(ILotusIdentityInfoService identityInfoService, ILogger<IdentityInfoController> logger)
			{
				_identityInfoService = identityInfoService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание идентификационных сведений о персонаже по указанным данным
			/// </summary>
			/// <param name="identityInfoCreate">Параметры для создания идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Идентификационные сведения о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<IdentityInfoDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] IdentityInfoCreateDto identityInfoCreate, CancellationToken token)
			{
				var result = await _identityInfoService.CreateAsync(identityInfoCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoUpdate">Параметры обновляемых идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Идентификационные сведения о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<IdentityInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] IdentityInfoDto identityInfoUpdate, CancellationToken token)
			{
				var result = await _identityInfoService.UpdateAsync(identityInfoUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанных идентификационных сведений о персонаже
			/// </summary>
			/// <param name="id">Идентификатор идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Идентификационные сведения о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<IdentityInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _identityInfoService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список идентификационных сведений о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<IdentityInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] IdentityInfosDto identityInfoRequest, CancellationToken token)
			{
				var result = await _identityInfoService.GetAllAsync(identityInfoRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление идентификационных сведений о персонаже
			/// </summary>
			/// <param name="id">Идентификатор идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _identityInfoService.DeleteAsync(id, token);
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