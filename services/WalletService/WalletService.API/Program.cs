using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using WalletService.API.Middlewares;
using WalletService.API.Validators;
using WalletService.Application.Handlers;
using WalletService.Infrastructure.Repositories;
using WalletService.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using WalletService.Infrastructure.Persistence;
using WalletService.Application.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<WalletDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


builder.Services.AddScoped<IWalletService, WalletRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateWalletCommandHandler).Assembly)
);
builder.Services.AddValidatorsFromAssemblyContaining<CreateWalletRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateWalletRequestValidator>();

MapsterConfiguration.RegisterMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();