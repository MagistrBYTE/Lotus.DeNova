using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы аспектов параметров существами.
    /// </summary>
    public static class XParameterAspectTypeErrors
    {
        #region Fields
        /// <summary>
        /// Аспекта параметра существа не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Аспекта параметра существа не найден",
            Succeeded = false,
        };

        /// <summary>
        /// Нельзя удалить константный аспект параметра существа.
        /// </summary>
        public static readonly Result NotDeleteConst = new()
        {
            Code = 1002,
            Message = "Нельзя удалить константный аспект параметра существа",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}