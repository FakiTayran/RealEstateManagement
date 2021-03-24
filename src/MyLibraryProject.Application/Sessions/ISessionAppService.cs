using System.Threading.Tasks;
using Abp.Application.Services;
using MyLibraryProject.Sessions.Dto;

namespace MyLibraryProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
