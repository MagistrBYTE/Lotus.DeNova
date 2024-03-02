namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс для создания новой игры.
    /// </summary>
    public class GameCreateRequest
    {
        /// <summary>
        /// Идентификатор игрока.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор сценария.
        /// </summary>
        public int ScenarioId { get; set; }
    }
    /**@}*/
}