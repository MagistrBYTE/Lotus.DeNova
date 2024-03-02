using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс игры.
    /// </summary>
    public class GameDto : IdentifierDtoId<Guid>
    {
        /// <summary>
        /// Идентификатор игрока.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор сценария.
        /// </summary>
        public int ScenarioId { get; set; }

        /// <summary>
        /// Статус текущей(актуальной) игры.
        /// </summary>
        /// <remarks>
        /// Для каждого игрока может быть только одна актуальная игра.
        /// </remarks>
        public bool IsCurrent { get; set; }
    }
    /**@}*/
}