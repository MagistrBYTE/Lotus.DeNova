using System.ComponentModel.DataAnnotations;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaAstrologyType Подсистема данных астрологии
     * \ingroup DeNova
     * \brief Подсистема данных астрологии.
     * @{
     */
    /// <summary>
    /// Класс для определения данных по астрологии персонажа.
    /// </summary>
    public class AstrologyType : EntityDb<int>, IComparable<AstrologyType>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AstrologyType";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AstrologyType"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AstrologyType>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Знак зодиака.
        /// </summary>
        [MaxLength(20)]
        public string? ZodiacSign { get; set; }

        /// <summary>
        /// Камень по знаку зодиака.
        /// </summary>
        [MaxLength(20)]
        public string? StoneZodiac { get; set; }

        /// <summary>
        /// Дерево по знаку зодиака.
        /// </summary>
        [MaxLength(20)]
        public string? TreeZodiac { get; set; }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(AstrologyType? other)
        {
            if (other == null) return 0;

            if (ZodiacSign is not null)
            {
                return (ZodiacSign.CompareTo(other.ZodiacSign));
            }

            return 0;
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (ZodiacSign ?? string.Empty);
        }
        #endregion
    }
    /**@}*/
}