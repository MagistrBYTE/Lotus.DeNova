#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaPlacementState Подсистема перемещения персонажа
     * \ingroup DeNova
     * \brief Подсистема перемещения персонажа.
     * @{
     */
    /// <summary>
    /// Класс для определения состояния местоположения персонажа.
    /// </summary>
    public class PlacementState : PersonState, IComparable<PlacementState>, ILotusDuplicate<PlacementState>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "PlacementState";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="PlacementState"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<PlacementState>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid PlacementStateId { get; set; }

        /// <summary>
        /// Позиция персонажа по X.
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Позиция персонажа по Y.
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Позиция персонажа по Z.
        /// </summary>
        public int PositionZ { get; set; }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(PlacementState? other)
        {
            if (other == null) return 0;
            return (0);
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return ($"X:{PositionX}; Y:{PositionY}; Z:{PositionZ}");
        }
        #endregion

        #region ILotusDuplicate methods
        /// <summary>
        /// Получение дубликата объекта.
        /// </summary>
        /// <param name="parameters">Параметры дублирования объекта.</param>
        /// <returns>Дубликат объекта.</returns>
        public PlacementState Duplicate(CParameters? parameters = null)
        {
            var entityCopy = new PlacementState()
            {
                PlacementStateId = PlacementStateId,
                GameId = GameId,
                PersonId = PersonId,
                PositionX = PositionX,
                PositionY = PositionY,
                PositionZ = PositionZ,
            };

            return entityCopy;
        }
        #endregion
    }
    /**@}*/
}