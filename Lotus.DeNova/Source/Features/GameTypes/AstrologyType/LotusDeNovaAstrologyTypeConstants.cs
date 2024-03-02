namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAstrologyType
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных подсистемы данных астрологии.
    /// </summary>
    public static class XAstrologyTypeConstants
    {
        #region Fields
        /// <summary>
        /// Змееносец.
        /// </summary>
        public static readonly AstrologyType Ophiuchus = new()
        {
            Id = 1,
            ZodiacSign = "Змееносец",
            StoneZodiac = "Алмаз",
            TreeZodiac = "Лиана",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Кецалькоатль.
        /// </summary>
        public static readonly AstrologyType Quetzalcoatl = new()
        {
            Id = 2,
            ZodiacSign = "Кецалькоатль",
            StoneZodiac = "Изумруд",
            TreeZodiac = "Ива",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Телец.
        /// </summary>
        public static readonly AstrologyType Taurus = new()
        {
            Id = 3,
            ZodiacSign = "Телец",
            StoneZodiac = "Топаз",
            TreeZodiac = "Дуб",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };
        #endregion
    }
    /**@}*/
}