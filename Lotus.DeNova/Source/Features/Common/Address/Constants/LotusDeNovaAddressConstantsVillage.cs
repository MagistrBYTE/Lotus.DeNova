namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddress
	*@{*/
    /// <summary>
    /// Статический класс для определения констант и первоначальных данных типа <see cref="AddressVillage"/>.
    /// </summary>
    public static class XAddressConstantsVillage
    {
        /// <summary>
        /// Андреевский.
        /// </summary>
        public static readonly AddressVillage Andreevsky =
            new(XAddressConstantsVillageSettlement.Andreyevskoye.Id, 100, "Андреевский");

        /// <summary>
        /// Мариинский.
        /// </summary>
        public static readonly AddressVillage Mariinskiy =
            new(XAddressConstantsVillageSettlement.Andreyevskoye.Id, 101, "Мариинский");

        /// <summary>
        /// Атамановский.
        /// </summary>
        public static readonly AddressVillage Atamanovskiy =
            new(XAddressConstantsVillageSettlement.Atamanovskoye.Id, 200, "Атамановский");

        /// <summary>
        /// Степной.
        /// </summary>
        public static readonly AddressVillage Stepnoy =
            new(XAddressConstantsVillageSettlement.Atamanovskoye.Id, 201, "Степной");
    }
    /**@}*/
}