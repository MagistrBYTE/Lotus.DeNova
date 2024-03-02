using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
    *@{*/
    /// <summary>
    /// Класс для получения списка аспектов параметров персонажа с учетом фильтрации и сортировки.
    /// </summary>
    public class PersonParameterAspectsRequest : Request
    {
        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid? PersonId { get; set; }
    }
    /**@}*/
}