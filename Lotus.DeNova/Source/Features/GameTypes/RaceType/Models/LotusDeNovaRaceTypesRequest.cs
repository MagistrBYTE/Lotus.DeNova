using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaRaceType
    *@{*/
    /// <summary>
    /// Класс для получения списка рас с учетом фильтрации и сортировки.
    /// </summary>
    public class RaceTypesRequest : Request
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }
    }
    /**@}*/
}