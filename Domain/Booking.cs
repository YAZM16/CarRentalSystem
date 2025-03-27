using System;

namespace CarRentalSystem.Domain.Models
{
    public class Booking
    {
        public int Id { get; }
        public Vehicle Vehicle { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool IsCancelled { get; private set; }

        public Booking(int id, Vehicle vehicle, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
            StartDate = startDate;
            EndDate = endDate;
            IsCancelled = false;
        }

        public Booking(Vehicle vehicle, DateTime startDate, DateTime endDate)
        {
            Vehicle = vehicle;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}