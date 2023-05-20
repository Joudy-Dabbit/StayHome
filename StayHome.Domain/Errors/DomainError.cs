using System.Net;
using Neptunee.BaseCleanArchitecture.HttpMessages;

namespace Domain.Errors;

public class DomainError
{
    public class User
    {
        public static HttpMessage NotFound =>
        new (HttpStatusCode.NotFound, "User Not Found"); 
        
        public static HttpMessage EmailOrPasswordWrong =>
        new (HttpStatusCode.BadRequest, "User is Blocked");

        public static HttpMessage Blocked =>
        new (HttpStatusCode.BadRequest, "User is Blocked");
        //
        // public static HttpMessage EmailIsRequired => new(
        //     HttpStatusCode.BadRequest, "Email is required ");        
        public static HttpMessage EmailNotExist(string email) => 
            new(HttpStatusCode.BadRequest, $"Email: {email} is not exist");    
        
        public static HttpMessage EmailAlreadyUsed(string email) => 
            new(HttpStatusCode.BadRequest, $"Email: {email} is Already Used");
    }
}