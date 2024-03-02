using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPlacementState
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы местоположения персонажа.
    /// </summary>
    public static class XPlacementStateErrors
    {
        #region Fields
        /// <summary>
        /// Указанное местоположение не найдено.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Указанное местоположение не найдено",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}