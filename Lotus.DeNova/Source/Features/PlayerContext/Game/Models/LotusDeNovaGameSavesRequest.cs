using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс для получения списка сохранений игры с учетом фильтрации и сортировки.
    /// </summary>
    public class GameSavesRequest : Request
    {
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }
    }
    /**@}*/
}