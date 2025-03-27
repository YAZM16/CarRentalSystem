using CarRentalSystem.Application.Interfaces;
using CarRentalSystem.Application.Services;
using CarRentalSystem.Domain.Models;

namespace CarRentalSystem.Infrastructure.Services
{
    public class EmailService : System.IObserver<Booking>
    {
        private readonly IObservable<Booking> bookingManager;
        private BookingManager bookingManager1;

        public EmailService(IObservable<Booking> bookingManager)
        {
            this.bookingManager = bookingManager;
            bookingManager.Subscribe(this);
        }

        public EmailService(BookingManager bookingManager1)
        {
            this.bookingManager1 = bookingManager1;
        }

        public void OnNext(Booking value)
        {
            Console.WriteLine($"Sending email: Booking {value.Id} created");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Error sending email: {error.Message}");
        }

        public void OnCompleted()
        {
            Console.WriteLine("Email service completed");
        }
    }

    public class SMSNotification : System.IObserver<Booking>
    {
        private readonly IObservable<Booking> bookingManager;
        private BookingManager bookingManager1;

        public SMSNotification(IObservable<Booking> bookingManager)
        {
            this.bookingManager = bookingManager;
            bookingManager.Subscribe(this);
        }

        public SMSNotification(BookingManager bookingManager1)
        {
            this.bookingManager1 = bookingManager1;
        }

        public void OnNext(Booking value)
        {
            Console.WriteLine($"Sending SMS: Booking {value.Id} created");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Error sending SMS: {error.Message}");
        }

        public void OnCompleted()
        {
            Console.WriteLine("SMS service completed");
        }
    }
}