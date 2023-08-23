//---------------------------------------------------------------------------------------------------------------------
namespace Lotus.DeNova
{
	/// <summary>
	/// Основной класс программы
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Точка входа в приложение
		/// </summary>
		/// <param name="args">Аргументы</param>
		public static void Main(String[] args)
		{
			var host = CreateHostBuilder(args).Build();

			host.Run();
		}

		/// <summary>
		/// Создание и конфигурация построителя web-приложения
		/// </summary>
		/// <param name="args">Аргументы</param>
		/// <returns>Построитель web-приложения</returns>
		private static IHostBuilder CreateHostBuilder(String[] args)
		{
			var hostBuilder = Host.CreateDefaultBuilder(args);


			hostBuilder.ConfigureAppConfiguration((ctx, builder) =>
				{
					if (ctx.HostingEnvironment.IsDevelopment())
					{
						builder.AddUserSecrets<Startup>();
					}
					else
					{
						var configPath = Environment.GetEnvironmentVariable("SECRETS_PATH");
						if (!string.IsNullOrEmpty(configPath))
						{
							builder.AddJsonFile(Path.Combine(configPath, "appsettings.secrets.json"));
						}
					}
				});

			hostBuilder.ConfigureWebHostDefaults((webBuilder) =>
				{
					webBuilder.UseStartup<Startup>();
					webBuilder.ConfigureKestrel(
						(context, options) =>
						{
							// var maxRequestSize = context.Configuration.GetSection("MaxRequestSize").Get<int>();
							// options.Limits.MaxRequestBodySize = maxRequestSize;
						});
				});

			return hostBuilder;
		}
	}
}
//---------------------------------------------------------------------------------------------------------------------