using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.PhoneNumber;
using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBook.PhoneNumbers.Dto
{

    [AutoMapFrom(typeof(PhoneNumber))]
    public class PhoneNumberListDto
    {  /// <summary>
       /// 电话号码
       /// </summary>
       /// 


[Required]
[MaxLength(PhoneBookConsts.MaxPhoneNumberLength)]
   
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType type { get; set; }
     
    }
}
