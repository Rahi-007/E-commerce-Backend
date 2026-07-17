using Microsoft.EntityFrameworkCore;

public static class SuperAdminSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        var exists = await context.Users.AnyAsync(); //x => x.Role == UserRole.SuperAdmin

        if (exists)
            return;

        Guid adminId = Guid.NewGuid();

        User admin = new()
        {
            Id = adminId,
            FirstName = "Super",
            LastName = "Admin",
            Phone = "01729249260",
            Address = string.Empty,
            Gender = Gender.Male,
            Password = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            CreatedById = adminId,
        };

        context.Users.Add(admin);
        await context.SaveChangesAsync();
    }
}