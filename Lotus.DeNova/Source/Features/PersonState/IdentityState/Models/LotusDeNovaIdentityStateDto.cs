namespace Lotus.DeNova
{
    /** \addtogroup DeNovaIdentityState
        *@{*/
    /// <summary>
    /// Класс для определения идентификационных сведений о персонаже.
    /// </summary>
    public class IdentityStateDto : PersonStateDto
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid IdentityStateId { get; set; }

        /// <summary>
        /// Имя персонажа.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Фамилия персонажа.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Отчество персонажа.
        /// </summary>
        public string? FatherName { get; set; }

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