using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.Account;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using FluentValidation;
using MediatR;
using AutoMapper;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.DataAccess;

namespace T_Car_Shop.Infrastructure.Commands.AccountCommands
{
	public class UpdateAccountDataCommandHandler : IRequestHandler<UpdateAccountDataCommand, Result<User>>
	{
		private readonly IMapper _mapper;
		private readonly IAccountService _accountService;
		private readonly IUserRepository _userRepository;
		private readonly IValidator<AccountUserRequest> _validator;
		public UpdateAccountDataCommandHandler(IAccountService accountService, IValidator<AccountUserRequest> validator,
			IMapper mapper, IUserRepository userRepository)
		{
			_userRepository = userRepository;
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

			user = _mapper.Map<User>(await _userRepository.UpdateAsync(_mapper.Map<UserEntity>(user), cancellationToken));
			return new Result<User>(user);
		}
	}
}
