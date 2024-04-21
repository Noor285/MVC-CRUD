using Day_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Day_3.CustomFilters;
using Day_3.Services;

namespace Day_3.Controllers
{
    [MyExceptionFilter]
    public class StudentController : Controller
    {

        StudentRepo studentRepo = new StudentRepo();
        DepartmentRepo departmentRepo = new DepartmentRepo();

        public IActionResult Index()
        {
           // var model = db.Students.Include(a => a.Department).ToList();
            return View(studentRepo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = departmentRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if(!ModelState.IsValid)
            {
                studentRepo.Add(std);
                return RedirectToAction("Index");
            }

            ViewBag.depts = departmentRepo.GetAll();
            return View(std);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();

            Student model = studentRepo.GetById(id.Value); //.Students.FirstOrDefault(a => a.Id == id);
            if(model == null)
                return NotFound();
            ViewBag.depts = departmentRepo.GetAll();
            return View(model);
             
        }

        [HttpPost]
        public IActionResult Update(Student std)
        {
            studentRepo.Update(std);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest("You must provide data for id");
            
            //var model = studentRepo.GetById(id.Value); //.Students.FirstOrDefault(a => a.Id == id.Value);
            //if (model == null)
            //    return NotFound();
           
            studentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}
