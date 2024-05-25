namespace FitnessAppApi.Api
{
    public class FitnessArena
    {
        public int ArenaId { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class TicketTypes
    {
        public int TicketTypeId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int ValidityDays { get; set; }
        public int ValidityEntries { get; set; }
        public bool IsDeleted { get; set; }
        public int ArenaId { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int EntriesPerDay { get; set; }
    }

    public class Clients
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? CNP { get; set; }
        public string? Address { get; set; }
        public string? Barcode { get; set; }
        public string? Notes { get; set; }
    }

    public class Entries
    {
        public int EntryId { get; set; }
        public int ClientId { get; set; }
        public int TicketTypeId { get; set; }
        public DateTime Date { get; set; }
        public int InsertedByUid { get; set; }
        public string? Barcode { get; set; }
        public int ArenaId { get; set; }
    }

    public class ClientTickets
    {
        public int ClientTicketsId { get; set; }
        public int ClientId { get; set; }
        public int TicketTypeId { get; set; }
        public DateTime IssueDate { get; set; }
        public string? Barcode { get; set; }
        public int NumOfEntries { get; set; }
        public decimal BuyPrice { get; set; }
        public bool Valid { get; set; }
        public DateTime FirstUsageDate { get; set; }
        public int ArenaId { get; set; }
    }
}