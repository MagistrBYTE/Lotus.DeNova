using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
    *@{*/
    /// <summary>
    /// Класс для получения списка персонажей с учетом фильтрации и сортировки.
    /// </summary>
    public class PersonsRequest : Request
    {
        /// <summary>
        /// Идентификатор игрока.
        /// </summary>
        public Guid? UserId { get; set; }
    }
    /**@}*/
}