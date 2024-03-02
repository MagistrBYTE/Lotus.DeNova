namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameSettingType
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных подсистемы сеттинга игры.
    /// </summary>
    public static class XGameSettingTypeConstants
    {
        #region Fields
        /// <summary>
        /// Игровой мир Сентра.
        /// </summary>
        public static readonly GameSettingType Sentra = new()
        {
            Id = 1,
            Name = "Sentra",
            DisplayName = "Сентра",
        };
        #endregion
    }
    /**@}*/
}