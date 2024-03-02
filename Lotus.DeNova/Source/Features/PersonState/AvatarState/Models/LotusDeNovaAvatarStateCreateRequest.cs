namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAvatarState
    *@{*/
    /// <summary>
    /// Класс для создания нового аватара персонажа.
    /// </summary>
    public class AvatarStateCreateRequest : PersonStateCreateRequest
    {
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