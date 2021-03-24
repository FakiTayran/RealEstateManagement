using System.Threading.Tasks;
using Abp.Application.Services;
using MyLibraryProject.Authorization.Accounts.Dto;

namespace MyLibraryProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
