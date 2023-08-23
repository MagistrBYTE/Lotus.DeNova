
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace Lotus.DeNova.Test
{
    /// <summary>
    /// Тесты для проверки создания новой игры
    /// </summary>
    public sealed class GameContextScenario : IClassFixture<DeNovaDefaultFactory>
    {
        private readonly DeNovaDefaultFactory _factory;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public GameContextScenario(DeNovaDefaultFactory factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Создания новой игры")]
        public async Task NewGame()
        {
			ILotusGameContextService gameContextService = _factory.ServiceProvider.GetRequiredService<ILotusGameContextService>();

			// Создаем игру
			var gameCreate = new GameContextCreateDto()
			{
				Name = "Новая игра 1",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id,
				UserId = DeNovaDefaultFactory.DefaultUser.Id,
			};

			var gameContext = await gameContextService.CreateAsync(gameCreate, CancellationToken.None);

			// Новая игра должна быть создана и должна быть текущей
			Assert.NotNull(gameContext.Payload);
			Assert.True(gameContext.Payload.IsCurrent);

			// Создаем игру
			var gameCreate2 = new GameContextCreateDto()
			{
				Name = "Новая игра 2",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id,
				UserId = DeNovaDefaultFactory.DefaultUser.Id,
			};

			// Новая игра должна быть создана и должна быть текущей
			var gameContext2 = await gameContextService.CreateAsync(gameCreate2, CancellationToken.None);
			Assert.NotNull(gameContext2.Payload);
			Assert.True(gameContext2.Payload.IsCurrent);

			// Предыдущая игра должна быть неактивной
			var gameContext3 = await gameContextService.GetAsync(gameContext.Payload.Id, CancellationToken.None);
			Assert.NotNull(gameContext3.Payload);
			Assert.False(gameContext3.Payload.IsCurrent);
		}

		[Fact(DisplayName = "Сохранение игры")]
		public async Task SaveGame()
		{
			ILotusGameContextService gameContextService = _factory.ServiceProvider.GetRequiredService<ILotusGameContextService>();

			//
			// Создаем игру
			//
			var gameCreate = new GameContextCreateDto()
			{
				Name = "Новая игра 1",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id,
				UserId = DeNovaDefaultFactory.DefaultUser.Id,
			};

			var gameContext = await gameContextService.CreateAsync(gameCreate, CancellationToken.None);

			//
			// Новая игра должна быть создана и должна быть текущей
			//
			Assert.NotNull(gameContext.Payload);
			Assert.True(gameContext.Payload.IsCurrent);

			//
			// Добавляем новые сведения о персонаже
			//
			ILotusIdentityInfoService identityInfoService = _factory.ServiceProvider.GetRequiredService<ILotusIdentityInfoService>();

			var identityInfoCreate = new IdentityInfoCreateDto()
			{
				GameContextId = gameContext.Payload.Id,
				PersonId = DeNovaDefaultFactory.DefaultPerson.Id,
				Name = "Иван",
				BeginPeriod = new DateTime(1900, 3, 2).ToUniversalTime(),
			};

			var identityInfo = await identityInfoService.CreateAsync(identityInfoCreate, CancellationToken.None);
			Assert.NotNull(identityInfo.Payload);
			Assert.Equal(identityInfoCreate.Name, identityInfo.Payload.Name);
			Assert.Equal(identityInfoCreate.GameContextId, identityInfo.Payload.GameContextId);
			Assert.Equal(identityInfoCreate.PersonId, identityInfo.Payload.PersonId);
			Assert.Equal(identityInfoCreate.BeginPeriod, identityInfo.Payload.BeginPeriod);

			//
			// Сохраняем игру
			//
			ILotusGameSaveService gameSaveService = _factory.ServiceProvider.GetRequiredService<ILotusGameSaveService>();
			var saveCreate = new GameSaveCreateDto()
			{
				GameContextId = gameContext.Payload.Id,
				Name = "test2",
			};
			var gameSave = await gameSaveService.SaveAsync(saveCreate, CancellationToken.None);
			Assert.NotNull(gameSave.Payload);
			Assert.Equal(saveCreate.Name, gameSave.Payload.Name);

			//
			// Добавляем еще одни сведения
			//
			var identityInfoCreate2 = new IdentityInfoCreateDto()
			{
				GameContextId = gameContext.Payload.Id,
				PersonId = DeNovaDefaultFactory.DefaultPerson.Id,
				Name = "Суриков",
				BeginPeriod = new DateTime(1952, 3, 2).ToUniversalTime(),
			};

			var identityInfo2 = await identityInfoService.CreateAsync(identityInfoCreate2, CancellationToken.None);
			Assert.NotNull(identityInfo2.Payload);
			Assert.Equal(identityInfoCreate2.Name, identityInfo2.Payload.Name);
			Assert.Equal(identityInfoCreate2.GameContextId, identityInfo2.Payload.GameContextId);
			Assert.Equal(identityInfoCreate2.PersonId, identityInfo2.Payload.PersonId);
			Assert.Equal(identityInfoCreate2.BeginPeriod, identityInfo2.Payload.BeginPeriod);

			//
			// Убеждаемся что у нас два сведения о персонаже
			//
			IdentityInfosDto identityInfoRequest = new IdentityInfosDto()
			{
				GameContextId = gameContext.Payload.Id,
				PersonId = DeNovaDefaultFactory.DefaultPerson.Id,
				PageInfo = new Repository.CPageInfoRequest()
				{
					PageNumber = 0,
					PageSize = 9999
				}
			};
			var identityInfos = await identityInfoService.GetAllAsync(identityInfoRequest, CancellationToken.None);
			Assert.NotNull(identityInfos.Payload);
			Assert.Equal(2, identityInfos.Payload.Count);

			//
			// Загружаем игру
			//
			GameLoadDto gameLoad = new GameLoadDto()
			{
				GameContextId = gameContext.Payload.Id,
				GameSaveId = gameSave.Payload.Id
			};
			await gameSaveService.LoadAsync(gameLoad, CancellationToken.None);

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