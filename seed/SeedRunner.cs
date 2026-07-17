using Microsoft.EntityFrameworkCore;

public static class SeedRunner
{
    public static async Task RunAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        await SuperAdminSeeder.SeedAsync(context);

        Console.WriteLine("✅ Seed Completed");
    }
}