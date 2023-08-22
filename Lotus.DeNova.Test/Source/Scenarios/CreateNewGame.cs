
using Microsoft.Extensions.Logging;

namespace Lotus.DeNova.Test
{
    /// <summary>
    /// Тесты для проверки создания новой игры
    /// </summary>
    public sealed class CreateNewGame : IClassFixture<DeNovaDefaultFactory>
    {
        private readonly DeNovaDefaultFactory _factory;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CreateNewGame(DeNovaDefaultFactory factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Создания новой игры")]
        public async Task Processed()
        {

        }
    }
}