using Challenge.Backend.Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Application.Validation
{
    public class CharacterValidator : AbstractValidator<CharacterRequestDto>
    {
        public CharacterValidator()
        {
            RuleFor(e => e.Image).NotNull().NotEmpty().WithMessage("El campo imagen no puede estar vacio");
            RuleFor(e => e.Name).NotNull().NotEmpty().WithMessage("El campo nombre no puede quedar vacio");
            RuleFor(e => e.Name).MaximumLength(50).WithMessage("Cantidad de caracteres del nombre excedido");
            RuleFor(e => e.Age).NotNull().NotEmpty().WithMessage("El campo edad no puede quedar vacio");
            RuleFor(e => e.Age).GreaterThan(-1).WithMessage("La edad debe ser mayor o igual que cero");
            RuleFor(e => e.Weight).NotNull().NotEmpty().WithMessage("El campo peso no puede quedar vacio");
            RuleFor(e => e.Weight).GreaterThan(-1).WithMessage("El peso debe ser mayor o igual que cero");
            RuleFor(e => e.History).NotNull().NotEmpty().WithMessage("El campo historia no puede quedar vacio");

        }
    }
}
