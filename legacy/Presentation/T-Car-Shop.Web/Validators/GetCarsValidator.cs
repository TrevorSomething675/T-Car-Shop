using T_Car_Shop.Infrastructure.Queries.CarQueries;
using FluentValidation;

namespace T_Car_Shop.Web.Validators
{
	public class GetCarsValidator : AbstractValidator<GetCarsQuery>
	{
		public GetCarsValidator() 
		{
			RuleFor(request => request.Filter)
				.NotEmpty().NotNull();
		}
	}
}