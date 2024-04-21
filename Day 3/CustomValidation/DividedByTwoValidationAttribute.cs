using System.ComponentModel.DataAnnotations;
namespace Day_3.CustomValidation
{
    public class DividedByTwoValidationAttribute : ValidationAttribute
    {
        int z;
        public DividedByTwoValidationAttribute(int x)
        {
            z = x;
        }
        public override bool IsValid(object? value)
        {
            int x = (int)value;
            if (x % z == 0)
            {
                return true;
            }
            else
                return false;
            return base.IsValid(value);
        }
    }
}
