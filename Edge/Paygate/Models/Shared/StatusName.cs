using Paygate;



namespace Paygate.Models.Shared
{
    // Define the StatusName enum based on the possible status values
    public enum StatusName
    {
        Unknown = 0,
        Confirmed = 1,
        Failed = 2,
        Pending = 3,
        Cancelled = 4
        // Add other status values as needed
    }
}