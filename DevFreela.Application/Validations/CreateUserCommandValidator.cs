using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Core.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Por favor, coloque um Email valido");

            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter pelo menos " +
                "8 Caracteres" +
                "1 Numero" +
                "1 Letra Maiuscula" +
                "1 Letra Minuscula" +
                "1 Caracter Especial");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatorio");
        }


        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

    }
}
