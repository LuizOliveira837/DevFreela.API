using DevFreela.Application.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validations
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .MinimumLength(10)
                .WithMessage("O titulo tem que ter no minimo 10 caracteres e no maximo 30 caracteres");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .MinimumLength(10)
                .WithMessage("A descrição tem que ter no minimo 10 caracteres e no maximo 30 caracteres");

        }
    }
}
