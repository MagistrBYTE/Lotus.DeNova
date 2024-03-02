namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddressState
    *@{*/
    /// <summary>
    /// Класс для создания нового места жительства.
    /// </summary>
    public class AddressStateCreateRequest : PersonStateCreateRequest
    {
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