using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TransportBot.Data
{
    public class DemoDataSeeder
    {
        private const string TripsDemoDataFilePath = "./Data/Seed/trips.json";
        private const string UsersDemoDataFilePath = "./Data/Seed/users.json";

        public static async Task SeedAsync(DataContext context)
        {
            await SeedTripsAsync(context);
            await SeedUsersAsync(context);
        }

         private static async Task SeedTripsAsync(DataContext context)
        {

        }

      private static async Task SeedUsersAsync(DataContext context)
      {

      }

        private static string GetFullFilePath(string filePath)
         => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{filePath}";
   }
}
