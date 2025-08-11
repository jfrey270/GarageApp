using GarageApp.Core.Models;

namespace GarageApp.Core.Services
{
    public interface IFuelService
    {
        Task<List<FuelEntry>> GetFuelEntriesAsync(int vehicleId);
        Task AddFuelEntryAsync(FuelEntry entry);
        double CalculateMPG(List<FuelEntry> entries);
    }
}
