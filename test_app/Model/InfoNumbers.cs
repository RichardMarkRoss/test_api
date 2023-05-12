using System;
using System.ComponentModel.DataAnnotations;
namespace test_app.Model
{
    public class InfoNumbers
    {
        [Key]
        public int Id { get; set; }
        public int Fact { get; set; }
    }
}
