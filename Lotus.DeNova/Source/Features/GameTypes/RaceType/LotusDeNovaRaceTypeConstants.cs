namespace Lotus.DeNova
{
    /** \addtogroup DeNovaRaceType
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных подсистемы рас.
    /// </summary>
    public static class XRaceTypeConstants
    {
        #region Fields
        /// <summary>
        /// Эриец.
        /// </summary>
        public static readonly RaceType Erian = new()
        {
            Id = 1,
            Name = "Erian",
            DisplayName = "Эриец",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Завротеанен.
        /// </summary>
        public static readonly RaceType Zavroteanen = new()
        {
            Id = 2,
            Name = "Zavroteanen",
            DisplayName = "Завротеанен",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Леохарт.
        /// </summary>
        public static readonly RaceType Leohart = new()
        {
            Id = 3,
            Name = "Leohart",
            DisplayName = "Леохарт",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Триб.
        /// </summary>
        public static readonly RaceType Tribe = new()
        {
            Id = 4,
            Name = "Tribe",
            DisplayName = "Триб",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Гвелл.
        /// </summary>
        public static readonly RaceType Gwell = new()
        {
            Id = 5,
            Name = "Gwell",
            DisplayName = "Гвелл",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Эль`гоу.
        /// </summary>
        public static readonly RaceType Elgou = new()
        {
            Id = 6,
            Name = "Elgou",
            DisplayName = "Эль`гоу",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Фергариец.
        /// </summary>
        public static readonly RaceType Fergarian = new()
        {
            Id = 7,
            Name = "Fergarian",
            DisplayName = "Фергариец",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };
        #endregion
    }
    /**@}*/
}