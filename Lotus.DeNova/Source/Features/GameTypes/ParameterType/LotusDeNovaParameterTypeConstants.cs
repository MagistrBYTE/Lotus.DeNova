namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных подсистемы параметров существ.
    /// </summary>
    public static class XParameterTypeConstants
    {
        //
        // ФИЗИЧЕСКИЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Физическая сила.
        /// </summary>
        public static readonly ParameterType PhysicalStrength = new()
        {
            Id = 1,
            Name = "PhysicalStrength",
            DisplayName = "Физическая сила",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Ловкость.
        /// </summary>
        public static readonly ParameterType Dexterity = new()
        {
            Id = 2,
            Name = "Dexterity",
            DisplayName = "Ловкость",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Выносливость.
        /// </summary>
        public static readonly ParameterType Endurance = new()
        {
            Id = 3,
            Name = "Endurance",
            DisplayName = "Выносливость",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Телосложение.
        /// </summary>
        public static readonly ParameterType Physique = new()
        {
            Id = 4,
            Name = "Physique",
            DisplayName = "Телосложение",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        //
        // МЕНТАЛЬНЫЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Восприятие.
        /// </summary>
        public static readonly ParameterType Perception = new()
        {
            Id = 5,
            Name = "Perception",
            DisplayName = "Восприятие",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Разум.
        /// </summary>
        public static readonly ParameterType Mind = new()
        {
            Id = 6,
            Name = "Mind",
            DisplayName = "Разум",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Сила воли.
        /// </summary>
        public static readonly ParameterType Willpower = new()
        {
            Id = 7,
            Name = "Willpower",
            DisplayName = "Сила воли",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Духовность.
        /// </summary>
        public static readonly ParameterType Spirituality = new()
        {
            Id = 8,
            Name = "Spirituality",
            DisplayName = "Духовность",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        //
        // СОЦИАЛЬНЫЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Внешность.
        /// </summary>
        public static readonly ParameterType Appearance = new()
        {
            Id = 9,
            Name = "Appearance",
            DisplayName = "Внешность",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Харизма.
        /// </summary>
        public static readonly ParameterType Charisma = new()
        {
            Id = 10,
            Name = "Charisma",
            DisplayName = "Харизма",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Влияние.
        /// </summary>
        public static readonly ParameterType Influence = new()
        {
            Id = 11,
            Name = "Influence",
            DisplayName = "Влияние",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Статус.
        /// </summary>
        public static readonly ParameterType Status = new()
        {
            Id = 12,
            Name = "Status",
            DisplayName = "Статус",
            GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
        };

        /// <summary>
        /// Список параметров существ для персонажей.
        /// </summary>
        public static readonly ParameterType[] PersonParameters = new ParameterType[]
        {
            PhysicalStrength!,
            Dexterity!,
            Endurance!,
            Physique!,
            Perception!,
            Mind!,
            Willpower!,
            Spirituality!,
            Appearance!,
            Charisma!,
            Influence!,
            Status!
        };
    }
    /**@}*/
}