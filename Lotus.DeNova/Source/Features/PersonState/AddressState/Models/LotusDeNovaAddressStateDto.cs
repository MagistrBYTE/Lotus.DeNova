namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddressState
    *@{*/
    /// <summary>
    /// Класс для определения информации об месте жительства.
    /// </summary>
    public class AddressStateDto : PersonStateDto
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid AddressStateId { get; set; }

        /// <summary>
        /// Идентификатор адреса.
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime BeginPeriod { get; set; }

        /// <summary>
        /// Дата окончания.
        /// </summary>
        public DateTime? EndPeriod { get; set; }
    }
    /**@}*/
}