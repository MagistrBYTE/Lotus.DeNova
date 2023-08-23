//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusAvatarInfoController.cs
*		Контролёр для работы с аватаром персонажа.
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
		/// Контролёр для работы с аватаром персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class AvatarInfoController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusAvatarInfoService _avatarInfoService;
			private readonly ILogger<AvatarInfoController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="avatarInfoService">Интерфейс сервиса для работы с аватаром персонажа</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public AvatarInfoController(ILotusAvatarInfoService avatarInfoService, ILogger<AvatarInfoController> logger)
			{
				_avatarInfoService = avatarInfoService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание аватара персонажа по указанным данным
			/// </summary>
			/// <param name="avatarInfoCreate">Параметры для создания аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аватар персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<AvatarInfoDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] AvatarInfoCreateDto avatarInfoCreate, CancellationToken token)
			{
				var result = await _avatarInfoService.CreateAsync(avatarInfoCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного аватара персонажа
			/// </summary>
			/// <param name="avatarInfoUpdate">Параметры обновляемого аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аватар персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<AvatarInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] AvatarInfoDto avatarInfoUpdate, CancellationToken token)
			{
				var result = await _avatarInfoService.UpdateAsync(avatarInfoUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аватара персонажа
			/// </summary>
			/// <param name="id">Идентификатор аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аватар персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<AvatarInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _avatarInfoService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аватаров персонажа
			/// </summary>
			/// <param name="avatarInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок аватаров персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<AvatarInfoDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] AvatarInfosDto avatarInfoRequest, CancellationToken token)
			{
				var result = await _avatarInfoService.GetAllAsync(avatarInfoRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аватара персонажа
			/// </summary>
			/// <param name="id">Идентификатор аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
			{
				var result = await _avatarInfoService.DeleteAsync(id, token);
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