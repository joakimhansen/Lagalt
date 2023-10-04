using Lagalt_backend.Data.Models;
using Lagalt_backend.Services.Categories;
using Lagalt_backend.Services.Projects;
using Lagalt_backend.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<LagaltDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LagaltTestDb")));

            // Register services
            builder.Services.AddScoped<UserService, UserService>();
            builder.Services.AddScoped<ProjectService, ProjectService>();
            builder.Services.AddScoped<CategoryService, CategoryService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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