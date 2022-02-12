using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.Entities;
using Challenge.Backend.Domain.ICommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Application.Validation
{
    public class MovieOrSerieValidator : AbstractValidator<CreateMovieRequestDto>
    {
        private readonly IGenericsRepository genericsRepository;

        public MovieOrSerieValidator(IGenericsRepository genericsRepository)
        {
            this.genericsRepository = genericsRepository;

            RuleFor(e => e.Image).NotNull().NotEmpty().WithMessage("El campo imagen no puede estar vacio");
            RuleFor(e => e.Title).NotNull().NotEmpty().WithMessage("El campo titulo no puede quedar vacio");
            RuleFor(e => e.Title).MaximumLength(50).WithMessage("Cantidad de caracteres del titulo excedido");
            RuleFor(e => e.CreationDate).NotNull().NotEmpty().WithMessage("El campo fecha de creacion no puede quedar vacio");
           // RuleFor(e => e.CreationDate);
            RuleFor(e => e.Rating).NotNull().NotEmpty().WithMessage("El campo calificacion no puede estar vacio");
            RuleFor(e => e.Rating).GreaterThan(0).LessThan(6).WithMessage("La calificacion debe ser de 1 a 5");
            RuleFor(e => e.GenreId).Must(ExistGenre).WithMessage("Genero no valido");

            RuleForEach(e => e.Characters).Must(ExistCharacter).WithMessage("Personaje no valido");
        }

        private bool ExistGenre(int genreId)
        {
            Genre genre = genericsRepository.Exists<Genre>(genreId);
            if (genre == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ExistCharacter(int characterId)
        {
            Character character = genericsRepository.Exists<Character>(characterId);
            if (character == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
