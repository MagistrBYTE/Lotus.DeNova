using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaScenarioType
    *@{*/
    /// <summary>
    /// Класс для получения списка сценариев с учетом фильтрации и сортировки.
    /// </summary>
    public class ScenarioTypesRequest : Request
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }
    }
    /**@}*/
}