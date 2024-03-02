namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
    *@{*/
    /// <summary>
    /// Базовый класс для создания сохраняемого состояния персонажа.
    /// </summary>
    public abstract class PersonStateCreateRequest
    {
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid PersonId { get; set; }
    }
    /**@}*/
}