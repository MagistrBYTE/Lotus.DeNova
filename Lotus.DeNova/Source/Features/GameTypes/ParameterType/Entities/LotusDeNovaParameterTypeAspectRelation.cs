#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaCreatureParameter
    *@{*/
    /// <summary>
    /// Класс для связывания параметра и его аспекта.
    /// </summary>
    public class ParameterTypeAspectRelation : EntityDb<int>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "ParameterTypeAspectRelation";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="ParameterTypeAspectRelation"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<ParameterTypeAspectRelation>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор типа параметра.
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Идентификатор типа аспекта параметра.
        /// </summary>
        public int ParameterAspectTypeId { get; set; }
        #endregion
    }
    /**@}*/
}