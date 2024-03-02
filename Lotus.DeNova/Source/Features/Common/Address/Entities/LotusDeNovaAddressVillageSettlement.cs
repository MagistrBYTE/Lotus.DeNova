using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddress
	*@{*/
    /// <summary>
    /// Класс представляющий собой компонент адреса - сельское поселение.
    /// </summary>
    [Serializable]
    public class AddressVillageSettlement : EntityDbNotifyProperty<int>, IComparable<AddressVillageSettlement>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AddressVillageSettlement";
        #endregion

        #region Static fields
        //
        // Константы для информирования об изменении свойств
        //
        protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
        protected static readonly PropertyChangedEventArgs PropertyArgsShortName = new(nameof(ShortName));
        protected static readonly PropertyChangedEventArgs PropertyArgsVillageSettlementType = new(nameof(VillageSettlementType));
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AddressVillageSettlement"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AddressVillageSettlement>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Fields
        // Основные параметры
        protected internal string _name;
        protected internal string? _shortName;
        protected internal string? _villageSettlementType;
        #endregion

        #region Properties
        //
        // ОСНОВНЫЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Наименование сельского поселения.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthNameVillageSettlement)]
        public string Name
        {
            get { return (_name); }
            set
            {
                _name = value;
                NotifyPropertyChanged(PropertyArgsName);
            }
        }

        /// <summary>
        /// Краткое наименование.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthShortName)]
        public string? ShortName
        {
            get { return (_shortName); }
            set
            {
                _shortName = value;
                NotifyPropertyChanged(PropertyArgsShortName);
            }
        }

        /// <summary>
        /// Тип сельского поселения.
        /// </summary>
        public string? VillageSettlementType
        {
            get { return (_villageSettlementType); }
            set
            {
                _villageSettlementType = value;
                NotifyPropertyChanged(PropertyArgsVillageSettlementType);
            }
        }

        /// <summary>
        /// Список населённых пунктов.
        /// </summary>
        public List<AddressVillage> Villages { get; set; } = new List<AddressVillage>();
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию инициализирует объект класса предустановленными значениями.
        /// </summary>
        public AddressVillageSettlement()
        {
            _name = string.Empty;
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="name">Наименование сельского поселения.</param>
        public AddressVillageSettlement(string name)
        {
            _name = name;
        }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(AddressVillageSettlement? other)
        {
            if (other == null) return 0;
            return (Name.CompareTo(other));
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (_name);
        }
        #endregion
    }
    /**@}*/
}