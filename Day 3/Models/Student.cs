using Day_3.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_3.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "*")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "max characters=20 and min characters=3")]
		public string Name { get; set; }

		[Range(20, 30)]
        // [DividedByTwoValidationAttribute(2 , ErrorMessage ="age must divided by two")]
        public int Age { get; set; }

		[RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
		public string Email { get; set; }

		[ForeignKey("Department")]
        public int DeptNo { get; set; }
        public Department Department { get; set; }
    }
}
