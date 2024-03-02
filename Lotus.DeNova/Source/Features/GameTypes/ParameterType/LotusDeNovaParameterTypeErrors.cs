using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы параметров существ.
    /// </summary>
    public static class XParameterTypeErrors
    {
        #region Fields
        /// <summary>
        /// Параметр не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Параметр не найден",
            Succeeded = false,
        };

        /// <summary>
        /// Нельзя удалить константный параметр.
        /// </summary>
        public static readonly Result NotDeleteConst = new()
        {
            Code = 1002,
            Message = "Нельзя удалить константный параметр",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}