namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс для создания сохранения игры.
    /// </summary>
    public class GameSaveCreateRequest
    {
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Идентификатор сохранения.
        /// </summary>
        public Guid? GameSaveId { get; set; }

        /// <summary>
        /// Название сохранения.
        /// </summary>
        public string? Name { get; set; }
    }
    /**@}*/
}