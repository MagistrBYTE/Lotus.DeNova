using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaRaceType
    *@{*/
    /// <summary>
    /// Класс расы.
    /// </summary>
    public class RaceTypeDto : IdentifierDtoId<int>
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Название расы.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Название расы для отображения.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        public string? AdditionalInfo { get; set; }
    }
    /**@}*/
}