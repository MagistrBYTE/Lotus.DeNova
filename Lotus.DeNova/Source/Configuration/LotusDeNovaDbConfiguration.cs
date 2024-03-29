using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaConfiguration Подсистема конфигурации и инициализации
     * \ingroup DeNova
     * \brief Подсистема конфигурации и инициализации.
     * @{
     */
    /// <summary>
    /// Статический класс для конфигурации и инициализации базы данных.
    /// </summary>
    public static class XDbConfiguration
    {
        /// <summary>
        /// Конфигурация и первоначальная инициализация базы данных.
        /// </summary>
        /// <remarks>
        /// Вызывается в <see cref="DeNovaDbContext.OnModelCreating(ModelBuilder)"/>.
        /// </remarks>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ConfigurationDenovaDatabase(ModelBuilder modelBuilder)
        {
            //
            // ТЕРРИТОРИАЛЬНО-АДРЕСНОЕ ХОЗЯЙСТВО
            //
            AddressElement.ModelCreating(modelBuilder);
            AddressStreet.ModelCreating(modelBuilder);
            AddressVillage.ModelCreating(modelBuilder);
            AddressVillageSettlement.ModelCreating(modelBuilder);

            //
            // ИГРОВЫЕ ТИПЫ
            //
            AstrologyType.ModelCreating(modelBuilder);
            GameSettingType.ModelCreating(modelBuilder);
            RaceType.ModelCreating(modelBuilder);
            ScenarioType.ModelCreating(modelBuilder);
            ParameterType.ModelCreating(modelBuilder);
            ParameterAspectType.ModelCreating(modelBuilder);


            Person.ModelCreating(modelBuilder);
            PersonParameter.ModelCreating(modelBuilder);
            PersonParameterAspect.ModelCreating(modelBuilder);

            //
            // ИГРОВОЙ КОНТЕКСТ
            //
            Game.ModelCreating(modelBuilder);
            GameSave.ModelCreating(modelBuilder);

            //
            // ДИНАМИЧЕСКИЕ ДАННЫЕ
            //
            BirthdayState.ModelCreating(modelBuilder);
            AddressState.ModelCreating(modelBuilder);
            AvatarState.ModelCreating(modelBuilder);
            IdentityState.ModelCreating(modelBuilder);
            PlacementState.ModelCreating(modelBuilder);

            // Первоначальная инициализация через миграцию
            XDbSeed.Create(modelBuilder);
        }
    }
    /**@}*/
}