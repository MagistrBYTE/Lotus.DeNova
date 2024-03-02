namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAstrologyType
    *@{*/
    /// <summary>
    /// Класс для создания новых данных по астрологии.
    /// </summary>
    public class AstrologyTypeCreateRequest
    {
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Знак зодиака.
        /// </summary>
        public string? ZodiacSign { get; set; }

        /// <summary>
        /// Камень по знаку зодиака.
        /// </summary>
        public string? StoneZodiac { get; set; }

        /// <summary>
        /// Дерево по знаку зодиака.
        /// </summary>
        public string? TreeZodiac { get; set; }
    }
    /**@}*/
}