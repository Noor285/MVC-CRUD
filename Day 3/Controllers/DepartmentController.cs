using Day_3.Models;
using Day_3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_3.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepo departmentRepo = new DepartmentRepo();

        public IActionResult Index()
        {
            var model = departmentRepo.GetAll(); //.Departments.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept )
        {
            if(ModelState.IsValid)
            {
                departmentRepo.Add(dept); // Add to copy of database
                // db.SaveChanges(); // Add to database
                try
                {
                    departmentRepo.Add(dept);

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(dept);
                }
                return RedirectToAction("Index");
            }
                return View(dept);           
        }



        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest("You must provide data for id");
            var model = departmentRepo.GetById(id.Value); //db.Departments.FirstOrDefault(a => a.Id == id.Value);
            if (model == null)
                return NotFound();

            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest("You must provide data for id");

            //var model =  db.Departments.FirstOrDefault(a => a.Id == id.Value);
            //if (model == null)
            //    return NotFound();
            //db.Departments.Remove(model);
            //db.SaveChanges();

            departmentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            //var model = db.Departments.FirstOrDefault(a => a.Id == id.Value);
            var model = departmentRepo.GetById(id.Value);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Department department, int? id)
        {
            //if (department.Id != 0 && department.Name != null)
            //{
            //    db.Departments.Update(department);
            //    db.SaveChanges();

            department.Id = id.Value;
            departmentRepo.Update(department);
            return RedirectToAction("Index");
    }



        public IActionResult CheckDeptId(int DeptId)
        {
            //var model=db.Departments.FirstOrDefault(a=>a.DeptId==DeptId);
            var model = departmentRepo.GetById(DeptId);
            if (model != null)
            {
                return Json(false);
                //int x = db.Departments.Max(a => a.DeptId);
                //return Json($"you can't use {DeptId} u can use {x+1}");
            }
            else
                return Json(true);
        }
        public IActionResult CheckDeptName(string Name, int DeptId)
        {
            //var model = db.Departments.FirstOrDefault(a=>a.Name==Name);
            var model = departmentRepo.GetByName(Name);
            if (model != null)
            {
                return Json(true);
            }
            else
                return Json("try use" + Name + DeptId.ToString());
        }


    }
}
