using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaIdentityState
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы идентификационных сведений о персонаже.
    /// </summary>
    public static class XIdentityStateErrors
    {
        #region Fields
        /// <summary>
        /// Сведения не найдены.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Сведения не найдены",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}