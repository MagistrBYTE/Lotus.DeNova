using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaAddress
	*@{*/
    /// <summary>
    /// Тип населенного пункта.
    /// </summary>
    [TypeConverter(typeof(EnumToStringConverter<TAddressVillageType>))]
    public enum TAddressVillageType
    {
        /// <summary>
        /// Город.
        /// </summary>
        [Description("Город")]
        Town = 0,

        /// <summary>
        /// Поселок.
        /// </summary>
        [Description("Поселок")]
        Township = 1,

        /// <summary>
        /// Село.
        /// </summary>
        [Description("Село")]
        Village = 2,

        /// <summary>
        /// Железнодорожный разъезд.
        /// </summary>
        [Description("Железнодорожный разъезд")]
        RailwaySiding = 24
    }

    /// <summary>
    /// Класс представляющий собой компонент адреса - населённый пункт.
    /// </summary>
    [Serializable]
    public class AddressVillage : EntityDbNotifyProperty<int>, IComparable<AddressVillage>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AddressVillage";
        #endregion

        #region Static fields
        //
        // Константы для информирования об изменении свойств
        //
        protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
        protected static readonly PropertyChangedEventArgs PropertyArgsVillageType = new(nameof(VillageType));
        protected static readonly PropertyChangedEventArgs PropertyArgsOKTMO = new(nameof(OKTMO));
        protected static readonly PropertyChangedEventArgs PropertyArgsOKATO = new(nameof(OKATO));
        protected static readonly PropertyChangedEventArgs PropertyArgsPostalCode = new(nameof(PostalCode));
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AddressVillage"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AddressVillage>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Fields
        // Основные параметры
        protected internal string _name = string.Empty;
        protected internal TAddressVillageType _villageType;
        protected internal string? _OKTMO;
        protected internal string? _OKATO;
        protected internal string? _postalCode;
        #endregion

        #region Properties
        //
        // ОСНОВНЫЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Наименование населённого пункта.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthNameVillage)]
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
        /// Тип населённого пункта.
        /// </summary>
        public TAddressVillageType VillageType
        {
            get { return (_villageType); }
            set
            {
                _villageType = value;
                NotifyPropertyChanged(PropertyArgsVillageType);
            }
        }

        /// <summary>
        /// Код ОКТМО.
        /// </summary>
        [MaxLength(10)]
        public string? OKTMO
        {
            get { return (_OKTMO); }
            set
            {
                _OKTMO = value;
                NotifyPropertyChanged(PropertyArgsOKTMO);
            }
        }

        /// <summary>
        /// Код ОКАТО.
        /// </summary>
        [MaxLength(10)]
        public string? OKATO
        {
            get { return (_OKATO); }
            set
            {
                _OKATO = value;
                NotifyPropertyChanged(PropertyArgsOKATO);
            }
        }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        [MaxLength(10)]
        public string? PostalCode
        {
            get { return (_postalCode); }
            set
            {
                _postalCode = value;
                NotifyPropertyChanged(PropertyArgsPostalCode);
            }
        }

        /// <summary>
        /// Внешний ключ для сельского поселения.
        /// </summary>
        public int? VillageSettlementId { get; set; }

        /// <summary>
        /// Навигационное свойство сельского поселения.
        /// </summary>
        [ForeignKey(nameof(VillageSettlementId))]
        public AddressVillageSettlement? VillageSettlement { get; set; }

        /// <summary>
        /// Список улиц.
        /// </summary>
        public List<AddressStreet> Streets { get; set; } = new List<AddressStreet>();
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию инициализирует объект класса предустановленными значениями.
        /// </summary>
        public AddressVillage()
        {
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="name">Наименование населённого пункта.</param>
        public AddressVillage(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="village_settlement_id">Внешний ключ для сельского поселения.</param>
        /// <param name="name">Наименование населённого пункта.</param>
        public AddressVillage(int village_settlement_id, string name)
        {
            _name = name;
            VillageSettlementId = village_settlement_id;
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="village_settlement_id">Внешний ключ для сельского поселения.</param>
        /// <param name="id">Индекс(ключ) населённого пункта.</param>
        /// <param name="name">Наименование населённого пункта.</param>
        public AddressVillage(int village_settlement_id, int id, string name)
        {
            _name = name;
            VillageSettlementId = village_settlement_id;
            Id = id;
        }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(AddressVillage? other)
        {
            if (other == null) return 0;
            return (Name.CompareTo(other.Name));
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