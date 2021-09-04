using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authontecation.Authontecation
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "user name required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }

        public string type { get; set; }

    }
}
