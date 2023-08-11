using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Orders;

public class AddPassengerOrderHandler : IRequestHandler<AddPassengerOrderCommand.Request,
    OperationResponse>
{
    private readonly IHttpService _httpService;
    private readonly IUserRepository _repository;
    private readonly IOrderRepository _orderRepository;

    public AddPassengerOrderHandler(IHttpService httpService,
        IUserRepository repository, IOrderRepository orderRepository)
    {
        _httpService = httpService;
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public async Task<OperationResponse> HandleAsync(AddPassengerOrderCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var user = await _orderRepository.TrackingQuery<Customer>()
            .Where(c => c.Id == _httpService.CurrentUserId!.Value)
            .FirstAsync(cancellationToken);

        var deliveryCoast = await _orderRepository.DeliveryCoast(request.Source.AreaId,
            request.Destination.AreaId);

        var source = new AddressOrder(request.Source.Street, request.Source.Additional,
            request.Source.AreaId);
        _repository.Add(source);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        var destination = new AddressOrder(request.Destination.Street, request.Destination.Additional,
            request.Destination.AreaId);
        _repository.Add(destination);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        var order = user.AddPassengerOrder(request.NumberOfPassenger,
            request.ScheduleDate, deliveryCoast, request.Note,
            destination.Id, source.Id);

        _repository.Add(order);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}