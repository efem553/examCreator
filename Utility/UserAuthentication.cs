using examCreator.Models;
using examCreator.Models.Repository.Interface;

namespace examCreator.Utility
{
    public class UserAuthentication
    {
        private IApplicationUserRepository _userRepo;
        public UserAuthentication(IApplicationUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool isUserAuthenticated(HttpContext _context)
        {
            try
            {
                if (_context != null)
                {
                    var userName = _context.Session.GetString("UserName");
                    var LoggedInSecret = _context.Session.GetString("LoggedInSecret");

                    if (_userRepo.GetAll(x => x.UserName == userName).Where(x => x.LoggedInSecret == LoggedInSecret).Count() == 1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
