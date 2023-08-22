// using System.Security.Claims;
// using Microsoft.AspNetCore.SignalR;
//
// namespace StayHome.SignalR;
//
// public class UserIdProvider : IUserIdProvider
// {
//     public string GetUserId(HubConnectionContext connection)
//     {
//         return connection.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier,new (string.Empty,string.Empty)).Value;
//     }
// }