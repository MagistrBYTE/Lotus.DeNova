namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных подсистемы аспектов параметров существ.
    /// </summary>
    public static class XParameterAspectTypeConstants
    {
        #region Fields
        /// <summary>
        /// Сильные руки.
        /// </summary>
        public static readonly ParameterAspectType StrongArms = new()
        {
            Id = 1,
            Name = "StrongArms",
            DisplayName = "Сильные руки",
            ParameterTypeId = XParameterTypeConstants.PhysicalStrength.Id,
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };
        #endregion
    }
    /**@}*/
}