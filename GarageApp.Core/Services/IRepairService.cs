using GarageApp.Core.Models;

namespace GarageApp.Core.Services
{
    public interface IRepairService
    {
        Task<List<Repair>> GetRepairRecordsAsync(int vehicleId);
        Task AddRepairRecordAsync(Repair record);
    }
}
