namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
    *@{*/
    /// <summary>
    /// Класс для создания нового персонажа.
    /// </summary>
    public class PersonCreateRequest
    {
        /// <summary>
        /// Идентификатор игрока.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя персонажа.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Идентификатор расы.
        /// </summary>
        public int RaceTypeId { get; set; }

        /// <summary>
        /// Идентификатор аватара.
        /// </summary>
        public Guid? AvatarId { get; set; }

        /// <summary>
        /// Статус локального изображения для аватара.
        /// </summary>
        public bool? IsLocalAvatar { get; set; }

        /// <summary>
        /// Идентификатор информации о астрологических сведениях.
        /// </summary>
        public int? AstrologyTypeId { get; set; }
    }
    /**@}*/
}