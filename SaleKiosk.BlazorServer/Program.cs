using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SaleKiosk.Application.Mappings;
using SaleKiosk.Application.Services;
using SaleKiosk.Application.Validators;
using SaleKiosk.BlazorServer.Data;
using SaleKiosk.Domain.Contracts;
using SaleKiosk.Infrastructure;
using SaleKiosk.Infrastructure.Repositories;
using SaleKiosk.SharedKernel.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

// rejestracja automappera w kontenerze IoC
builder.Services.AddAutoMapper(typeof(KioskMappingProfile));
// rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przez ModelState)
builder.Services.AddFluentValidationAutoValidation();
// rejestracja kontekstu bazy w kontenerze IoC
var sqliteConnectionString = "Data Source=SaleKiosk.db";
builder.Services.AddDbContext<KioskDbContext>(options =>
 options.UseSqlite(sqliteConnectionString));
// rejestracja walidatora
builder.Services.AddScoped<IValidator<CreateProductDto>, RegisterCreateProductDtoValidator>();
builder.Services.AddScoped<IKioskUnitOfWork, KioskUnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<DataSeeder>();
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// seeding data utwozry baze 
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}

app.Run();
