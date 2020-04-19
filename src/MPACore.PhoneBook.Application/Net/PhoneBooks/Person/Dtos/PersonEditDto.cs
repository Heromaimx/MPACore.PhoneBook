using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBook.PhoneNumbers.Dto;

namespace MPACore.PhoneBook.Net.PhoneBook.Dtos
{
    [AutoMapTo(typeof(Person))]
    public class PersonEditDto
    {  /// <summary>
       /// 姓名
       /// </summary>
       /// 
        public int? Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>

        public string EmailAddress { get; set; }
        /// <summary>
        /// 地址信息
        /// </summary>

        public string Address { get; set; }


        public List<PhoneNumberEditDto> PhoneNumbers { get; set; }

    }
}
