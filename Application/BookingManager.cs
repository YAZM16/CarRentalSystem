using CarRentalSystem.Domain.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Application.Services;

public class BookingManager : IObservable
{
    private readonly List<IObserver> _observers = new();

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }

    public Booking BookVehicle(Vehicle vehicle, DateTime startDate, DateTime endDate)
    {
        var booking = new Booking(vehicle, startDate, endDate);
        NotifyObservers($"Booking created for vehicle {vehicle.Id}");
        return booking;
    }
}