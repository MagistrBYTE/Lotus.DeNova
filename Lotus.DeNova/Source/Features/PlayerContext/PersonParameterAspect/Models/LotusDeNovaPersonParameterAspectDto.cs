using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
    *@{*/
    /// <summary>
    /// Класс аспекта параметра персонажа.
    /// </summary>
    public class PersonParameterAspectDto : IdentifierDtoId<Guid>
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