//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема контролеров
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusImageController.cs
*		Контролёр для работы с изображениями.
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
		/// Контролёр для работы с изображениями
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ApiController]
        [Route($"{XConstants.PrefixApi}/[controller]")]
        public class ImageController : ControllerResultBase
		{
			#region ======================================= ДАННЫЕ ====================================================
			private readonly ILotusImageService _imageService;
			private readonly ILogger<ImageController> _logger;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="imageService">Интерфейс сервиса для работы с изображениями</param>
			/// <param name="logger">Интерфейс сервиса логгера</param>
			//---------------------------------------------------------------------------------------------------------
			public ImageController(ILotusImageService imageService, ILogger<ImageController> logger)
			{
				_imageService = imageService;
				_logger = logger;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание изображения по указанным данным
			/// </summary>
			/// <param name="imageCreate">Параметры для создания изображения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPost("create")]
			[ProducesResponseType(typeof(Response<ImageDto>), StatusCodes.Status201Created)]
			public async Task<IActionResult> Create([FromBody] ImageCreateDto imageCreate, CancellationToken token)
			{
				var result = await _imageService.CreateAsync(imageCreate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного изображения
			/// </summary>
			/// <param name="imageUpdate">Параметры обновляемого изображения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpPut("update")]
			[ProducesResponseType(typeof(Response<ImageDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Update([FromBody] ImageDto imageUpdate, CancellationToken token)
			{
				var result = await _imageService.UpdateAsync(imageUpdate, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного изображения
			/// </summary>
			/// <param name="id">Идентификатор изображения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("get")]
			[ProducesResponseType(typeof(ResponsePage<ImageDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> Get([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _imageService.GetAsync(id, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка изображений
			/// </summary>
			/// <param name="imageRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок изображений</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpGet("getall")]
			[ProducesResponseType(typeof(ResponsePage<ImageDto>), StatusCodes.Status200OK)]
			public async Task<IActionResult> GetAll([FromQuery] ImagesDto imageRequest, CancellationToken token)
			{
				var result = await _imageService.GetAllAsync(imageRequest, token);
				return SendResponse(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление изображения
			/// </summary>
			/// <param name="id">Идентификатор изображения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			[HttpDelete("delete")]
			public async Task<IActionResult> Delete([FromQuery] Int32 id, CancellationToken token)
			{
				var result = await _imageService.DeleteAsync(id, token);
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