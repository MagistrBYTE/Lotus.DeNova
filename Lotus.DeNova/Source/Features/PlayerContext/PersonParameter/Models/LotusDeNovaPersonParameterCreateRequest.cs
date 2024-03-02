namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
    *@{*/
    /// <summary>
    /// Класс для создания нового параметра персонажа.
    /// </summary>
    public class PersonParameterCreateRequest
    {
        /// <summary>
        /// Идентификатор типа параметра.
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public float BaseValue { get; set; }

        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid PersonId { get; set; }
    }
    /**@}*/
}