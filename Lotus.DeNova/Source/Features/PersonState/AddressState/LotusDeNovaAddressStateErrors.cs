using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddressState
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы места жительства.
    /// </summary>
    public static class XAddressStateErrors
    {
        #region Fields
        /// <summary>
        /// Информация не найдена.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Информация не найдена",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}