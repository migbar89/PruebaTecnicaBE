using AppUsers.Application.Services;
using FluentValidation.AspNetCore;
using PruebaTecnia.net7.Services;
using PruebaTecnica.net7.Data;
using PruebaTecnica.net7.Data.Repositories;
using AppUsers.Dominio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers()
//            .AddFluentValidation(v =>
//            {
//                v.ImplicitlyValidateChildProperties = true;
//                v.ImplicitlyValidateRootCollectionElements = true;
//                v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//            });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<UserContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMailServices, MailServices>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
