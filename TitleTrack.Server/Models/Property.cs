namespace TitleTrack.Server.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string FullAddress
        {
            get
            {
                return $"{StreetAddress}, {City}, {State} {ZipCode}";
            }
        }
    }
}