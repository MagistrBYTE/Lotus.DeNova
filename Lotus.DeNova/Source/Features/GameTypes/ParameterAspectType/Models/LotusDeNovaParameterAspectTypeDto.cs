using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
    *@{*/
    /// <summary>
    /// Класс для определения аспекта параметра существа.
    /// </summary>
    public class ParameterAspectTypeDto : IdentifierDtoId<int>
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Идентификатор параметра.
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Название аспекта параметра.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Название аспекта параметра для отображения.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        public string? AdditionalInfo { get; set; }
    }
    /**@}*/
}