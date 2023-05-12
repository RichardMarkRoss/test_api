using System;
using System.ComponentModel.DataAnnotations;
namespace test_app.Model
{
    public class WinningNumbers
    {
        [Key]
        public int WinningNumberId { get; set; }
        public int TicketId { get; set; }
        public string? TicketTitle { get; set; }
        public int WinningNumber { get; set; }
        public DateTime DrawDate { get; set; }
    }
}
