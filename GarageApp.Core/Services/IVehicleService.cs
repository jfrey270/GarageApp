using GarageApp.Core.Models;

namespace GarageApp.Core.Services
{
    public interface IVehicleService
    {
    Task<List<Vehicle>> GetVehiclesAsync();
    Task AddVehicleAsync(Vehicle vehicle);
    Task UpdateVehicleAsync(Vehicle vehicle);
    Task DeleteVehicleAsync(int vehicleId);
    // TireSize is now part of Vehicle model (no extra methods needed)
    }
}
