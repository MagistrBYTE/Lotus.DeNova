using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaAddress Подсистема адресного хозяйства
     * \ingroup DeNova
     * \brief Подсистема адресного хозяйства обеспечивает идентификацию объектов на основе адреса и местоположения.
     * @{
     */
    /// <summary>
    /// Тип адресуемого элемента.
    /// </summary>
    [TypeConverter(typeof(EnumToStringConverter<TAddressElementType>))]
    public enum TAddressElementType
    {
        /// <summary>
        /// Земельный участок.
        /// </summary>
        [Description("Земельный участок")]
        Landplot = 0,

        /// <summary>
        /// Объект капитального строительства.
        /// </summary>
        [Description("Объект капитального строительства")]
        Building = 1,

        /// <summary>
        /// Квартира.
        /// </summary>
        [Description("Квартира")]
        Apartment = 2
    }

    /// <summary>
    /// Класс для определения информации о структуре адреса или местоположении объекта.
    /// </summary>
    [Serializable]
    public class AddressElement : EntityDbNotifyProperty<int>, IComparable<AddressElement>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AddressElement";
        #endregion

        #region Static fields
        //
        // Константы для информирования об изменении свойств
        //
        protected static readonly PropertyChangedEventArgs PropertyArgsElementType = new(nameof(ElementType));
        protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
        protected static readonly PropertyChangedEventArgs PropertyArgsNumber = new(nameof(Number));
        protected static readonly PropertyChangedEventArgs PropertyArgsCadastralNumber = new(nameof(CadastralNumber));
        protected static readonly PropertyChangedEventArgs PropertyArgsCode = new(nameof(Code));
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AddressElement"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AddressElement>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Fields
        // Основные параметры
        protected internal TAddressElementType _elementType;
        protected internal string _name = string.Empty;
        protected internal string _number = string.Empty;
        protected internal string? _cadastralNumber;
        protected internal string? _code;
        #endregion

        #region Properties
        //
        // ОСНОВНЫЕ ПАРАМЕТРЫ
        //
        /// <summary>
        /// Тип адресуемого элемента.
        /// </summary>
        public TAddressElementType ElementType
        {
            get { return (_elementType); }
            set
            {
                _elementType = value;
                NotifyPropertyChanged(PropertyArgsElementType);
            }
        }

        /// <summary>
        /// Наименование адресуемого элемента.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthNameElement)]
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
        /// Номер адресуемого элемента.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthNumber)]
        public string Number
        {
            get { return (_number); }
            set
            {
                _number = value;
                NotifyPropertyChanged(PropertyArgsNumber);
            }
        }

        /// <summary>
        /// Кадастровый номер.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthCadastralNumber)]
        public string? CadastralNumber
        {
            get { return (_cadastralNumber); }
            set
            {
                _cadastralNumber = value;
                NotifyPropertyChanged(PropertyArgsCadastralNumber);
            }
        }

        /// <summary>
        /// Уникальный номер адреса.
        /// </summary>
        [MaxLength(XAddressConstantsDb.LengthCadastralNumber)]
        public string? Code
        {
            get { return (_code); }
            set
            {
                _code = value;
                NotifyPropertyChanged(PropertyArgsCode);
            }
        }

        /// <summary>
        /// Внешний ключ для улицы.
        /// </summary>
        public int? StreetId { get; set; }

        /// <summary>
        /// Навигационное свойство для улицы.
        /// </summary>
        [ForeignKey(nameof(StreetId))]
        public AddressStreet? Street { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию инициализирует объект класса предустановленными значениями.
        /// </summary>
        public AddressElement()
        {

        }

        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="number">Номер адресуемого элемента.</param>
        public AddressElement(string number)
        {
            _number = number;
        }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(AddressElement? other)
        {
            if (other == null) return 0;

            var result = _name.CompareTo(other.Name);
            if (result == 0)
            {
                return (_number.CompareTo(other.Number));
            }

            return result;
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