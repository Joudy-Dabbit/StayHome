using System.Net;
using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Application.Dashboard.Core.Abstractions;

namespace StayHome.Application.Mobile.Customers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand.Request, OperationResponse<CreateCustomerCommand.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public CreateCustomerHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<OperationResponse<CreateCustomerCommand.Response>> HandleAsync(CreateCustomerCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var profileImage = await _fileService.Upload(request.ImageFile);

        var customer = new Customer(request.FullName, request.PhoneNumber,
             profileImage, request.Email, request.BirthDate, request.DeviceToken, request.CityId);
        
        var identityResult = await _userRepository.AddWithRole(customer, StayHomeRoles.Customer, request.Password);
        
        if(!identityResult.Succeeded)
            return identityResult.ToOperationResponse<CreateCustomerCommand.Response>();
        
        var accessToken = _userRepository.GenerateAccessToken(customer, 
            new List<string>(){StayHomeRoles.Customer.ToString()}, DateTime.UtcNow.AddMinutes(10));
        var refreshToken = await _userRepository.GenerateRefreshToken(customer.Id);
        
        if (!refreshToken.IsSucceded)
            return OperationResponse.WithBadRequest(refreshToken.ErrorMessage).ToResponse<CreateCustomerCommand.Response>();
        
        return await _userRepository.GetAsync(customer.Id, 
            CreateCustomerCommand.Response.Selector(accessToken, refreshToken.Token));
    }
}