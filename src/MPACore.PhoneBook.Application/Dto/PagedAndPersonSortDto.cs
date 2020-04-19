using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.Dto
{
   public class PagedAndPersonSortDto:IPagedResultRequest,ISortedResultRequest
    {

        public string Sorting { get; set; }
        [Range(0,int.MaxValue)]
        public int SkipCount { get; set; }

        /// <summary>
        /// 每页显示的最大数量级不能超过500条
        /// </summary>
        [Range(1,500)]

        public int MaxResultCount { get; set; }

    }
}
