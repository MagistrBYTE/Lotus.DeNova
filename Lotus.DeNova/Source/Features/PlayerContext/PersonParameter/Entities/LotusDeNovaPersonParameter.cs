using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaPersonParameter Подсистема параметров персонажа
     * \ingroup DeNova
     * \brief Подсистема параметров персонажа.
     * @{
     */
    /// <summary>
    /// Класс для определения параметра персонажа персонажа.
    /// </summary>
    [Serializable]
    public class PersonParameter : EntityDb<Guid>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "PersonParameter";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="PersonParameter"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<PersonParameter>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор типа параметра.
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Навигационное свойство для типа параметра.
        /// </summary>
        [ForeignKey(nameof(ParameterTypeId))]
        public virtual ParameterType ParameterType { get; set; } = default!;

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public float BaseValue { get; set; }

        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid? PersonId { get; set; }

        /// <summary>
        /// Навигационное свойство для персонажа.
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual Person? Person { get; set; } = default!;

        /// <summary>
        /// Аспекты развития параметра.
        /// </summary>
        public List<PersonParameterAspect> Aspects { get; set; } = new List<PersonParameterAspect>();
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует данные списка предустановленными данными.
        /// </summary>
        public PersonParameter()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными данными.
        /// </summary>
        /// <param name="parameterTypeId">Идентификатор типа параметра.</param>
        public PersonParameter(int parameterTypeId)
        {
            Id = Guid.NewGuid();
            ParameterTypeId = parameterTypeId;
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными данными.
        /// </summary>
        /// <param name="parameterTypeId">Идентификатор типа параметра.</param>
        /// <param name="personId">Идентификатор персонажа.</param>
        public PersonParameter(int parameterTypeId, Guid personId)
        {
            Id = Guid.NewGuid();
            ParameterTypeId = parameterTypeId;
            PersonId = personId;
        }
        #endregion

        #region System methods
        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            var name = XParameterTypeConstants.PersonParameters.First(x => x.Id == ParameterTypeId).DisplayName;
            return ($"{name} | {BaseValue}");
        }
        #endregion
    }
    /**@}*/
}