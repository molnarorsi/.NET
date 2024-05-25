using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Application.AddSnake
{
    public class AddSnakeValidator : AbstractValidator<AddSnakeRequest>
    {
        public AddSnakeValidator() {
            this.RuleFor(request => request.Name).NotEmpty();
            this.RuleFor(request => request.Color).NotEmpty();
            this.RuleFor(request => request.Point).NotEmpty();
        }

    }
}
