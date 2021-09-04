using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class AllApplications
    {
        public List<applicationVM> allowed { get; set; }
        public List<applicationVM> notAllowed { get; set; }
    }
}
