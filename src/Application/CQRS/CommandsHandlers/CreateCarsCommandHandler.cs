using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class CreateCarsCommandHandler : IRequestHandler<CreateCarsCommand, Guid[]>
    {
        private readonly ICarRepository _carRepository;

        private readonly ICarImageRepository _carImageRepository;

        private readonly ICarCarImageRepository _carCarImageRepository;

        public CreateCarsCommandHandler(ICarRepository carRepository, ICarImageRepository carImageRepository, ICarCarImageRepository carCarImageRepository)
        {
            _carRepository = carRepository;
            _carImageRepository = carImageRepository;
            _carCarImageRepository = carCarImageRepository;
        }

        public async Task<Guid[]> Handle(CreateCarsCommand request, CancellationToken cancellationToken)
        {
            var carsIdentifiers = new Guid[request.Quantity];
            for (int i = 0; i < request.Quantity; i++)
            {
                var carToCreate = new CarEntity
                {
                    PricePerDay = request.PricePerDay,
                    Brand = request.Brand,
                    Model = request.Model,
                    FuelConsumption = request.FuelConsumption,
                    NumberOfSeats = request.NumberOfSeats,
                    CarTransmissionId = request.CarTransmissionTypeId,
                    BookingPointId = request.BookingPointId
                };
                var car = await _carRepository.CreateAsync(carToCreate);
                carsIdentifiers[i] = car.Id;
            }

            var imagesIdentifiers = new Guid[request.Images.Length];
            for (int i = 0; i < request.Images.Length; i++)
            {
                var image = await _carImageRepository.CreateAsync(
                    new CarImageEntity { Base64Content = request.Images[i] });

                imagesIdentifiers[i] = image.Id;
            }

            var carCarImages = new List<CarCarImageEntity>();

            foreach (var carId in carsIdentifiers)
            {
                foreach (var imageId in imagesIdentifiers)
                {
                    carCarImages.Add(new CarCarImageEntity { CarId = carId, CarImageId = imageId });
                }
            }

            await _carCarImageRepository.CreateRangeAsync(carCarImages);

            return carsIdentifiers;
        }
    }
}