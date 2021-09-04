using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class applicationVM
    {


        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Require")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Require")]
        public string phone { get; set; }

        [Required(ErrorMessage = "National ID Require")]
        public string NationalId { get; set; }
        [Required(ErrorMessage = "Address Require")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Require")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Gender Require")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "National ID Image Require")]
        public string BirthDateImage { get; set; }
        [Required(ErrorMessage = "Birth Date Image Require")]
        public string NationalIdImage { get; set; }

        public image BirthDateURL { get; set; }
        public image NationalIdURL { get; set; }
        public int approved { get; set; }
        public string userID { get; set; }

    }
}
