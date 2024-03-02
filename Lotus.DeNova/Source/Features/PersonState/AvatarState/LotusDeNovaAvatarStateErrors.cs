using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAvatarState
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы аватара персонажа.
    /// </summary>
    public static class XAvatarStateErrors
    {
        #region Fields
        /// <summary>
        /// Аватар не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Аватар не найден",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}