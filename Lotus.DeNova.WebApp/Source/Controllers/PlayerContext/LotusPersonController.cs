using Lotus.Repository;
using Lotus.Web;

using Microsoft.AspNetCore.Mvc;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaWebAppController
    *@{*/
    /// <summary>
    /// Контролёр для работы с персонажами.
    /// </summary>
    public class PersonController : ControllerResultBase
    {
        #region Fields
        private readonly ILotusPersonService _personService;
        private readonly ILogger<PersonController> _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="personService">Интерфейс сервиса для работы с персонажами.</param>
        /// <param name="logger">Интерфейс сервиса логгера.</param>
        public PersonController(ILotusPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Создание персонажа по указанным данным.
        /// </summary>
        /// <param name="personCreate">Параметры для создания персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<PersonDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] PersonCreateRequest personCreate, CancellationToken token)
        {
            var result = await _personService.CreateAsync(personCreate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Обновление данных указанной персонажа.
        /// </summary>
        /// <param name="personUpdate">Параметры обновляемого персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Раса.</returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<PersonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] PersonDto personUpdate, CancellationToken token)
        {
            var result = await _personService.UpdateAsync(personUpdate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение указанного персонажа.
        /// </summary>
        /// <param name="id">Идентификатор персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Персонаж.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponsePage<PersonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken token)
        {
            var result = await _personService.GetAsync(id, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение списка персонажей.
        /// </summary>
        /// <param name="personRequest">Параметры получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок персонажей.</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ResponsePage<PersonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] PersonsRequest personRequest, CancellationToken token)
        {
            var result = await _personService.GetAllAsync(personRequest, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Удаление персонажа.
        /// </summary>
        /// <param name="id">Идентификатор персонажа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken token)
        {
            var result = await _personService.DeleteAsync(id, token);
            return SendResponse(result);
        }
        #endregion
    }
    /**@}*/
}