using Abp.Application.Services;
using MPACore.PhoneBook.MultiTenancy.Dto;

namespace MPACore.PhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

