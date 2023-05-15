namespace StayHome.Application.Dashboard.Core.Abstractions.Http;

public interface IHttpService
{
    Guid? CurrentUserId { get; }
}