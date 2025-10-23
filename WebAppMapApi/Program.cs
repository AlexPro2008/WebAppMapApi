using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebAppMapApi.Models;

// построение приложения
var builder = WebApplication.CreateBuilder(args);

// добавление функционала MVC
builder.Services.AddControllersWithViews();

// здесь используем Scoped-сервис он работает в рамках одного запроса
// и при каждом новом запросе создается новый экземпляр класса

builder.Services.AddScoped<MapFactory>();
/*
// регистрация сервисов
// регистрация репозитория для работы с запросамм
builder.Services.AddScoped<IQueryRepository, QueryRepository>();

// регистрация репозитория для работы с отчетами
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// регистрация репозитория для работы с сущностями
builder.Services.AddScoped<IGetEntityRepository, GetEntityRepository>();

builder.Services.AddScoped<CheckEntity>();

// для абстрагированного добавление обновления и удаления
builder.Services.AddScoped<IRepository, Repository>();
*/
// регистрация фильтра для обработки исключениями контроллера
builder.Services.AddControllers(op =>
{
    var filters = op.Filters;

});
// отключаем чтобы сервер мог посылать нормальный массив ошибок 
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});


// соединиие с БД
var connection = builder
    .Configuration
    .GetConnectionString("DbConnection");
builder
    .Services
    .AddDbContext<MapFactory>(options => options
        // подключение lazy loading, сначала установить
        // NuGet-пакет Microsoft.EntityFrameworkCore.Proxies
        .UseLazyLoadingProxies()
        // используем MySql 
        .UseMySQL(connection!)
    ); 



// ссылка на build
var app = builder.Build();



// добавление сервиса CORS (Cross Origin Resource Sharing)
// для разрешения запросов к серверу от других доменов
// т.е. от клиентских приложений, созданных в других проектах
builder.Services.AddCors();



// настройка CORS - разрешаем обрабатывать все источники запросов
// и все виды REST-запросов
app.UseCors(builder => builder.AllowAnyOrigin()
.AllowAnyMethod().AllowAnyHeader());


// используем для поставки поток файлов к стороне клиента
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")),
    RequestPath = "/images"
});

// разрешение работы маршрутизации
app.UseRouting();
// добавляем для аутентификация и авторизации
app.MapControllers();
app.Run();