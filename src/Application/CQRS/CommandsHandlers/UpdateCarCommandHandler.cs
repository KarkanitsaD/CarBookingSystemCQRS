using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
    {
        private readonly ICarRepository _carRepository;

        private readonly ICarCarImageRepository _carCarImageRepository;

        private readonly ICarImageRepository _carImageRepository;

        public UpdateCarCommandHandler(ICarCarImageRepository carCarImageRepository, ICarRepository carRepository, ICarImageRepository carImageRepository)
        {
            _carCarImageRepository = carCarImageRepository;
            _carRepository = carRepository;
            _carImageRepository = carImageRepository;
        }


        public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetAsync(request.CarId);

            if (car == null)
            {
                //404
                throw new Exception();
            }

            car.PricePerDay = request.PricePerDay;
            await _carRepository.UpdateAsync(car);

            var carCarImages = new CarCarImageEntity[request.ImagesIdentifiersToDelete.Length];

            for (int i = 0; i < request.ImagesIdentifiersToDelete.Length; i++)
            {
                var carCarImage = await _carCarImageRepository.GetAsync(request.CarId, request.ImagesIdentifiersToDelete[i]);

                carCarImages[i] = carCarImage ?? throw new Exception();
            }

            await _carCarImageRepository.RemoveRangeAsync(carCarImages);

            var newCarCarImages = new CarCarImageEntity[request.NewImages.Length];
            for (int i = 0; i < request.NewImages.Length; i++)
            {
                var image = await _carImageRepository.CreateAsync(new CarImageEntity
                { Base64Content = request.NewImages[i] });

                newCarCarImages[i] = new CarCarImageEntity { CarId = request.CarId, CarImageId = image.Id };
            }

            await _carCarImageRepository.CreateRangeAsync(newCarCarImages);

            return Unit.Value;
        }
    }
}