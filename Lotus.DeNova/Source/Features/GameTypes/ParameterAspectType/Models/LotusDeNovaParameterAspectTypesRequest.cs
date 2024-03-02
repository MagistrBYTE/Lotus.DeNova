using Lotus.Repository;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
    *@{*/
    /// <summary>
    /// Класс для получения списка аспектов параметров существ с учетом фильтрации и сортировки.
    /// </summary>
    public class ParameterAspectTypesRequest : Request
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Идентификатор параметра.
        /// </summary>
        public int? ParameterTypeId { get; set; }
    }
    /**@}*/
}