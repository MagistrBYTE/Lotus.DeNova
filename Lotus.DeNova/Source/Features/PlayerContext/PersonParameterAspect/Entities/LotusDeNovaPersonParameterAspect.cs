using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPersonParameter
    *@{*/
    /// <summary>
    /// Класс для определения аспекта параметра персонажа.
    /// </summary>
    [Serializable]
    public class PersonParameterAspect : EntityDb<Guid>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "PersonParameterAspect";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="PersonParameterAspect"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<PersonParameterAspect>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор типа аспекта параметра.
        /// </summary>
        public int ParameterAspectTypeId { get; set; }

        /// <summary>
        /// Навигационное свойство для типа аспекта параметра.
        /// </summary>
        [ForeignKey(nameof(ParameterAspectTypeId))]
        public virtual ParameterAspectType ParameterAspectType { get; set; } = default!;

        /// <summary>
        /// Идентификатор параметра персонажа кторому принадлежит данный аспект.
        /// </summary>
        public Guid PersonParameterId { get; set; }

        /// <summary>
        /// Навигационное свойство для параметра персонажа кторому принадлежит данный аспект.
        /// </summary>
        public virtual PersonParameter PersonParameter { get; set; } = default!;

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Навигационное свойство для персонажа.
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; } = default!;
        #endregion

        #region System methods
        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (Value.ToString());
        }
        #endregion
    }
    /**@}*/
}