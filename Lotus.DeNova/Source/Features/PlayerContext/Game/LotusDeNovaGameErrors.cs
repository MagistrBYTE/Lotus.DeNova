using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы работы с контекстом игрока.
    /// </summary>
    public static class XGameErrors
    {
        #region Fields
        /// <summary>
        /// Контекст игры не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Контекст игры не найден",
            Succeeded = false,
        };

        /// <summary>
        /// Сохранение игры не найдено.
        /// </summary>
        public static readonly Result SaveNotFound = new()
        {
            Code = 1002,
            Message = "Сохранение игры не найдено",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}