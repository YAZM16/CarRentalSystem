using System;
using System.Collections.Generic;

namespace CarRentalSystem.Domain.Models
{
    public class Vehicle
    {
        public string Id { get; }
        public string Type { get; }
        public decimal DailyRate { get; }
        public bool IsAvailable { get; private set; }
        public List<Booking> Bookings { get; private set; }

        public Vehicle(string id, string type, decimal dailyRate)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            DailyRate = dailyRate;
            IsAvailable = true;
            Bookings = new List<Booking>();
        }
    }
}