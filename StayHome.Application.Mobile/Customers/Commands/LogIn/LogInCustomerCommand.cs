using System.ComponentModel;
using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shared;

namespace StayHome.Application.Mobile.Customers;

public class LogInCustomerCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        [DefaultValue("customer@gmail.com")] public string Email { get; set; }
        [DefaultValue("1234")] public string password { get; set; }
    }
    public class Response : TokenDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        

        public static Expression<Func<Customer, Response>> Selector(string accessToken, string refreshToken) => c
            => new()
            {
                Id = c.Id,
                FullName = c.FullName,
                BirthDate = c.BirthDate,
                PhoneNumber = c.PhoneNumber,
                ImageUrl = c.ImageUrl,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
    }
}