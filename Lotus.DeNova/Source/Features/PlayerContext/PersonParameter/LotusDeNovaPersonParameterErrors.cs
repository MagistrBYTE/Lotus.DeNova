using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы параметров персонажа.
    /// </summary>
    public static class XPersonParameterErrors
    {
        #region Fields
        /// <summary>
        /// Параметр персонажа не найден.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Параметр персонажа не найден",
            Succeeded = false,
        };

        /// <summary>
        /// Нельзя удалить константный параметр персонажа.
        /// </summary>
        public static readonly Result NotDeleteConst = new()
        {
            Code = 1002,
            Message = "Нельзя удалить константный параметр персонажа",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}