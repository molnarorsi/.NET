namespace ClientAPI.API
{
    public class Entities
    {
        public class Fitness
        {
            public int fitnessID { get; set; }
            public string? fitnessName { get; set; }
            public bool isDeleted { get; set; }
        }

        public class Memberships
        {
            public int membershipID { get; set; }
            public string? membershipName { get; set; }
            public decimal membershipPrice { get; set; }
            public int validityDays { get; set; }
            public int validityEntries { get; set; }
            public bool isDeleted { get; set; }
            public int fitnessID { get; set; }
            public int fromHour { get; set; }
            public int toHour { get; set; }
            public int dailyEntriesNumber { get; set; }
        }

        public class Clients
        {
            public int clientID { get; set; }
            public string? clientName { get; set; }
            public string? phoneNumber { get; set; }
            public string? email { get; set; }
            public bool isDeleted { get; set; }
            public byte[]? avatar { get; set; }
            public DateTime registerDate { get; set; }
            public string? CNP { get; set; }
            public string? barcode { get; set; }
            public string? address { get; set; }
            public string? notes { get; set; }
        }

        public class Entries
        {
            public int entriesID { get; set; }
            public int clientID { get; set; }
            public int membershipID { get; set; }
            public DateTime date { get; set; }
            public int insertedByUID { get; set; }
            public string? barcode { get; set; }
            public int fitnessID { get; set; }
        }

        public class ClientMemberships
        {
            public int clientMembershipID { get; set; }
            public int clientID { get; set; }
            public int membershipID { get; set; }
            public DateTime buyingDate { get; set; }
            public string? barcode { get; set; }
            public int nrOfEntries { get; set; }
            public decimal price { get; set; }
            public bool isValid { get; set; }
            public DateTime firstUsage { get; set; }
            public int fitnessID { get; set; }
        }
    }


}
