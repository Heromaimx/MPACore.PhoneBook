using Abp.Runtime.Validation;
using MPACore.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPACore.PhoneBook.Net.PhoneBook.Dtos
{
    public class GetPersonInput : PagedAndPersonSortDto, IShouldNormalize
    {

        //ViewModel=>dto=>model
        //DTO数据传输对象
      
        public string FilterText { get; set; }
        
        
        public void Normalize()
        {
            if(string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
