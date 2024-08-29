using T_Car_Shop.Infrastructure.Queries.CarQueries;
using FluentValidation;

namespace T_Car_Shop.Web.Validators
{
	public class GetCarValidator : AbstractValidator<GetCarQuery>
	{
		public GetCarValidator()
		{
			RuleFor(request => request.Filter)
				.NotEmpty().NotNull()
				.DependentRules(() =>
				{
					RuleFor(request => request.Filter.Id)
						.NotEmpty()
						.NotNull();
				});
		}
	}
}