using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
    *@{*/
    /// <summary>
    /// Базовый класс для получения состояний персонажа.
    /// </summary>
    public abstract class PersonStatesRequest : Request
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