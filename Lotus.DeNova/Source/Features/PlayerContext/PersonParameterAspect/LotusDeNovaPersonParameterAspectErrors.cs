using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы аспектов параметров персонажа.
    /// </summary>
    public static class XPersonParameterAspectErrors
    {
        #region Fields
        /// <summary>
        /// Аспект параметра персонажа не найдена.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Аспект параметра персонажа не найдена",
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