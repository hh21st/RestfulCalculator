
using Microsoft.Extensions.DependencyInjection;
using RestfulCalculator.BusinessLogic;
using RestfulCalculator.Interface.BusinessLogic;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Minimal.WebApi.Config.Calculator;
using RestfulCalculator.Resources;
using RestfulCalculator.Services.Calculator;
using System;

namespace RestfulCalculator.Minimal.WebApi

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddScoped<ICalculator, Calculator>()
                .AddScoped<IAddService, AddService>()
                .AddScoped<ISubtractService, SubtractService>()
                .AddScoped<IMultiplyService, MultiplyService>()
                .AddScoped<IDivideService, DivideService>();

            builder.Services.AddProblemDetails();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(exceptionHandlerApp
                => exceptionHandlerApp.Run(async context
                    => await Results.Problem().ExecuteAsync(context)));
            app.UseStatusCodePages(async statusCodeContext
                => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                    .ExecuteAsync(statusCodeContext.HttpContext));

            app.UseAuthorization();

            MapServices(app);

            app.Logger.LogInformation(Messages.AppStarted);

            app.Run();

            app.Logger.LogInformation(Messages.AppEnded);
        }


        private static void MapServices(WebApplication app)
        {
            new AddServiceConfig().Map(app);
            new SubtractServiceConfig().Map(app);
            new MultiplyServiceConfig().Map(app);
            new DivideServiceConfig().Map(app);
        }

    }
}