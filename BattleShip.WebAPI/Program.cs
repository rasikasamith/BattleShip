
using BattleShip.WebAPI.Repositories;
using BattleShip.WebAPI.Repositories.Contracts;
using Microsoft.Net.Http.Headers;

namespace BattleShip.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //To Add dependancy injection
            builder.Services.AddScoped<IGameBoardRepository, GameBoardRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Add these lines to give permissions to access
            app.UseCors(policy =>
            policy.WithOrigins("http://localhost:7253","https://localhost:7253")
            .AllowAnyMethod()
            .WithHeaders(HeaderNames.ContentType)
            );        

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
