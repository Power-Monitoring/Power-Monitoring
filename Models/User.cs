using System;
using System.ComponentModel.DataAnnotations;

namespace Power_Monitoring.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
