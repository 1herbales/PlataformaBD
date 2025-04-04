using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Plataforma.Core.DTOs;



namespace Plataforma.Infrastructure.Validators
{
    public class DocenteValidator : AbstractValidator<DocenteDTO>
    {
        public DocenteValidator() 
        {
               RuleFor(docente => docente.Nombre)
                .NotNull()
                .Length(4, 50);
               
            RuleFor(docente => docente.EmailInstitucional)
                .NotNull()
                .EmailAddress();

        }
    }
}
