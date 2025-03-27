using CarRentalSystem.Application.Interfaces;
using CarRentalSystem.Application.Services;
using CarRentalSystem.Domain.Models;
using CarRentalSystem.Infrastructure;
using CarRentalSystem.Infrastructure.Services;

class Program
{
    static void Main(string[] args)
    {
        // Initialize services
        var bookingManager = new BookingManager();

        // Register observers
        var emailService = new EmailService(bookingManager);
        var smsNotification = new SMSNotification(bookingManager);

        // Create sample vehicle
        var car = new Vehicle("CAR001", "Toyota Camry", 50.00m);

        Console.WriteLine("Welcome to Car Rental System");
        Console.WriteLine("Booking a vehicle...");

        // Book vehicle
        var booking = bookingManager.BookVehicle(car,
            DateTime.Now,
            DateTime.Now.AddDays(1));

        Console.WriteLine($"Booking created successfully!");
        Console.WriteLine($"Booking ID: {booking.Id}");
        Console.WriteLine($"Vehicle Type: {booking.Vehicle.Type}");
        Console.WriteLine($"Dates: {booking.StartDate} - {booking.EndDate}");

        Console.ReadLine();
    }
}