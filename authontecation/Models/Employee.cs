using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authontecation.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Require")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary Require")]
        public double salary { get; set; }
    }
}
