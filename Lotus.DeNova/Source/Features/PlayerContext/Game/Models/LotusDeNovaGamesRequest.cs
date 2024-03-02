using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
    *@{*/
    /// <summary>
    /// Класс для получения списка игр с учетом фильтрации и сортировки.
    /// </summary>
    public class GamesRequest : Request
    {
        /// <summary>
        /// Идентификатор игрока.
        /// </summary>
        public Guid? UserId { get; set; }
    }
    /**@}*/
}