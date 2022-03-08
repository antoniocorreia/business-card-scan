namespace BusinessCardScan.Shared
{
    public class BusinessCard
    {
        public string? Locale { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<string>? CompanyNames { get; set; }
        public List<string>? Departments { get; set; }
        public List<string>? JobTitles { get; set; }
        public List<string>? Emails { get; set; }
        public List<string>? Websites { get; set; }
        public List<string>? Addresses { get; set; }
        public List<string>? MobilePhones { get; set; }
        public List<string>? Faxes { get; set; }
        public List<string>? WorkPhones { get; set; }
        public List<string>? OtherPhones { get; set; }

    }
}
