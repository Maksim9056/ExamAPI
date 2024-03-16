
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

            // ������� ��� ������� ������ PostgreSQL � Linux � �������������� systemctl
            string command = "service postgresql start";

            // ������� ������� ��� ���������� ������� ������� ������ PostgreSQL
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = $"-c \"{command}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            // ��������� �������
            process.Start();

            // ����, ���� ������� ����������
            process.WaitForExit();



            builder.Services.AddDbContext<ExamAPIContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ExamAPIContext") ?? throw new InvalidOperationException("Connection string 'ExamAPIContext' not found.")));


            ////# ������ �������� � ���� ������ C#
            ////# (���� ��� ����� �������� � ���������� ����� ������ ������� C#)
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
            //// �������� ������ ���������� ������� DbContext � ���������� ��������
            //using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
            //{
            //    var migrationDbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();

            //    //if (!migrationDbContext.Database.GetPendingMigrations().Any())
            //    //{
            //    //    var migrator = migrationDbContext.GetInfrastructure().GetService<IMigrator>();
            //    //    migrator.Migrate();
            //    //}
            //    //var serviceProvider = serviceScope.ServiceProvider;
            //    // �������� ��������, ���� ��� �����������
            //    if (migrationDbContext.Database.GetPendingMigrations().Any())
            //    {
            //        var migrator = migrationDbContext.GetService<IMigrator>();
            //        migrator.Migrate();
            //    }
            //    //// ��������� ���������� ��������� ���� ������
            //    //var migrationDbContext = serviceProvider.GetRequiredService<ExamAPIContext>();

            //    ////// �������� ��������, ���� ��� �����������
            //    ////if (migrationDbContext.Database.GetPendingMigrations().Any())
            //    ////{
            //    ////    var migrator = migrationDbContext.GetService<IMigrator>();
            //    ////    migrator.Migrate();
            //    ////}

            //    //var dbContext = serviceScope.ServiceProvider.GetRequiredService<ExamAPIContext>();
            //    //// ���������� ���� ��������� ��������
            //    //dbContext.Database.Migrate();

            //}


            builder.Services.AddControllers();

            // ��������� �������� CORS ��� ����������
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

            // �������� CORS � ��������� ��� ����������
            app.UseCors("AllowAll");



            app.MapControllers();

            app.Run();
        }
    }
}
