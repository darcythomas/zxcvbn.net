using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace zxcvbn.net
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    class VeryStrongPassword : ValidationAttribute
    {
        public VeryStrongPassword() : base("Password needs to be stronger") { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as String;
            if (password == null) return new ValidationResult("A password is required.");
            if (Zxcvbn.Score(password) == 4)
            {
                return new ValidationResult("Password is not strong enough.");
            }

            return ValidationResult.Success;
        }
    }

}
