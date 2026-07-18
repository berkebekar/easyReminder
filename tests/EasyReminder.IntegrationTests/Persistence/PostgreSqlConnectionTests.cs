using Testcontainers.PostgreSql;
using EasyReminder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReminder.IntegrationTests.Persistence;

public sealed class PostgreSqlConnectionTests
{
    [Fact]
    public async Task CanApplyMigrationsAndConnect()
    {
        // arrange
        await using PostgreSqlContainer postgreSqlContainer = new PostgreSqlBuilder("postgres:17-alpine").Build(); 
        await postgreSqlContainer.StartAsync();
        
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(postgreSqlContainer.GetConnectionString(), npgsqlOptions => npgsqlOptions.UseNodaTime()).Options;

        await using AppDbContext dbContext = new(options);
        // act
        await dbContext.Database.MigrateAsync();
        
        //assert
        bool canConnect = await dbContext.Database.CanConnectAsync();
        Assert.True(canConnect);
    }
}