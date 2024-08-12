using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using FluentValidation;
using AutoMapper;
using MediatR;
using T_Car_Shop.Application.Services;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Result<Car>>
    {
        private readonly IMapper _mapper;
		private readonly ICarRepository _carRepository;
        private readonly IValidator<GetCarQuery> _validator;
        private readonly IImageService _imageService;
        public GetCarQueryHandler(ICarRepository carRepository, IMapper mapper, 
            IValidator<GetCarQuery> validator, IImageService imageService)
        {
            _carRepository = carRepository;
            _imageService = imageService;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<Result<Car>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new InvalidException(String.Join(" ", validationResult.Errors));

            var specification = new CarSpecification(request.Filter);
            var car = _mapper.Map<Car>(await _carRepository.GetAsync(specification, cancellationToken));
            await _imageService.FillImages(car, specification.ImagesFillingType, cancellationToken);
            
            if(car == null)
				throw new NotFoundException("NOT FOUND!!!");

			return new Result<Car>(car).Success();
        }
    }
}