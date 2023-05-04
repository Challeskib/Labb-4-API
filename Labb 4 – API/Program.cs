using Labb_4___API.Data;
using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.EntityFrameworkCore;


namespace Labb_4___API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            builder.Services.AddControllers().AddNewtonsoftJson(options => options
            .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddScoped<IAppRepository<Person>, PersonRepository>();
            builder.Services.AddScoped<IAppRepository<Link>, LinkRepository>();
            builder.Services.AddScoped<IAppRepository<Hobby>, HobbyRepository>();



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