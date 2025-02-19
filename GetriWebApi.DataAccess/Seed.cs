using GetriWebApi.Models;
using Microsoft.AspNetCore.Identity;

namespace GetriWebApi.DataAccess
{
    public static class Seed
    {
        public static async Task Seeding(ApplicationDbContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any()) {
                var users = new List<AppUser>
                {
                    new AppUser{ DisplayName="Sachin", Email="sachin@gmail.com", UserName="sachin", Bio="Test Bio"  },
                    new AppUser{ DisplayName="Virat", Email="virat@gmail.com", UserName="virat", Bio="Test Bio" }
                };
                foreach (var user in users) {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if (!context.Activities.Any()) {
                var activitySeeder = new ActivitySeeder();
                var mockActivities = activitySeeder.GenerateMockData();
                await context.Activities.AddRangeAsync(mockActivities);
                await context.SaveChangesAsync();
            }
            return;
            
        }
    }
}
