
using Clipkart.Infrastructure.DbContexts;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;

namespace Clipkart.Infrastructure.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private ApplicationDbContext _context;

        public UserLoginRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public bool VerifyUserLogin(User user)
        {
            var resUser = _context.Users.Where(u => u.UserName.Equals(user.UserName));
            return resUser.ToList().Count() == 1;
        }

        public bool Login(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
