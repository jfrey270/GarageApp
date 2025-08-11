using GarageApp.Core.Models;

namespace GarageApp.Core.Services
{
    public interface IMaintenanceService
    {
        Task<List<Maintenance>> GetMaintenanceRecordsAsync(int vehicleId);
        Task AddMaintenanceRecordAsync(Maintenance record);
    }
}
