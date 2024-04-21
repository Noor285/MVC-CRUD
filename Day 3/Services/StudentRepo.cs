using Day_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_3.Services
{
    // CRUD

    public class StudentRepo
    {
        ITIDBContext db = new ITIDBContext();

        public List<Student> GetAll()
        {
            return db.Students.Include(a => a.Department).Where(a => a.Department.Status == true).ToList();
        }

        public Student GetById(int id) 
        {
            return db.Students.SingleOrDefault(a => a.Id == id);
        }

        public void Add(Student student) 
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.Students.SingleOrDefault(a => a.Id == id);
            db.Students.Remove(model);
            db.SaveChanges();
        }

    }
}
