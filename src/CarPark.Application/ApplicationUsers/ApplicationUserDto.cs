using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Application.ApplicationUsers
{
    public class BaseApplicationUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ApplicationUserDto : BaseApplicationUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
    }
}
