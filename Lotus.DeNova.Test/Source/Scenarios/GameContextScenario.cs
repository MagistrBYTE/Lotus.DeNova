using Microsoft.Extensions.DependencyInjection;

namespace Lotus.DeNova.Test
{
    /// <summary>
    /// Тесты для проверки создания новой игры.
    /// </summary>
    public sealed class GameContextScenario : IClassFixture<DeNovaDefaultFactory>
    {
        private readonly DeNovaDefaultFactory _factory;
        private PersonDto _testPerson;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public GameContextScenario(DeNovaDefaultFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Создание тестового персонажа.
        /// </summary>
        /// <returns></returns>
        private async Task<PersonDto> CreateTestPerson()
        {
            var personService = _factory.ServiceProvider.GetRequiredService<ILotusPersonService>();

            var personCreate = new PersonCreateRequest()
            {
                UserId = DeNovaDefaultFactory.DefaultUser.Id,
                Name = "Тестовый персонажа",
                RaceTypeId = XRaceTypeConstants.Tribe.Id
            };
            var _testPersonResponce = await personService.CreateAsync(personCreate, CancellationToken.None);
            Assert.NotNull(_testPersonResponce.Payload);

            var person = _testPersonResponce.Payload;
            Assert.Equal(personCreate.Name, person.Name);

            return person;
        }

        [Fact(DisplayName = "Создания персонажа")]
        public async Task CreatePerson()
        {
            _testPerson = await CreateTestPerson();
        }

        [Fact(DisplayName = "Создания новой игры")]
        public async Task NewGame()
        {
            var gameService = _factory.ServiceProvider.GetRequiredService<ILotusGameService>();

            // Создаем игру
            var gameCreate = new GameCreateRequest()
            {
                UserId = DeNovaDefaultFactory.DefaultUser.Id,
                ScenarioId = XScenarioTypeConstants.Sandbox.Id
            };

            var gameContext = await gameService.CreateAsync(gameCreate, CancellationToken.None);

            // Новая игра должна быть создана и должна быть текущей
            Assert.NotNull(gameContext.Payload);
            Assert.True(gameContext.Payload.IsCurrent);

            // Создаем игру
            var gameCreate2 = new GameCreateRequest()
            {
                UserId = DeNovaDefaultFactory.DefaultUser.Id,
                ScenarioId = XScenarioTypeConstants.Sandbox.Id
            };

            // Новая игра должна быть создана и должна быть текущей
            var gameContext2 = await gameService.CreateAsync(gameCreate2, CancellationToken.None);
            Assert.NotNull(gameContext2.Payload);
            Assert.True(gameContext2.Payload.IsCurrent);

            // Предыдущая игра должна быть неактивной
            var gameContext3 = await gameService.GetAsync(gameContext.Payload.Id, CancellationToken.None);
            Assert.NotNull(gameContext3.Payload);
            Assert.False(gameContext3.Payload.IsCurrent);
        }

        [Fact(DisplayName = "Сохранение игры")]
        public async Task SaveGame()
        {
            var gameService = _factory.ServiceProvider.GetRequiredService<ILotusGameService>();

            //
            // Создаем игру
            //
            var gameCreate = new GameCreateRequest()
            {
                UserId = DeNovaDefaultFactory.DefaultUser.Id,
                ScenarioId = XScenarioTypeConstants.Sandbox.Id
            };

            var gameContext = await gameService.CreateAsync(gameCreate, CancellationToken.None);

            //
            // Новая игра должна быть создана и должна быть текущей
            //
            Assert.NotNull(gameContext.Payload);
            Assert.True(gameContext.Payload.IsCurrent);

            //
            // Создаем персонажа
            //
            _testPerson ??= await CreateTestPerson();

            //
            // Добавляем новые сведения о персонаже
            //
            var identityInfoService = _factory.ServiceProvider.GetRequiredService<ILotusIdentityStateService>();

            var identityInfoCreate = new IdentityStateCreateRequest()
            {
                GameId = gameContext.Payload.Id,
                PersonId = _testPerson.Id,
                Name = "Иван",
                BeginPeriod = new DateTime(1900, 3, 2, 0, 0, 0, DateTimeKind.Utc).ToUniversalTime(),
            };

            var identityInfo = await identityInfoService.CreateAsync(identityInfoCreate, CancellationToken.None);
            Assert.NotNull(identityInfo.Payload);
            Assert.Equal(identityInfoCreate.Name, identityInfo.Payload.Name);
            Assert.Equal(identityInfoCreate.GameId, identityInfo.Payload.GameId);
            Assert.Equal(identityInfoCreate.PersonId, identityInfo.Payload.PersonId);
            Assert.Equal(identityInfoCreate.BeginPeriod, identityInfo.Payload.BeginPeriod);

            //
            // Сохраняем игру
            //
            var saveCreate = new GameSaveCreateRequest()
            {
                GameId = gameContext.Payload.Id,
                Name = "test2",
            };
            var gameSave = await gameService.SaveAsync(saveCreate, CancellationToken.None);
            Assert.NotNull(gameSave.Payload);
            Assert.Equal(saveCreate.Name, gameSave.Payload.Name);

            //
            // Добавляем еще одни сведения
            //
            var identityInfoCreate2 = new IdentityStateCreateRequest()
            {
                GameId = gameContext.Payload.Id,
                PersonId = _testPerson.Id,
                Name = "Суриков",
                BeginPeriod = new DateTime(1952, 3, 2, 0, 0, 0, DateTimeKind.Utc).ToUniversalTime(),
            };

            var identityInfo2 = await identityInfoService.CreateAsync(identityInfoCreate2, CancellationToken.None);
            Assert.NotNull(identityInfo2.Payload);
            Assert.Equal(identityInfoCreate2.Name, identityInfo2.Payload.Name);
            Assert.Equal(identityInfoCreate2.GameId, identityInfo2.Payload.GameId);
            Assert.Equal(identityInfoCreate2.PersonId, identityInfo2.Payload.PersonId);
            Assert.Equal(identityInfoCreate2.BeginPeriod, identityInfo2.Payload.BeginPeriod);

            //
            // Убеждаемся что у нас два сведения о персонаже
            //
            var identityInfoRequest = new IdentityStatesDto()
            {
                GameId = gameContext.Payload.Id,
                PersonId = _testPerson.Id,
            };
            var identityInfos = await identityInfoService.GetAllAsync(identityInfoRequest, CancellationToken.None);
            Assert.NotNull(identityInfos.Payload);
            Assert.Equal(2, identityInfos.Payload.Count);

            //
            // Загружаем игру
            //
            var gameLoad = new GameLoadRequest()
            {
                GameId = gameContext.Payload.Id,
                GameSaveId = gameSave.Payload.Id
            };
            await gameService.LoadAsync(gameLoad, CancellationToken.None);

            //
            // Проверяем, должны быть одни сведения
            //
            var identityInfos2 = await identityInfoService.GetAllAsync(identityInfoRequest, CancellationToken.None);
            Assert.NotNull(identityInfos.Payload);
            Assert.Single(identityInfos2.Payload);
            Assert.Equal(identityInfoCreate.Name, identityInfos2.Payload.First().Name);
        }
    }
}