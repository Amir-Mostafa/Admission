using authontecation.Authontecation;
using authontecation.interfces;
using authontecation.Models;
using authontecation.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authontecation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private IEmployee dbcontext;
        public EmployeeController(IEmployee dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        
        public IActionResult GetAll()
        {
            return Ok(dbcontext.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            if (dbcontext.GetById(id) == null)
                return Content("Not Found");

            return Ok(dbcontext.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Add(emp);
                return Ok();
            }
            else
                return BadRequest();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var data = dbcontext.Delete(id);
            if (data== null)
                return BadRequest();

            else
            {
                return Ok(data);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult Update( Employee emp, int Id)
        {
            if (Id != emp.Id)
                return BadRequest();
            else
            {
                var data = dbcontext.Edit(emp);
                if (data == null)
                    return BadRequest();
                return Ok(data);
            }
        }
            



    }
}
