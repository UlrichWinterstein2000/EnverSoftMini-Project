namespace EnverSoftMini.Core.Entities
{
    public class Supplier
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }

        public string? CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
