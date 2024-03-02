using System.ComponentModel.DataAnnotations;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaScenarioType Подсистема сценария
     * \ingroup DeNova
     * \brief Подсистема сценария.
     * @{
     */
    /// <summary>
    /// Класс для определения сценария игры.
    /// </summary>
    public class ScenarioType : EntityDb<int>, IComparable<ScenarioType>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "ScenarioType";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="ScenarioType"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<ScenarioType>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сеттинга.
        /// </summary>
        public int? GameSettingTypeId { get; set; }

        /// <summary>
        /// Название сценария.
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Название сценария для отображения.
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
        public int CompareTo(ScenarioType? other)
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