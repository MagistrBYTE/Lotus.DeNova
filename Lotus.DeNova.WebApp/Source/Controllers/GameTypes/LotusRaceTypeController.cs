using Lotus.Repository;
using Lotus.Web;

using Microsoft.AspNetCore.Mvc;

namespace Lotus.DeNova
{
    /**
     * \defrace DeNovaWebAppController Подсистема контролеров
     * \inrace DeNovaWebApp
     * \brief Подсистема контролеров.
     * @{
     */
    /// <summary>
    /// Контролёр для работы с расами.
    /// </summary>
    public class RaceTypeController : ControllerResultBase
    {
        #region Fields
        private readonly ILotusRaceTypeService _raceService;
        private readonly ILogger<RaceTypeController> _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="raceService">Интерфейс сервиса для работы с расами.</param>
        /// <param name="logger">Интерфейс сервиса логгера.</param>
        public RaceTypeController(ILotusRaceTypeService raceService, ILogger<RaceTypeController> logger)
        {
            _raceService = raceService;
            _logger = logger;
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Создание расы по указанным данным.
        /// </summary>
        /// <param name="raceCreate">Параметры для создания расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<RaceTypeDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] RaceTypeCreateRequest raceCreate, CancellationToken token)
        {
            var result = await _raceService.CreateAsync(raceCreate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Обновление данных указанной расы.
        /// </summary>
        /// <param name="raceUpdate">Параметры обновляемой расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<RaceTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] RaceTypeDto raceUpdate, CancellationToken token)
        {
            var result = await _raceService.UpdateAsync(raceUpdate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение указанной расы.
        /// </summary>
        /// <param name="id">Идентификатор расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponsePage<RaceTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int id, CancellationToken token)
        {
            var result = await _raceService.GetAsync(id, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение списка рас.
        /// </summary>
        /// <param name="raceRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок рас.</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ResponsePage<RaceTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] RaceTypesRequest raceRequest, CancellationToken token)
        {
            var result = await _raceService.GetAllAsync(raceRequest, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Удаление расы.
        /// </summary>
        /// <param name="id">Идентификатор расы.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, CancellationToken token)
        {
            var result = await _raceService.DeleteAsync(id, token);
            return SendResponse(result);
        }
        #endregion
    }
    /**@}*/
}