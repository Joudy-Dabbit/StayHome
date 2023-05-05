// using System.Linq.Expressions;
// using Domain.Entities;
// using Neptunee.BaseCleanArchitecture.OResponse;
// using Neptunee.BaseCleanArchitecture.Requests;
// using StayHome.Contracts.Shared;
//
// namespace StayHome.Application.Mobile.Customers.Commands;
//
// public class CreateCustomerCommand
// {
//     public class Request : IRequest<OperationResponse<Response>>  
//     {
//         public string FirstName { get; set; }
//         public string LastName { get; set; }
//         public string Email { get; set; }  
//         public string Password { get; set; }  
//         public string PhoneNumber { get; set; }
//         public DateOnly? BirthDate { get; set; }
//         public string DeviceToken { get; set; }
//     }   
//     public class Response : TokenDto
//     {
//         public Guid Id { get; set; }
//         public string FirstName { get; set; }
//         public string LastName { get; set; }
//         public string PhoneNumber { get; set; }
//         public string ImageUrl { get; set; }
//         public string Email { get; set; }
//         public DateOnly? BirthDate { get; set; }
//
//         public static Expression<Func<Customer, Response>> Selector(string accessToken) => c
//             => new()
//             {
//                 Id = c.Id,
//                 FirstName = c.FirstName,
//                 LastName = c.LastName,  
//                 BirthDate = c.BirthDate,
//                 Email = c.Email,
//                 PhoneNumber = c.PhoneNumber,
//                 AccessToken = accessToken,
//                 ImageUrl = c.ImageUrl
//             };
//     }
// }