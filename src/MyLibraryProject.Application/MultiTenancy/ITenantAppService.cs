using Abp.Application.Services;
using MyLibraryProject.MultiTenancy.Dto;

namespace MyLibraryProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

