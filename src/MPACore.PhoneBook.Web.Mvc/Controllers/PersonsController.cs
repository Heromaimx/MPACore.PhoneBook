using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPACore.PhoneBook.Controllers;
using MPACore.PhoneBook.Net.PhoneBook;
using MPACore.PhoneBook.Net.PhoneBook.Dtos;

namespace MPACore.PhoneBook.Web.Controllers
{
    public class PersonsController : PhoneBookControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonsController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        public async Task<IActionResult> Index(GetPersonInput input)
        {
            var dtos = await _personAppService.GetPagedPersonAsync(input);

            return View(dtos);
        }
    }
}