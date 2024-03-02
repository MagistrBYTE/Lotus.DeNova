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
    /// Тип улицы.
    /// </summary>
    [TypeConverter(typeof(EnumToStringConverter<TAddressStreetType>))]
    public enum TAddressStreetType
    {
        /// <summary>
        /// Тип улицы отсутствует.
        /// </summary>
        [Description("Тип улицы отсутствует")]
        None = -1,

        /// <summary>
        /// Улица.
        /// </summary>
        [Description("Улица")]
        Street = 0,

        /// <summary>
        /// Переулок.
        /// </summary>
        [Description("Переулок")]
        Lane = 1,

        /// <summary>
        /// Микрорайон.
        /// </summary>
        [Description("Микрорайон")]
        Microdistrict = 2
    }

    /// <summary>
    /// Класс представляющий собой компонент адреса - элемент улицы в населённом пункте или местоположение.
    /// вне границ населённого пункта.
    /// </summary>
    [Serializable]
    public class AddressStreet : EntityDbNotifyProperty<int>, IComparable<AddressStreet>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AddressStreet";
        #endregion

        #region Static fields
        //
        // Константы для информирования об изменении свойств
        //
        protected static readonly PropertyChangedEventArgs PropertyArgsStreetType = new(nameof(StreetType));
        protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AddressStreet"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AddressStreet>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Fields
        // Основные параметры
        protected internal string _name = string.Empty;
        protected internal TAddressStreetType _streetType;
        #endregion

        #region Properties
        //
        // ОСНОВНЫЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Тип улицы.
        /// </summary>
        public TAddressStreetType StreetType
        {
            get { return (_streetType); }
            set
            {
                _streetType = value;
                NotifyPropertyChanged(PropertyArgsStreetType);
            }
        }

        /// <summary>
        /// Наименование.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthNameStreet)]
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
        /// Внешний ключ для населённого пункта.
        /// </summary>
        public int? VillageId { get; set; }

        /// <summary>
        /// Навигационное свойство населённого пункта.
        /// </summary>
        [ForeignKey(nameof(VillageId))]
        public AddressVillage? Village { get; set; }

        /// <summary>
        /// Список элементов.
        /// </summary>
        public List<AddressElement> Elements { get; set; } = new List<AddressElement>();
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию инициализирует объект класса предустановленными значениями.
        /// </summary>
        public AddressStreet()
        {
        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="name">Наименование улицы.</param>
        public AddressStreet(string name)
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
        public int CompareTo(AddressStreet? other)
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