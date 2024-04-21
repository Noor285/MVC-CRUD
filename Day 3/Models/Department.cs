using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_3.Models
{
    [Table("Department")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote("CheckDeptId", "Department")]
        public int Id { get; set; }

        [Remote("CheckDeptName", "Department", AdditionalFields = "DeptId")]
        public string Name { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
