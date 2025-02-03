using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.Account;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using FluentValidation;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AccountCommands
{
	public class UpdateAccountDataCommandHandler : IRequestHandler<UpdateAccountDataCommand, Result<User>>
	{
		private readonly IMapper _mapper;
		private readonly IAccountService _accountService;
		private readonly IValidator<AccountUserRequest> _validator;
		public UpdateAccountDataCommandHandler(IAccountService accountService, IValidator<AccountUserRequest> validator,
			IMapper mapper)
		{
			_accountService = accountService;
			_validator = validator;
			_mapper = mapper;
		}
		public async Task<Result<User>> Handle(UpdateAccountDataCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.AccountUserData, cancellationToken);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult.Errors.ToList());

			var user = _mapper.Map<User>(request.AccountUserData);
			//var updatedUser = await _accountService.UpdateAccountDataAsync(user, cancellationToken);

			return new Result<User>(user);
		}
	}
}
