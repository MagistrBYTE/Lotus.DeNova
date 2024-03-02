using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
    *@{*/
    /// <summary>
    /// Класс для определения аспекта параметра существа.
    /// </summary>
    [Serializable]
    public class ParameterAspectType : EntityDb<int>, IComparable<ParameterAspectType>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "ParameterAspectType";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="ParameterAspectType"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<ParameterAspectType>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сеттинга игры.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Идентификатор параметра.
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Навигационное свойство для параметра.
        /// </summary>
        [ForeignKey(nameof(ParameterTypeId))]
        public virtual ParameterType ParameterType { get; set; } = null!;

        /// <summary>
        /// Название аспекта параметра.
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Название аспекта параметра для отображения.
        /// </summary>
        [MaxLength(40)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        [MaxLength(256)]
        public string? AdditionalInfo { get; set; }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(ParameterAspectType? other)
        {
            if (other == null) return 0;

            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (DisplayName ?? Name);
        }
        #endregion
    }
    /**@}*/
}