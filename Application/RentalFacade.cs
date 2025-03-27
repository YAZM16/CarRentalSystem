// Facade coordinates between Presentation and Domain layers
using CarRentalSystem.Application.Services;
using CarRentalSystem.Domain.Models;
using CarRentalSystem.Infrastructure.Data;

public class RentalFacade
{
    private readonly CarRentalSystem.Infrastructure.Data.VehicleDatabase vehicleDb;
    private readonly BookingManager bookingMgr;

    public RentalFacade()
    {
        vehicleDb = VehicleDatabase.Instance;
        bookingMgr = new BookingManager();
    }

    public bool BookVehicle(string vehicleId, DateTime startDate, DateTime endDate)
    {
        var vehicle = vehicleDb.GetVehicle(vehicleId);

        if (vehicle == null)
            return false;

        var availableVehicles = vehicleDb.GetAvailableVehicles(startDate, endDate);
        if (!availableVehicles.Contains(vehicle))
            return false;

        var booking = bookingMgr.BookVehicle(vehicle, startDate, endDate);
        return booking != null;
    }
}