using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
    *@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы работы с персонажами.
    /// </summary>
    public static class XPersonErrors
    {
        #region Fields
        /// <summary>
        /// Персонаж не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Персонаж не найден",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}