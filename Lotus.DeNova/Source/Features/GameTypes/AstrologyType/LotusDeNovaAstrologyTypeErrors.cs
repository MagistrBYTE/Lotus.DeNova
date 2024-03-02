using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAstrologyType
	*@{*/
    /// <summary>
    /// Статический класс для определения ошибок подсистемы данных астрологии.
    /// </summary>
    public static class XAstrologyTypeErrors
    {
        #region Fields
        /// <summary>
        /// Данные по астрологии не найдены.
        /// </summary>
        public static readonly Result NotFound = new()
        {
            Code = 1000,
            Message = "Данные по астрологии не найдены",
            Succeeded = false,
        };

        /// <summary>
        /// Нельзя удалить константные данные по астрологии.
        /// </summary>
        public static readonly Result NotDeleteConst = new()
        {
            Code = 1002,
            Message = "Нельзя удалить константные данные по астрологии",
            Succeeded = false,
        };
        #endregion
    }
    /**@}*/
}