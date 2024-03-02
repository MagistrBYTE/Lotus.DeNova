using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
    *@{*/
    /// <summary>
    /// Класс для получения списка параметров персонажа с учетом фильтрации и сортировки.
    /// </summary>
    public class PersonParametersRequest : Request
    {
        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid? PersonId { get; set; }
    }
    /**@}*/
}