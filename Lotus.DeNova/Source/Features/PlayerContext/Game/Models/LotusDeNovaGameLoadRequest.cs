namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс для загрузки сохранения игры.
    /// </summary>
    public class GameLoadRequest
    {
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Идентификатор сохранения.
        /// </summary>
        public Guid GameSaveId { get; set; }
    }
    /**@}*/
}