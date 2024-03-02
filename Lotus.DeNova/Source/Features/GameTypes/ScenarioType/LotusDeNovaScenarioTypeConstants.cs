namespace Lotus.DeNova
{
    /** \addtogroup DeNovaScenarioType
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных подсистемы сценариев.
    /// </summary>
    public static class XScenarioTypeConstants
    {
        #region Fields
        /// <summary>
        /// Песочница.
        /// </summary>
        public static readonly ScenarioType Sandbox = new()
        {
            Id = 1,
            Name = "Sandbox",
            DisplayName = "Песочница",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };
        #endregion
    }
    /**@}*/
}