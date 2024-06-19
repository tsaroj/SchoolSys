using log4net.Config;
using Carter;
using SERVER.CORE.DTOs;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

//Configure Log4net.
XmlConfigurator.Configure(new FileInfo("log4net.config"));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapingConfig));
builder.Services.RegisterServices(builder.Configuration);

// builder.Services.AddScoped<IUserServices, UserServices>();
// builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.UseHttpsRedirection();

app.Run();