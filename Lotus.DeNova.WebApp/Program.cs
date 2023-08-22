//---------------------------------------------------------------------------------------------------------------------
using System.Reflection;
using Lotus.DeNova;
using Lotus.Web;
using Lotus.Account;
//---------------------------------------------------------------------------------------------------------------------

var builder = WebApplication.CreateBuilder(args);

//
// ������� ������� ��� ������
//
builder.Services.AddCors(x => x.AddDefaultPolicy(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()));
builder.Services.AddOptions();
builder.Services.AddHttpContextAccessor();

//
// ������� ����������� � ������
//
builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

//
// ������� ���� ������
//
builder.Services.AddLotusCommonServices();
builder.Services.AddLotusAccountDatabaseServices(builder.Configuration, Lotus.DeNova.XDbConstants.ConnectingDenovaDb, false);
builder.Services.AddLotusDeNovaDatabaseServices(builder.Configuration);

//
// ������� �������������� � �����������
//

builder.Services.AddLotusAccountServices();
builder.Services.AddLotusAccountOpenIddictServices(null);
builder.Services.AddLotusPermissionsExtension();
builder.Services.AddAuthorizationCore();

//
// DeNova
//
builder.Services.AddLotusDeNovaServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//---------------------------------------------------------------------------------------------------------------------
//
// ������������ ��������� ��������� �������
//
//---------------------------------------------------------------------------------------------------------------------
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

await app.InitLotusDeNovaDatabase();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();

/// <summary>
/// ��� ������������
/// </summary>
public partial class Program { }