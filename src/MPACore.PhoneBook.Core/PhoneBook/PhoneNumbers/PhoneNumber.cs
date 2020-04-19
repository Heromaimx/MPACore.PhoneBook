using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBook.PhoneNumbers
{
    public class PhoneNumber :Entity<long>, IHasCreationTime
    {
        /// <summary>
        /// 电话号码
        /// </summary>
    [Required]
    [MaxLength(11)]
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType type { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }



    }
}
