using Day_3.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Day_3.Controllers
{
    public class TestController : Controller
    {

        public IActionResult AddFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFile(int id, IFormFile stdImg)
        {
            string FileName = $"{id.ToString()}.{stdImg.FileName.Split(".").Last()}";
            using (FileStream f1 = new FileStream("wwwroot/images/" + FileName, FileMode.Create))
            {
                stdImg.CopyTo(f1);
            }
            return Content("Doneeee");
        }

        public IActionResult AddDegree()
        {
            return View();
        }

        public IActionResult Add(int id, List<string> names, Dictionary<int, int> degree)
        {
            return Content($"Id = {id} || Length Of Names => {names.Count} || Degree => {degree[3]}");
        }


        public IActionResult IndexEcep()
        {
            int x = int.Parse("lll");
            return View();
        }

        public IActionResult Display()
        {
            int x = int.Parse("40dd");
            return View();
        }

        [LoginFilter]
        public IActionResult CreateLogin()
        {
            return View();
        }


    }
}
