using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Models;

namespace CarRentalSystem.Infrastructure.Data
{
    public sealed class VehicleDatabase
    {
        private static VehicleDatabase? _instance;
        private readonly Dictionary<string, Vehicle> _vehicles;

        private VehicleDatabase()
        {
            _vehicles = new Dictionary<string, Vehicle>();
        }

        public static VehicleDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleDatabase();
                }
                return _instance;
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles[vehicle.Id] = vehicle;
        }

        public List<Vehicle> GetAvailableVehicles(DateTime startDate, DateTime endDate)
        {
            return _vehicles.Values
                .Where(v =>
                    !v.Bookings.Any(b =>
                        !(b.StartDate >= endDate || b.EndDate <= startDate)))
                .ToList();
        }

        public Vehicle? GetVehicle(string id)
        {
            return _vehicles.TryGetValue(id, out var vehicle) ? vehicle : null;
        }
    }
}