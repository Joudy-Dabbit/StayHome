using System.Net;
using Neptunee.BaseCleanArchitecture.HttpMessages;

namespace Domain.Errors;

public class DomainError
{
    public class User
    {
        public static HttpMessage NotFound =>
        new (HttpStatusCode.NotFound, "User Not Found", new Dictionary<string, string>()); 
        
        public static HttpMessage EmailOrPasswordWrong =>
        new (HttpStatusCode.BadRequest, "User is Blocked", new Dictionary<string, string>());

        public static HttpMessage Blocked =>
        new (HttpStatusCode.BadRequest, "User is Blocked" , new Dictionary<string, string>());
    }
}