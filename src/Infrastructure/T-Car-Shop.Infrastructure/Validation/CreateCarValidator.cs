using T_Car_Shop.Infrastructure.Commands.CarCommands;
using FluentValidation;

namespace T_Car_Shop.Infrastructure.Validation
{
    public class CreateCarValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarValidator()
        {
            RuleFor(command => command.Car).NotEmpty().NotNull()
                .WithMessage("Car should not be empty.")
                .WithErrorCode("403");
        }
    }
}