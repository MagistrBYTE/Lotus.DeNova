using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaScenarioType
    *@{*/
    /// <summary>
    /// Класс сценария.
    /// </summary>
    public class ScenarioTypeDto : IdentifierDtoId<int>
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Название сценария.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Название сценария для отображения.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        public string? AdditionalInfo { get; set; }
    }
    /**@}*/
}