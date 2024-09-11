using Microsoft.EntityFrameworkCore;
using DotNetProject.Services;
using DotNetProject.Repositories;
using DotNet_Backend.Service;

namespace DotNetProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure services
            // Add DbContext with SQL Server configuration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register SegmentService
            builder.Services.AddScoped<ISegment, SegmentService>();
            builder.Services.AddScoped<IManufacturer, ManufacturerService>();
            builder.Services.AddScoped<IModel, ModelService>();
            builder.Services.AddScoped<ICarDescription, CarDescriptionService>();
            builder.Services.AddScoped<IVehicle,VehicleService>();  
            builder.Services.AddScoped<IComponent, ComponentService>();
            builder.Services.AddScoped<IAlternateComponent, AlternateComponentService>();
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IEmail, EmailService>();
            // Add controllers
            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
