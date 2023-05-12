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
        public DateTime PurchaseDate { get; set;}
        public DateTime ExpirationDate { get; set;}
    }
}