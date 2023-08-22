// using StayHome.SignalR.Hub;
// using StayHome.SignalR.Hubs;
// using Microsoft.AspNetCore.SignalR;
//
// namespace StayHome.SignalR.NotificationService;
//
// public class SignalRNotificationService : ISignalRNotificationService
// {
//     private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;
//
//     public SignalRNotificationService(IHubContext<NotificationHub, INotificationHub> hubContext)
//     {
//         _hubContext = hubContext;
//     }
//
//     // public async Task Send<TNotification>(IEnumerable<Guid> dashUserIds, TNotification notification)
//     // {
//     //     await _hubContext.Clients.Users(ToString(dashUserIds)).NewNotification(notification);
//     // }
//
//     private IEnumerable<string> ToString(IEnumerable<Guid> guids) => guids.Select(guid => guid.ToString());
// }