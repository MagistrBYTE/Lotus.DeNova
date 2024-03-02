using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
    *@{*/
    /// <summary>
    /// Класс для получения списка параметров существ с учетом фильтрации и сортировки.
    /// </summary>
    public class ParameterTypesRequest : Request
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }
    }
    /**@}*/
}