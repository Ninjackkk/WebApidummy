using Microsoft.AspNetCore.Mvc;
using WebApidummy.Data;
using WebApidummy.Models;

namespace WebApidummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        [Route("AddEmp")]
        public IActionResult AddNewEmp(Emp e)
        {
            db.EmpDetails.Add(e);
            db.SaveChanges();
            return Ok("Emp Added Successfully");                        // Add using api
        }


        [HttpGet]
        [Route("GetEmps")]
        public IActionResult GetAllEmp()
        {               
            var data =db.EmpDetails.ToList();                         // Fetch using api
            return Ok(data);
        }

        //Route[("DelEmp/{id}")]
        //[HttpPo]
        // public IActionResult DelEmp(int id)
        //{
        //    var data = db.EmpDetails.Find(id);
        //    db.EmpDetails.Remove(data);
        //    db.SaveChanges();
        //    return Ok("Emp deleted successfully");
        //}

        [Route("Delete/id")]
        [HttpDelete]
        public IActionResult Delete(int id) 
        { 
            var data=db.EmpDetails.Find(id);
            db.EmpDetails.Remove(data);
            db.SaveChanges();   
            return Ok("Emp deleted successfully");                          // Delete using api
        }

        [Route("UpdEmp")]
        [HttpPut]
        public IActionResult UpdEmp(Emp emp)
        {
            db.EmpDetails.Update(emp);
            db.SaveChanges();
            return Ok("Emp Updated Successfully");                               // Update using api
        }

        [Route("AddMultipleEmployees")]
        [HttpPost]
        public IActionResult AddMultiple(List<Emp>emps)
        {
            db.EmpDetails.AddRange(emps);
            db.SaveChanges();
            return Ok("Added Multiple Employees");                          // Adding Multiple Employees using api
        }

        [Route("DeleteMultipleEmployees")]
        [HttpDelete]
        public IActionResult DeleteMultiple(List<int>id)
        {
           var data= db.EmpDetails.Where(e=>id.Contains(e.Id)).ToList();
            db.EmpDetails.RemoveRange(data);
            db.SaveChanges();
            return Ok("Deleted Multiple Employees");                            // Deleting Multiple Employees using api
        }

        [Route("SearchByAny")]
        [HttpGet]
        public IActionResult Search(String emp)
        {
            var data=db.EmpDetails.Where(x=>(x.Name.Contains(emp))||x.Dept.Contains(emp)||x.Salary.Equals(emp)||x.Id.ToString().Equals(emp)).ToList();
            return Ok(data);
        }
           
    }
}
