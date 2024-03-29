using Lotus.Repository;
using Lotus.Web;

using Microsoft.AspNetCore.Mvc;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaWebAppController
    *@{*/
    /// <summary>
    /// Контролёр для работы с идентификационными сведениями о персонаже.
    /// </summary>
    public class IdentityStateController : ControllerResultBase
    {
        #region Fields
        private readonly ILotusIdentityStateService _identityInfoService;
        private readonly ILogger<IdentityStateController> _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="identityInfoService">Интерфейс сервиса для работы с идентификационными сведениями о персонаже.</param>
        /// <param name="logger">Интерфейс сервиса логгера.</param>
        public IdentityStateController(ILotusIdentityStateService identityInfoService, ILogger<IdentityStateController> logger)
        {
            _identityInfoService = identityInfoService;
            _logger = logger;
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Создание идентификационных сведений о персонаже по указанным данным.
        /// </summary>
        /// <param name="identityInfoCreate">Параметры для создания идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификационные сведения о персонаже.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<IdentityStateDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] IdentityStateCreateRequest identityInfoCreate, CancellationToken token)
        {
            var result = await _identityInfoService.CreateAsync(identityInfoCreate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Обновление данных идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="identityInfoUpdate">Параметры обновляемых идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификационные сведения о персонаже.</returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<IdentityStateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] IdentityStateDto identityInfoUpdate, CancellationToken token)
        {
            var result = await _identityInfoService.UpdateAsync(identityInfoUpdate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение указанных идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="id">Идентификатор идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификационные сведения о персонаже.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponsePage<IdentityStateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
        {
            var result = await _identityInfoService.GetAsync(id, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение списка идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="identityInfoRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список идентификационных сведений о персонаже.</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ResponsePage<IdentityStateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] IdentityStatesDto identityInfoRequest, CancellationToken token)
        {
            var result = await _identityInfoService.GetAllAsync(identityInfoRequest, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Удаление идентификационных сведений о персонаже.
        /// </summary>
        /// <param name="id">Идентификатор идентификационных сведений о персонаже.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
        {
            var result = await _identityInfoService.DeleteAsync(id, token);
            return SendResponse(result);
        }
        #endregion
    }
    /**@}*/
}