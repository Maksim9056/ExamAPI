
using ExamAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ExamAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

       

            builder.Services.AddDbContext<ExamAPIContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ExamAPIContext") ?? throw new InvalidOperationException("Connection string 'ExamAPIContext' not found.")));
            // Add services to the container.
            // Создание нового экземпляра сервиса DbContext и применение миграций
            using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
            {
                //var migrationDbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();

                //if (!migrationDbContext.Database.GetPendingMigrations().Any())
                //{
                //    var migrator = migrationDbContext.GetInfrastructure().GetService<IMigrator>();
                //    migrator.Migrate();
                //}
                var serviceProvider = serviceScope.ServiceProvider;

                // Получение экземпляра контекста базы данных
                var migrationDbContext = serviceProvider.GetRequiredService<ExamAPIContext>();

                // Создание миграции, если они отсутствуют
                if (migrationDbContext.Database.GetPendingMigrations().Any())
                {
                    var migrator = migrationDbContext.GetService<IMigrator>();
                    migrator.Migrate();
                }

                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();
                // Применение всех ожидающих миграций
                dbContext.Database.Migrate();
            }


            builder.Services.AddControllers();

            // Добавляем политику CORS без блокировок
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
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

            // Включаем CORS с политикой без блокировок
            app.UseCors("AllowAll");



            app.MapControllers();

            app.Run();
        }
    }
}
