using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Domain.ApplicationUsers
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }

    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(DbContext _context) : base(_context)
        {

        }
    }
}
