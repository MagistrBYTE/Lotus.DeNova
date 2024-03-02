using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс для сохранения игры.
    /// </summary>
    public class GameSaveDto : IdentifierDtoId<Guid>
    {
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Название сохранения.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Дата создания сохранения.
        /// </summary>
        public DateTime Created { get; set; }
    }
    /**@}*/
}