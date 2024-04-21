using Day_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_3.Services
{
    // CRUD

    public class DepartmentRepo
    {
        ITIDBContext db = new ITIDBContext();

        public List<Department> GetAll()
        {
            return db.Departments.Where(a => a.Status == true).ToList();
        } 

        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.Id == id);
        }

        internal object GetByName(string name)
        {
            return db.Departments.SingleOrDefault(a => a.Name == name);
        }

        public void Add(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }

        public void Update(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.Departments.SingleOrDefault(a => a.Id == id);
            model.Status = false;
            //db.Departments.Remove(model);
            db.SaveChanges();
        }

     
    }
}
