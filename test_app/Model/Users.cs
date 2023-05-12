using System;
using System.ComponentModel.DataAnnotations;
namespace test_app.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int UserAge { get; set; }
        public int Credits { get; set;}
        public bool Rica { get; set; }
        public int IdNumber { get; set; }
    }
}
