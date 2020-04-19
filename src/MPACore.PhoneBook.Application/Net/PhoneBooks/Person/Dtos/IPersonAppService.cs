using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.Net.PhoneBook.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.Net.PhoneBook
{
   public interface IPersonAppService:IApplicationService
    {
        /// <summary>
        /// 获取人的相关信息,支持分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);
        /// <summary>
        /// 根据ID 获取相关联系人的信息
        /// </summary>
        /// <returns></returns>

        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);


    Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto input);



        /// <summary>
        /// 新增或者更改联系人信息
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);

        /// <summary>
        /// 删除联系人信息
        /// </summary>
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);

    }
}
