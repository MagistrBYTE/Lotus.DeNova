namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAvatarState
        *@{*/
    /// <summary>
    /// Класс для определения аватара персонажа.
    /// </summary>
    public class AvatarStateDto : PersonStateDto
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid AvatarStateId { get; set; }

        /// <summary>
        /// Идентификатор изображения.
        /// </summary>
        public int? ImageId { get; set; }

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