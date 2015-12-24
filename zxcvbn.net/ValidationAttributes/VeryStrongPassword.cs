using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace zxcvbn.net
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class VeryStrongPassword : ValidationAttribute, IClientValidatable
    {
        public VeryStrongPassword() : base("Password needs to be stronger") { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;
            if (password == null) return new ValidationResult("A password is required.");
            if (Zxcvbn.Score(password) < 4)
            {
                return new ValidationResult("Password is not strong enough.");
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule VeryStrongPasswordRule = new ModelClientValidationRule();
            VeryStrongPasswordRule.ErrorMessage = errorMessage;
            VeryStrongPasswordRule.ValidationType = "VeryStrongPassword"; // This is the name the jQuery adapter will use
            VeryStrongPasswordRule.ValidationParameters.Add("param", "VeryStrongPassword");

            yield return VeryStrongPasswordRule;
        }
    }

}
