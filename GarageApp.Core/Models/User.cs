using SQLite;

namespace GarageApp.Core.Models
{
    public class User
    {
        [PrimaryKey]
        public string? AppleId { get; set; } // Unique identifier from Apple Sign-In

        public string? DisplayName { get; set; }
        public DateTime RegisteredOn { get; set; }

        public bool IsSynced { get; set; }
    }
}
