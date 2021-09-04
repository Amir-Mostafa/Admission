using authontecation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authontecation.interfces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);   
    }
}
