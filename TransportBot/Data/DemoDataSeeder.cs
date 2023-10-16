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
        private const string AddressesDemoDataFilePath = "./Data/Seed/addresses.json";
        private const string OrdersDemoDataFilePath = "./Data/Seed/orders.json";

        public static async Task SeedAsync(DataContext context)
        {
            await SeedUsersAsync(context);
            await SeedAddressesAsync(context);
            await SeedTripsAsync(context);
            // await SeedOrdersAsync(context);
        }

        private static async Task SeedUsersAsync(DataContext context)
        {
            var usersFullPath = GetFullFilePath(UsersDemoDataFilePath);
            if (!File.Exists(usersFullPath) || await context.Users.AnyAsync())
            return;

            var usersJson = await File.ReadAllTextAsync(usersFullPath);
            var users = JsonSerializer.Deserialize<UserEntity[]>(usersJson);

            if (users is not {Length: > 0})
            return;

            foreach(var user in users)
            {
                user.Created = user.Created.ToUniversalTime();
                user.BirthDate = user.BirthDate?.ToUniversalTime();
                user.Updated = user.Updated?.ToUniversalTime();
                user.LastTrip = user.LastTrip?.ToUniversalTime();
            }

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAddressesAsync(DataContext context)
        {
            var addressesFullPath = GetFullFilePath(AddressesDemoDataFilePath);
            if (!File.Exists(addressesFullPath) || await context.Addresses.AnyAsync())
            return;

            var addressesJson = await File.ReadAllTextAsync(addressesFullPath);
            var addresses = JsonSerializer.Deserialize<AddressEntity[]>(addressesJson);

            if (addresses is not {Length: > 0})
            return;

            await context.Addresses.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTripsAsync(DataContext context)
        {
            var tripsFullPath = GetFullFilePath(TripsDemoDataFilePath);
            if (!File.Exists(tripsFullPath) || await context.Trips.AnyAsync())
            return;

            var tripsJson = await File.ReadAllTextAsync(tripsFullPath);
            var trips = JsonSerializer.Deserialize<TripEntity[]>(tripsJson);

            if (trips is not {Length: > 0})
            return;

            foreach(var trip in trips)
            {
                trip.Created = trip.Created.ToUniversalTime();
                trip.TripDateTime = trip.TripDateTime.ToUniversalTime();
                trip.Updated = trip.Updated?.ToUniversalTime();
            }

            await context.Trips.AddRangeAsync(trips);
            await context.SaveChangesAsync();
        }

        private static async Task SeedOrdersAsync(DataContext context)
        {
            var ordersFullPath = GetFullFilePath(OrdersDemoDataFilePath);
            if (!File.Exists(ordersFullPath) || await context.Orders.AnyAsync())
            return;

            var ordersJson = await File.ReadAllTextAsync(ordersFullPath);
            var orders = JsonSerializer.Deserialize<OrderEntity[]>(ordersJson);

            if (orders is not {Length: > 0})
            return;

            foreach(var order in orders)
            {
                order.Created = order.Created.ToUniversalTime();
                order.Updated = order.Updated?.ToUniversalTime();
            }

            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }

        private static string GetFullFilePath(string filePath)
         => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{filePath}";
   }
}
