using SQLite;
using GarageApp.Core.Models;
using GarageApp.Core.Services;

namespace GarageApp.Database
{
    public class DatabaseService : IVehicleService, IMaintenanceService, IRepairService, IFuelService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Vehicle>().Wait(); // Will auto-migrate to add TireSize if not present
            _db.CreateTableAsync<Maintenance>().Wait();
            _db.CreateTableAsync<Repair>().Wait();
            _db.CreateTableAsync<FuelEntry>().Wait();
        }

        // Vehicle
        public async Task<List<Vehicle>> GetVehiclesAsync() => await _db.Table<Vehicle>().ToListAsync();
        public async Task AddVehicleAsync(Vehicle vehicle) => await _db.InsertAsync(vehicle);
        public async Task UpdateVehicleAsync(Vehicle vehicle) => await _db.UpdateAsync(vehicle);
        public async Task DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = await _db.FindAsync<Vehicle>(vehicleId);
            if (vehicle != null) await _db.DeleteAsync(vehicle);
        }

        // Maintenance
        public async Task<List<Maintenance>> GetMaintenanceRecordsAsync(int vehicleId) =>
            await _db.Table<Maintenance>().Where(r => r.VehicleId == vehicleId).ToListAsync();
        public async Task AddMaintenanceRecordAsync(Maintenance record) => await _db.InsertAsync(record);

        // Repair
        public async Task<List<Repair>> GetRepairRecordsAsync(int vehicleId) =>
            await _db.Table<Repair>().Where(r => r.VehicleId == vehicleId).ToListAsync();
        public async Task AddRepairRecordAsync(Repair record) => await _db.InsertAsync(record);

        // Fuel
        public async Task<List<FuelEntry>> GetFuelEntriesAsync(int vehicleId) =>
            await _db.Table<FuelEntry>().Where(e => e.VehicleId == vehicleId).ToListAsync();
        public async Task AddFuelEntryAsync(FuelEntry entry) => await _db.InsertAsync(entry);

        public double CalculateMPG(List<FuelEntry> entries)
        {
            if (entries == null || entries.Count < 2) return 0;
            entries = entries.OrderBy(e => e.Date).ToList();
            var first = entries.First();
            var last = entries.Last();
            var miles = last.OdometerMiles - first.OdometerMiles;
            var gallons = entries.Skip(1).Sum(e => e.Gallons); // exclude first fill-up
            return gallons > 0 ? miles / gallons : 0;
        }
    }
}
