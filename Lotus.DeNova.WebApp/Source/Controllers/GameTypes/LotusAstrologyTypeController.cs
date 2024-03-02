using Lotus.Repository;
using Lotus.Web;

using Microsoft.AspNetCore.Mvc;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaWebAppController
     *@{*/
    /// <summary>
    /// Контролёр для работы с данными по астрологии.
    /// </summary>
    public class AstrologyTypeController : ControllerResultBase
    {
        #region Fields
        private readonly ILotusAstrologyTypeService _astrologyService;
        private readonly ILogger<AstrologyTypeController> _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="astrologyService">Интерфейс сервиса для работы с данными по астрологии.</param>
        /// <param name="logger">Интерфейс сервиса логгера.</param>
        public AstrologyTypeController(ILotusAstrologyTypeService astrologyService, ILogger<AstrologyTypeController> logger)
        {
            _astrologyService = astrologyService;
            _logger = logger;
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Создание данных по астрологии по указанным данным.
        /// </summary>
        /// <param name="astrologyCreate">Параметры для создания данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные по астрологии.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<AstrologyTypeDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AstrologyTypeCreateRequest astrologyCreate, CancellationToken token)
        {
            var result = await _astrologyService.CreateAsync(astrologyCreate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Обновление указанных данных по астрологии.
        /// </summary>
        /// <param name="astrologyUpdate">Параметры обновляемых данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные по астрологии.</returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<AstrologyTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] AstrologyTypeDto astrologyUpdate, CancellationToken token)
        {
            var result = await _astrologyService.UpdateAsync(astrologyUpdate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение указанных данных по астрологии.
        /// </summary>
        /// <param name="id">Идентификатор данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные по астрологии.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponsePage<AstrologyTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int id, CancellationToken token)
        {
            var result = await _astrologyService.GetAsync(id, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение списка данных по астрологии.
        /// </summary>
        /// <param name="astrologyRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок данных по астрологии.</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ResponsePage<AstrologyTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] AstrologyTypesRequest astrologyRequest, CancellationToken token)
        {
            var result = await _astrologyService.GetAllAsync(astrologyRequest, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Удаление данных по астрологии.
        /// </summary>
        /// <param name="id">Идентификатор данных по астрологии.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, CancellationToken token)
        {
            var result = await _astrologyService.DeleteAsync(id, token);
            return SendResponse(result);
        }
        #endregion
    }
    /**@}*/
}