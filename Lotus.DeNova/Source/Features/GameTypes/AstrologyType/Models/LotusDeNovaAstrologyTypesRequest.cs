using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAstrologyType
    *@{*/
    /// <summary>
    /// Класс для получения списка данных по астрологии с учетом фильтрации и сортировки.
    /// </summary>
    public class AstrologyTypesRequest : Request
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }
    }
    /**@}*/
}