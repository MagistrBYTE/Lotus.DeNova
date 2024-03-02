using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaRaceType
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы рас.
    /// </summary>
    public static class XRaceTypeErrors
    {
        #region Fields
        /// <summary>
        /// Раса не найдена.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Раса не найдена",
            Succeeded = false,
        };

        /// <summary>
        /// Нельзя удалить константную расу.
        /// </summary>
        public static readonly Result NotDeleteConst = new()
        {
            Code = 1002,
            Message = "Нельзя удалить константную расу",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}