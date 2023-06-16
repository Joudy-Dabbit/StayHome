using Microsoft.AspNetCore.Hosting;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Settings;

public class GetProfileImagesHandler : IRequestHandler<GetProfileImagesQuery.Request, 
    OperationResponse<List<string>>>
{
    private readonly string _wwwroot;

    public GetProfileImagesHandler(IWebHostEnvironment webHostEnvironment)
    {
        _wwwroot = webHostEnvironment.WebRootPath;
    }

    public async Task<OperationResponse<List<string>>> HandleAsync(GetProfileImagesQuery.Request request,
        CancellationToken cancellationToken = new CancellationToken())
        => await Task.FromResult(new DirectoryInfo(Path.Combine(_wwwroot, "ProfileImage"))
            .EnumerateFiles()
            .Select(x => Path.Combine("ProfileImage", x.Name)).ToList());
}    