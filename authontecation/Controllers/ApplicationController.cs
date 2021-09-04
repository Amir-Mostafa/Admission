using authontecation.Authontecation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repo.interfces;
using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private IApplicationRepo db;
        public ApplicationController(IApplicationRepo db)
        {
            this.db = db;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(db.Get());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            if (db.getById(id) == null)
                return Content("Not Found");

            return Ok(db.getById(id));
        }

        [HttpGet("user/{id}")]
        public IActionResult userApplication(string id)
        {
            applicationVM data = db.userApplication(id);
            if (data== null)
                return Ok(new response { Message="Application Not Found",Status="Not Found"});

            List<string> imgs = db.getDocuments(data.Id);

            image birth = new image()
            {
                filename = data.BirthDateImage,
                value= imgs[0]
             };

            image national = new image()
            {
                filename = data.NationalIdImage,
                value = imgs[1]
            };

            data.BirthDateURL = birth;
            data.NationalIdURL = national;
            return Ok(data);
        }


        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
            db.delete(id);
            return Ok(new response { Message="Deleated successfuly",Status="success"});
        }

        [HttpGet("approve/{id}")]
        public IActionResult approve(int id)
        {
            db.approve(id);
            return Ok(new response { Message = "Updated successfuly", Status = "success" });
        }
        [HttpGet("disApprove/{id}")]
        public IActionResult disApprove(int id)
        {
            db.disApprove(id);
            return Ok(new response { Message = "Updated successfuly", Status = "success" });
        }

        [HttpPost]
        public IActionResult Add(applicationVM app)
        {
            if (ModelState.IsValid)
            {
                var data=db.Add(app);
                if(data==null)
                    return Ok(new response { Message = "something error", Status = "error" });

                return Ok(new response { Message = "application added successfuly", Status = "success" });
            }
            else
            {

                return Ok(new response { Message = "something error", Status = "error" });
            }


        }

        [HttpPut]
        public IActionResult Edit(applicationVM app)
        {
            if (ModelState.IsValid)
            {
                var data = db.edit(app);
                if (data == null)
                    return Ok(new response { Message = "something error", Status = "error" });

                return Ok(new response { Message = "application updated successfuly", Status = "success" });
            }
            else
            {

                return Ok(new response { Message = "something error", Status = "error" });
            }


        }
        [HttpGet("documents/{id:int}")]
        public IActionResult getDocuments(int id)
        {
            return Ok(db.getDocuments(id));
        }
    }
}
