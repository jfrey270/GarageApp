using SQLite;

namespace GarageApp.Core.Models
{
	public class Vehicle
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string? Name { get; set; } // Optional
		public string? Make { get; set; } // Required
		public string? Model { get; set; } // Required
		public int Year { get; set; } // Required
		public string? Color { get; set; } // Required
		public string? Engine { get; set; } // Required
		public string? VIN { get; set; } // Optional
		public int? Miles { get; set; } // Optional
		public string? PhotoPath { get; set; } // Optional (iOS/iPad only)
		public string? CloudKitRecordId { get; set; } // For syncing

		[Ignore]
		public List<Maintenance>? MaintenanceRecords { get; set; }
		[Ignore]
		public List<Repair>? RepairRecords { get; set; }
		[Ignore]
		public List<FuelEntry>? FuelEntries { get; set; }
	}
}
