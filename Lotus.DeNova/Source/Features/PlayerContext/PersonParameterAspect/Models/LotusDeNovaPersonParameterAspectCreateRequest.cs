namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
    *@{*/
    /// <summary>
    /// Класс для создания новой аспекта параметра персонажа.
    /// </summary>
    public class PersonParameterAspectCreateRequest
    {
        /// <summary>
        /// Идентификатор типа аспекта параметра.
        /// </summary>
        public int ParameterAspectTypeId { get; set; }

        /// <summary>
        /// Идентификатор параметра персонажа кторому принадлежит данный аспект.
        /// </summary>
        public Guid PersonParameterId { get; set; }

        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid PersonId { get; set; }
    }
    /**@}*/
}