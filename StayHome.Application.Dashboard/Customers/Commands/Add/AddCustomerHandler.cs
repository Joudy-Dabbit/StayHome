using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand.Request,
    OperationResponse<GetAllCustomerQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public AddCustomerHandler(IUserRepository userRepository, IFileService fileService)
    {
        _userRepository = userRepository;
        _fileService = fileService;
    } 
    public async Task<OperationResponse<GetAllCustomerQuery.Response>> HandleAsync(AddCustomerCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        if(await _userRepository.IsEmailExist<Customer>(request.PhoneNumber))
            return DomainError.User.EmailAlreadyUsed(request.Email);

        var customer = new Customer(request.FullName,
            request.PhoneNumber, request.Email,   
            request.BirthDate, request.CityId);
        
        customer.AddAddress(request.Address.Name, request.Address.AreaId, 
            request.Address.HouseNumber, request.Address.Street,
            request.Address.Additional, request.Address.Floor);
        
        var identityResult = await _userRepository.AddWithRole(customer, StayHomeRoles.Customer, request.Password);
        
        if(!identityResult.Succeeded)
            return identityResult.ToOperationResponse<GetAllCustomerQuery.Response>();

        return await _userRepository.GetAsync(customer.Id, GetAllCustomerQuery.Response.Selector());    
    }
}