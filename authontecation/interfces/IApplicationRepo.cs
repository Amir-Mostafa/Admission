using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IApplicationRepo
    {
        AllApplications Get();
        applicationVM Add(applicationVM app);
        applicationVM getById(int id);
        applicationVM edit(applicationVM app);
        void delete(int id);

        void approve(int id);
        void disApprove(int id);

        

        List<string> getDocuments(int id);
        applicationVM userApplication(string id);

    }
}
