using SQLite;

namespace GarageApp.Core.Models
{
    public class FuelEntry
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        [SQLite.Indexed]
        public int VehicleId { get; set; } // Foreign key

        public DateTime Date { get; set; } // Required
        public double Gallons { get; set; } // Required
        public int OdometerMiles { get; set; } // Required

        public double? MPG { get; set; } // Calculated

        public string? CloudKitRecordId { get; set; } // For syncing

        [Ignore]
        public Vehicle? Vehicle { get; set; }
    }
}
