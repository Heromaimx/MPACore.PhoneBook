using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using MPACore.PhoneBook.Net.PhoneBook.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.AutoMapper;
using Abp.UI;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.Net.PhoneBook
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {

            if (input.PersonEditDto.Id.HasValue)
            {
                //有值说明是更改

                await UpdatePersonAsync(input.PersonEditDto);

            }
            else
            {
                //无值说明是创建新增

                await CreatePersonAsync(input.PersonEditDto);

            }


        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("该联系人已经消失在数据库中，无法二次删除");
            }

            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {

            var query=_personRepository.GetAll();

            //改造
            //var query2 = _personRepository.GetAll().Include(PhoneNumber);
            var query3 = _personRepository.GetAllIncluding(a=>a.PhoneNumbers);


            var personCount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();


            //var listDto = new List<PersonListDto>();
            //foreach (var person in listDto)
            //{
            //    var dto = new PersonListDto();
            //    dto.EmailAddress = person.EmailAddress;
            //}
            var dtos = persons.MapTo<List<PersonListDto>>();
            return new PagedResultDto<PersonListDto>(personCount, dtos);

        }


        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            var person = await _personRepository.GetAsync(input.Id.Value);

            //改造
            var person2 = await _personRepository.GetAllIncluding(a=>a.PhoneNumbers).FirstOrDefaultAsync(a=>a.Id==input.Id.Value);

            return person.MapTo<PersonListDto>();

        }


        protected async Task UpdatePersonAsync(PersonEditDto input) 
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);

            //var person= new Person();
            //person.EmailAddress = input.EmailAddress;
            //person.Address = input.Address;

            input.MapTo(entity);
            await _personRepository.UpdateAsync(entity);
        }


        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            _personRepository.Insert(input.MapTo<Person>());
            
        }

        public async Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto input)
        {
            var output = new GetPersonForEditOutput();

            PersonEditDto personEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAsync(input.Id.Value);

                //改造
                var entity2 = await _personRepository.GetAllIncluding(a => a.PhoneNumbers).FirstOrDefaultAsync(a => a.Id == input.Id.Value);



                personEditDto = entity.MapTo<PersonEditDto>();




            }
            else {
                personEditDto = new PersonEditDto();
            }
            output.Person = personEditDto;

            return output;
        }
    }
}
