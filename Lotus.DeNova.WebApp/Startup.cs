//---------------------------------------------------------------------------------------------------------------------
using System.Reflection;
using Lotus.DeNova;
using Lotus.Web;
using Lotus.Account;
//---------------------------------------------------------------------------------------------------------------------
namespace Lotus.DeNova
{
	/// <summary>
	/// Базовый класс для запуска Web приложения
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Конфигурация
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="configuration">Конфигурация</param>
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		/// <summary>
		/// Конфигурация сервисов
		/// </summary>
		/// <param name="services">Коллекция сервисов</param>
		public void ConfigureServices(IServiceCollection services)
		{
			//
			// Базовые сервисы для работы
			//
			services.AddCors(x => x.AddDefaultPolicy(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowAnyOrigin()));
			services.AddOptions();
			services.AddHttpContextAccessor();

			//
			// Сервисы контролеров и сессии
			//
			services.AddControllers();
			services.AddDistributedMemoryCache();
			services.AddSession();

			//
			// Сервисы базы данных
			//
			services.AddLotusCommonServices();
			services.AddLotusAccountDatabaseServices(Configuration, XDbConstants.ConnectingDenovaDb, false);
			services.AddLotusDeNovaDatabaseServices(Configuration);

			//
			// Сервисы аутентификации и авторизации
			//

			services.AddLotusAccountServices();
			services.AddLotusAccountOpenIddictServices(null);
			services.AddLotusPermissionsExtension();
			services.AddAuthorizationCore();

			//
			// DeNova
			//
			services.AddLotusDeNovaServices();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
			});
		}

		/// <summary>
		/// Конфигурация конвейера обработки запроса
		/// </summary>
		/// <param name="app">Построитель Web приложения</param>
		/// <param name="env">Настройки окружения</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Configure the HTTP request pipeline.
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");

				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseSession();

			app.UseCors();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseWebSockets();

			app.InitLotusDeNovaDatabaseAsync().Wait();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
//---------------------------------------------------------------------------------------------------------------------