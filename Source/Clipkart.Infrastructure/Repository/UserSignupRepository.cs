using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clipkart.Infrastructure.DbContexts;
using ClipKart.Core.Interfaces.UserLogin;

namespace Clipkart.Infrastructure.Repository
{
    public class UserSignupRepository : IUserSignupRepository
    {
        private ApplicationDbContext _context;

        public UserSignupRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
    }
}
