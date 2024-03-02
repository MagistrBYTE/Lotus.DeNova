using Lotus.Repository;
using Lotus.Web;

using Microsoft.AspNetCore.Mvc;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaWebAppController
    *@{*/
    /// <summary>
    /// Контролёр для работы с аватаром персонажа.
    /// </summary>
    public class AvatarStateController : ControllerResultBase
    {
        #region Fields
        private readonly ILotusAvatarStateService _avatarInfoService;
        private readonly ILogger<AvatarStateController> _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="avatarInfoService">Интерфейс сервиса для работы с аватаром персонажа.</param>
        /// <param name="logger">Интерфейс сервиса логгера.</param>
        public AvatarStateController(ILotusAvatarStateService avatarInfoService, ILogger<AvatarStateController> logger)
        {
            _avatarInfoService = avatarInfoService;
            _logger = logger;
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Создание аватара персонажа по указанным данным.
        /// </summary>
        /// <param name="avatarInfoCreate">Параметры для создания аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аватар персонажа.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<AvatarStateDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AvatarStateCreateRequest avatarInfoCreate, CancellationToken token)
        {
            var result = await _avatarInfoService.CreateAsync(avatarInfoCreate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Обновление данных указанного аватара персонажа.
        /// </summary>
        /// <param name="avatarInfoUpdate">Параметры обновляемого аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аватар персонажа.</returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<AvatarStateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] AvatarStateDto avatarInfoUpdate, CancellationToken token)
        {
            var result = await _avatarInfoService.UpdateAsync(avatarInfoUpdate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение указанного аватара персонажа.
        /// </summary>
        /// <param name="id">Идентификатор аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Аватар персонажа.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponsePage<AvatarStateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
        {
            var result = await _avatarInfoService.GetAsync(id, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение списка аватаров персонажа.
        /// </summary>
        /// <param name="avatarInfoRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок аватаров персонажа.</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ResponsePage<AvatarStateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] AvatarStatesDto avatarInfoRequest, CancellationToken token)
        {
            var result = await _avatarInfoService.GetAllAsync(avatarInfoRequest, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Удаление аватара персонажа.
        /// </summary>
        /// <param name="id">Идентификатор аватара персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
        {
            var result = await _avatarInfoService.DeleteAsync(id, token);
            return SendResponse(result);
        }
        #endregion
    }
    /**@}*/
}