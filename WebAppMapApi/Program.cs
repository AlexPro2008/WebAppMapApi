using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebAppMapApi.Models;

// ���������� ����������
var builder = WebApplication.CreateBuilder(args);

// ���������� ����������� MVC
builder.Services.AddControllersWithViews();

// ����� ���������� Scoped-������ �� �������� � ������ ������ �������
// � ��� ������ ����� ������� ��������� ����� ��������� ������

builder.Services.AddScoped<MapFactory>();
/*
// ����������� ��������
// ����������� ����������� ��� ������ � ���������
builder.Services.AddScoped<IQueryRepository, QueryRepository>();

// ����������� ����������� ��� ������ � ��������
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// ����������� ����������� ��� ������ � ����������
builder.Services.AddScoped<IGetEntityRepository, GetEntityRepository>();

builder.Services.AddScoped<CheckEntity>();

// ��� ����������������� ���������� ���������� � ��������
builder.Services.AddScoped<IRepository, Repository>();
*/
// ����������� ������� ��� ��������� ������������ �����������
// builder.Services.AddControllers(op =>
// {
//     var filters = op.Filters;

// });
// ��������� ����� ������ ��� �������� ���������� ������ ������
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});


// ��������� � ��
var connection = builder
    .Configuration
    .GetConnectionString("DbConnection");
builder
    .Services
    .AddDbContext<MapFactory>(options => options
        // ����������� lazy loading, ������� ����������
        // NuGet-����� Microsoft.EntityFrameworkCore.Proxies
        .UseLazyLoadingProxies()
        // ���������� MySql
        .UseMySql(connection!, new MySqlServerVersion(new Version(8, 0, 33)), b => b.UseNetTopologySuite())
    );



// ������ �� build
var app = builder.Build();



// ���������� ������� CORS (Cross Origin Resource Sharing)
// ��� ���������� �������� � ������� �� ������ �������
// �.�. �� ���������� ����������, ��������� � ������ ��������
builder.Services.AddCors();



// ��������� CORS - ��������� ������������ ��� ��������� ��������
// � ��� ���� REST-��������
app.UseCors(builder => builder.AllowAnyOrigin()
.AllowAnyMethod().AllowAnyHeader());


// ���������� ��� �������� ����� ������ � ������� �������
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")),
    RequestPath = "/images"
});

// ���������� ������ �������������
app.UseRouting();
// ��������� ��� �������������� � �����������
app.MapControllers();
await app.RunAsync();