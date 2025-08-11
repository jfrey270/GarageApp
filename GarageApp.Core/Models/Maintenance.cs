using SQLite;

namespace GarageApp.Core.Models
{
    public class Maintenance
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        [SQLite.Indexed]
        public int VehicleId { get; set; } // Foreign key

        public DateTime Date { get; set; } // Required
        public string? WorkPerformed { get; set; } // Required
        public int MilesAtService { get; set; } // Required
        public string? Shop { get; set; } // Required

        public string? CloudKitRecordId { get; set; } // For syncing

        [Ignore]
        public Vehicle? Vehicle { get; set; }
    }
}
