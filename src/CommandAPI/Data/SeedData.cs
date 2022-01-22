using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CommandContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<CommandContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.CommandItems.Any())
            {
                context.CommandItems.AddRange(
                new Command
                {
                    HowTo = "Create an EF migration",
                    Platform = "'Entity Framework Core Command Line",
                    CommandLine = "dotnet ef migrations add"

                },
                new Command
                {
                    HowTo = "'Apply Migrations to DB",
                    Platform = "Entity Framework Core Command Line",
                    CommandLine = "dotnet ef database update"

                },
                new Command
                {
                    HowTo = "Reset Database",
                    Platform = "Entity Framework Core Command Line",
                    CommandLine = "dotnet ef database drop --force --context [DBContext]"
                },
                new Command
                {
                    HowTo = "Install EF Core Command Line",
                    Platform = ".NET Core 3.1 CLI",
                    CommandLine = "dotnet tool install --global dotnet-ef --version 3.1.1"
                },

                new Command
                {
                    HowTo = "Install EF Core design nuget package",
                    Platform = ".NET Core 3.1 CLI",
                    CommandLine = "dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.1"
                },
                new Command
                {
                    HowTo = "Install EF Core Posgresql nuget package",
                    Platform = ".NET Core 3.1 CLI",
                    CommandLine = "dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --versin 3.1.1"
                },
                new Command
                {
                    HowTo = "Start new asp.net core empy web",
                    Platform = ".NET Core 3.1 CLI",
                    CommandLine = "dotnet new web -f netcoreapp3.1"
                },
                new Command
                {
                    HowTo = "Start new asp.net core empy web",
                    Platform = ".NET 6 CLI",
                    CommandLine = "dotnet new web"
                },
                new Command
                {
                    
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"
                },

                new Command
                {
                    
                    HowTo = "Run Migrations",
                    CommandLine = "dotnet ef database update",
                    Platform = ".Net Core EF"
                },

                new Command
                {
                    
                    HowTo = "List active migrations",
                    CommandLine = "dotnet ef migrations list",
                    Platform = ".Net Core EF"
                }
                );
                context.SaveChanges();
            }
        }
    }
}