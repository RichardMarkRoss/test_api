using System;
using System.ComponentModel.DataAnnotations;
namespace test_api.Model
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
