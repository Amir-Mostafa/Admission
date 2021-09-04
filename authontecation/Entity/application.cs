using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class application
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string phone { get; set; }

        public string NationalId { get; set; }
        public string  Address { get; set; }
        public DateTime Date { get; set; }

        public string Gender { get; set; }

        public string BirthDateImage { get; set; }

        public string NationalIdImage { get; set; }
        public int approved { get; set; }

        public string userID { get; set; }


    }
}
