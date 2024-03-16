
using ExamAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace ExamAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Команда для запуска службы PostgreSQL в Linux с использованием systemctl
            string command = "service postgresql start";

            // Создаем процесс для выполнения команды запуска службы PostgreSQL
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = $"-c \"{command}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            // Запускаем процесс
            process.Start();

            // Ждем, пока процесс завершится
            process.WaitForExit();



            builder.Services.AddDbContext<ExamAPIContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ExamAPIContext") ?? throw new InvalidOperationException("Connection string 'ExamAPIContext' not found.")));


            ////# Запуск миграций в базе данных C#
            ////# (этот код нужно вставить в подходящее место вашего проекта C#)
            using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var migrationDbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();

                if (migrationDbContext.Database.GetPendingMigrations().Any())
                {
                    var migrator = migrationDbContext.GetService<IMigrator>();
                    migrator.Migrate();
                }
            }

            // Add services to the container.
            //// Создание нового экземпляра сервиса DbContext и применение миграций
            //using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
            //{
            //    var migrationDbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();

            //    //if (!migrationDbContext.Database.GetPendingMigrations().Any())
            //    //{
            //    //    var migrator = migrationDbContext.GetInfrastructure().GetService<IMigrator>();
            //    //    migrator.Migrate();
            //    //}
            //    //var serviceProvider = serviceScope.ServiceProvider;
            //    // Создание миграции, если они отсутствуют
            //    if (migrationDbContext.Database.GetPendingMigrations().Any())
            //    {
            //        var migrator = migrationDbContext.GetService<IMigrator>();
            //        migrator.Migrate();
            //    }
            //    //// Получение экземпляра контекста базы данных
            //    //var migrationDbContext = serviceProvider.GetRequiredService<ExamAPIContext>();

            //    ////// Создание миграции, если они отсутствуют
            //    ////if (migrationDbContext.Database.GetPendingMigrations().Any())
            //    ////{
            //    ////    var migrator = migrationDbContext.GetService<IMigrator>();
            //    ////    migrator.Migrate();
            //    ////}

            //    //var dbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();
            //    //// Применение всех ожидающих миграций
            //    //dbContext.Database.Migrate();

            //}


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
                app.UseHsts();

                app.UseHttpsRedirection();

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
