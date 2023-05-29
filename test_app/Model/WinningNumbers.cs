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
        public int Ball1 { get; set; }
        public int Ball2 { get; set; }
        public int Ball3 { get; set; }
        public int Ball4 { get; set; }
        public int Ball5 { get; set; }
        public int Ball6 { get; set; }
        public int Ball7 { get; set; }
        public int Ball8 { get; set; }
        public int Ball9 { get; set; }
        public DateTime DrawDate { get; set; }
    }
}
