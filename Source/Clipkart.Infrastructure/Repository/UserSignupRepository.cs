
using Clipkart.Infrastructure.DbContexts;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;

namespace Clipkart.Infrastructure.Repository
{
    public class UserSignupRepository : IUserSignupRepository
    {
        private ApplicationDbContext _context;

        public UserSignupRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool SignupUser(SignupUser signupUser)
        {
            try
            {
                _context.SignupUsers.Add(signupUser);
                _context.SaveChanges();
                return true;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Exception occured while commiting the user data to database.");
                Console.WriteLine(exception);
                return false;
            }
        }
    }
}
