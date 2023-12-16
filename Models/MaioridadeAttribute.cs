using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Models
{
    public class MaioridadeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dataNascimento)
            {
                var idade = DateTime.Today.Year - dataNascimento.Year;

                if (idade < 18)
                {
                    return new ValidationResult("O cliente deve ter pelo menos 18 anos.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
