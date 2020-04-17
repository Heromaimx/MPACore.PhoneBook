using System.Collections.Generic;
using MPACore.PhoneBook.Roles.Dto;

namespace MPACore.PhoneBook.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
