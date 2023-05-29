using System;
using System.ComponentModel.DataAnnotations;
namespace test_app.Model
{
    public class LottoTickets
    {
        [Key]
        public int TicketId { get; set; }
        public int UserId { get; set;}
        public int TicketNumber { get; set;}
        public int Ball1 { get; set; }
        public int Ball2 { get; set; }
        public int Ball3 { get; set; }
        public int Ball4 { get; set; }
        public int Ball5 { get; set; }
        public int Ball6 { get; set; }
        public int Ball7 { get; set; }
        public int Ball8 { get; set; }
        public int Ball9 { get; set; }
        public DateTime PurchaseDate { get; set;}
        public DateTime ExpirationDate { get; set;}
    }
}