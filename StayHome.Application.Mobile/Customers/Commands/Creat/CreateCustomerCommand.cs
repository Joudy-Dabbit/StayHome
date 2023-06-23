using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Security;

namespace StayHome.Application.Mobile.Customers;

public class CreateCustomerCommand
{
    public class Request : IRequest<OperationResponse<Response>>  
    {
        public string FullName { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }  
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string DeviceToken { get; set; }
        public Gender Gender { get;  set; }
        public Guid CityId { get; set; }
    }   
    public class Response : TokenDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public static Expression<Func<Customer, Response>> Selector(string accessToken,
            string refreshToken) => c
            => new()
            {
                Id = c.Id,
                FullName = c.FullName,
                BirthDate = c.BirthDate,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
    }
}