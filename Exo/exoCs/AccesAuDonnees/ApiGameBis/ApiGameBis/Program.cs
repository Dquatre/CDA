
using ApiGameBis.Models;
using ApiGameBis.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiGameBis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PlatformDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddTransient<PlatformsServices>();
            builder.Services.AddTransient<GamesServices>();
            builder.Services.AddTransient<GamesPlatformsServices>();
            builder.Services.AddTransient<SeriesServices>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddNewtonsoftJson();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}