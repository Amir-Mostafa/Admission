using AutoMapper;
using repo.Entity;
using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<applicationVM, application>();
            CreateMap< application, applicationVM>();

        }
    }
}
