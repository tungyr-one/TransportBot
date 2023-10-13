using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportBot.Entities;

namespace TransportBot.Data
{
    public class DemoDataSeeder
    {
        private const string TripsDemoDataFilePath = "./Data/Seed/trips.json";
        private const string UsersDemoDataFilePath = "./Data/Seed/users.json";

        public static async Task SeedAsync(DataContext context)
        {
            // await SeedTripsAsync(context);
            await SeedUsersAsync(context);
        }

        private static async Task SeedTripsAsync(DataContext context)
        {
            // var tripsFullPath = GetFullFilePath(TripsDemoDataFilePath);
            // if (!File.Exists(tripsFullPath) || await context.Trips.AnyAsync())
            // return;

            // var tripsJson = await File.ReadAllTextAsync(tripsFullPath);
            // var trips = JsonSerializer.Deserialize<TripDb[]>(tripsJson);

            // if (trips is not {Length: > 0})
            // return;

            // await context.Trips.AddRangeAsync(trips);
            // await context.SaveChangesAsync();
        }

        private static async Task SeedUsersAsync(DataContext context)
        {
            var usersFullPath = GetFullFilePath(UsersDemoDataFilePath);
            if (!File.Exists(usersFullPath) || await context.Users.AnyAsync())
            return;

            var usersJson = await File.ReadAllTextAsync(usersFullPath);
            var users = JsonSerializer.Deserialize<UserDb[]>(usersJson);

            if (users is not {Length: > 0})
            return;

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        private static string GetFullFilePath(string filePath)
         => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{filePath}";
   }
}
