using authontecation.Authontecation;
using AutoMapper;
using repo.Entity;
using repo.interfces;
using repo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Repo
{
    public class ApplicationRepo : IApplicationRepo
    {
        private ApplicationDbContext db;
        private readonly IMapper mapper;
        public ApplicationRepo(ApplicationDbContext dbContext, IMapper _Mapper)
        {
            this.db = dbContext;
            this.mapper = _Mapper;
        }
        public AllApplications Get()
        {
            var data1 = db.applications.Where(n=>n.approved==0).Select(n => new applicationVM { Address=n.Address,BirthDateImage=n.BirthDateImage,Date=n.Date,Gender=n.Gender,Id=n.Id,Name=n.Name,NationalId=n.NationalId,NationalIdImage=n.NationalIdImage,phone=n.phone,approved=n.approved}).ToList();
            var data2= db.applications.Where(n => n.approved == 1).Select(n => new applicationVM { Address = n.Address, BirthDateImage = n.BirthDateImage, Date = n.Date, Gender = n.Gender, Id = n.Id, Name = n.Name, NationalId = n.NationalId, NationalIdImage = n.NationalIdImage, phone = n.phone,approved=n.approved }).ToList();
            AllApplications data = new AllApplications();
            data.allowed = data2;
            data.notAllowed = data1;
            return data;
        }
        public applicationVM Add(applicationVM d)
        {

            try
            {
                d.BirthDateURL.filename = Guid.NewGuid() + d.BirthDateURL.filename;
                d.NationalIdURL.filename = Guid.NewGuid() + d.NationalIdURL.filename;
                d.BirthDateImage = d.BirthDateURL.filename;
                d.NationalIdImage = d.NationalIdURL.filename;
                var data = mapper.Map<application>(d);
                db.applications.Add(data);
                
                string val1=Helper.uploadeFile.uploade(d.BirthDateURL);
                string val2 = Helper.uploadeFile.uploade(d.NationalIdURL);

                if (val1 == "Saved" && val2 == "Saved")
                {
                    db.SaveChanges();
                    return d;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }


        }
        public applicationVM getById(int id)
        {
            return db.applications.Where(n => n.Id == id).Select(n => new applicationVM { Address = n.Address, BirthDateImage = n.BirthDateImage, Date = n.Date, Gender = n.Gender, Id = n.Id, Name = n.Name, NationalId = n.NationalId, NationalIdImage = n.NationalIdImage, phone = n.phone }).FirstOrDefault();
        }
        public applicationVM edit(applicationVM d)
        {


            try
            {
                var data = mapper.Map<application>(d);
                string val1 = Helper.uploadeFile.uploade(d.BirthDateURL);
                string val2 = Helper.uploadeFile.uploade(d.NationalIdURL);



                if (val1 == "Saved" && val2 == "Saved")
                {
                    
                    db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return d;
                }
                else
                    return null;

            }
            catch
            {
                return null;
            }
            
            
        }
        public void delete(int id)
        {
            application d = db.applications.Where(n => n.Id == id).FirstOrDefault();

            db.applications.Remove(d);
            db.SaveChanges();
        }
        public void approve(int id)
        {
            application d = db.applications.Where(n => n.Id == id).FirstOrDefault();
            d.approved = 1;
            db.SaveChanges();
        }
        public void disApprove(int id)
        {
            application d = db.applications.Where(n => n.Id == id).FirstOrDefault();
            d.approved = 0;
            db.SaveChanges();
        }
        public List<string> getDocuments(int id)
        {
            try
            {
                application d = db.applications.Where(n => n.Id == id).FirstOrDefault();

                List<string> documents = new List<string>();
                string birth = Helper.uploadeFile.getBase64(d.BirthDateImage);
                string nationalid = Helper.uploadeFile.getBase64(d.NationalIdImage);
                documents.Add(birth);
                documents.Add(nationalid);
                return documents;
            }
            catch
            {
                return null;
            }

        }
        applicationVM IApplicationRepo.userApplication(string id)
        {
            return db.applications.Where(n => n.userID == id).Select(n => new applicationVM { Address = n.Address, BirthDateImage = n.BirthDateImage, Date = n.Date, Gender = n.Gender, Id = n.Id, Name = n.Name, NationalId = n.NationalId, NationalIdImage = n.NationalIdImage, phone = n.phone,userID=n.userID }).FirstOrDefault();
        }

    }
}
