using T_Car_Shop.Core.Models.Web.Account;
using FluentValidation;

namespace T_Car_Shop.Web.Validators
{
	public class UpdateAccountDataValidator : AbstractValidator<AccountUserRequest>
	{
		public UpdateAccountDataValidator()
		{
			RuleFor(request => request.Id).NotNull().NotEmpty();

			RuleFor(request => request)
				.Must(request => !string.IsNullOrEmpty(request.UserName) || !string.IsNullOrEmpty(request.Password))
				.WithMessage("Empty account data");

			When(request => request.Password != null, () =>
			{
				RuleFor(request => request.Password)
					.NotNull().NotEmpty()
					.DependentRules(() =>
					{
						RuleFor(request => request.NewPassword)
							.NotNull()
							.NotEmpty()
							.Equal(request => request.ConfirmNewPassword)
							.WithMessage("New password and confirmation password must match.");

						RuleFor(request => request.ConfirmNewPassword)
							.NotNull()
							.NotEmpty();
					});
			});

			When(request => request.UserName != null, () =>
			{
				RuleFor(request => request.UserName)
					.NotEmpty().NotNull()
					.DependentRules(() =>
					{
						RuleFor(request => request.NewUserName)
							.NotNull().NotEmpty();
					});
			});
		}
	}
}
