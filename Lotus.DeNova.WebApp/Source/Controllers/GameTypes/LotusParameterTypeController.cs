using Lotus.Repository;
using Lotus.Web;

using Microsoft.AspNetCore.Mvc;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaWebAppController
    *@{*/
    /// <summary>
    /// Контролёр для работы с параметрами существ.
    /// </summary>
    public class ParameterTypeController : ControllerResultBase
    {
        #region Fields
        private readonly ILotusParameterTypeService _parameterService;
        private readonly ILogger<ParameterTypeController> _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="parameterService">Интерфейс сервиса для работы с параметрами существ.</param>
        /// <param name="logger">Интерфейс сервиса логгера.</param>
        public ParameterTypeController(ILotusParameterTypeService parameterService, ILogger<ParameterTypeController> logger)
        {
            _parameterService = parameterService;
            _logger = logger;
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Создание параметра существа по указанным данным.
        /// </summary>
        /// <param name="parameterCreate">Данные для создания параметра существа.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр существа.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<ParameterTypeDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] ParameterTypeCreateRequest parameterCreate, CancellationToken token)
        {
            var result = await _parameterService.CreateAsync(parameterCreate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Обновление данных указанного параметра существа.
        /// </summary>
        /// <param name="parameterUpdate">Данные обновляемого параметра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр существа.</returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<ParameterTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ParameterTypeDto parameterUpdate, CancellationToken token)
        {
            var result = await _parameterService.UpdateAsync(parameterUpdate, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение указанного параметра существа.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Параметр существа.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponsePage<ParameterTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int id, CancellationToken token)
        {
            var result = await _parameterService.GetAsync(id, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Получение списка параметров существ.
        /// </summary>
        /// <param name="parameterRequest">Запрос для получения списка.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Cписок параметров существ.</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ResponsePage<ParameterTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] ParameterTypesRequest parameterRequest, CancellationToken token)
        {
            var result = await _parameterService.GetAllAsync(parameterRequest, token);
            return SendResponse(result);
        }

        /// <summary>
        /// Удаление параметра существа.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Статус успешности.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, CancellationToken token)
        {
            var result = await _parameterService.DeleteAsync(id, token);
            return SendResponse(result);
        }
        #endregion
    }
    /**@}*/
}