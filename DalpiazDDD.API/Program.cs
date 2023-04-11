using Autofac;
using Autofac.Extensions.DependencyInjection;
using DalpiazDDD.Infrastructure.CrossCutting.IOC;
using DalpiazDDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
//var connection = builder.Configuration["SqlConnection:SqlConnectionString"];
var connection = builder.Configuration["SqlConnection:Postgresql"];
builder.Services.AddDbContext<SqlContext>(options => options.UseNpgsql(connection));

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ModuleIOC()));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //Para o erro de DateTime do Postgres => Cannot write DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone'


app.UseCors(options => {
    //options.WithOrigins("http://localhost:3000");
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


