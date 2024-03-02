using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaScenarioType
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы сценария.
    /// </summary>
    public static class XScenarioTypeErrors
    {
        #region Fields
        /// <summary>
        /// Сценарий не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Сценарий не найден",
            Succeeded = false,
        };

        /// <summary>
        /// Нельзя удалить константный сценарий.
        /// </summary>
        public static readonly Result NotDeleteConst = new()
        {
            Code = 1002,
            Message = "Нельзя удалить константный сценарий",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}