using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using FluentValidation;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<PagedData<Car>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

		private readonly IValidator<GetCarsQuery> _validator;
        public GetCarsQueryHandler(ICarRepository carRepository, IValidator<GetCarsQuery> validator,
			IMapper mapper, IImageService imageService)
        {
            _carRepository = carRepository;
            _imageService = imageService;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<Car>>> Handle(GetCarsQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
				var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                    return new Result<PagedData<Car>>().Invalid(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

				var specification = new CarSpecification(request.Filter);
				var cars = _mapper.Map<PagedData<Car>>(await _carRepository.GetAllAsync(specification, cancellationToken));

                await _imageService.FillImages(cars, specification.ImagesFillingType, cancellationToken);

                return new Result<PagedData<Car>>(cars).Success();
            }
            catch (Exception ex)
            {
                return new Result<PagedData<Car>>().BadRequest(ex.Message);
            }
        }
    }
}