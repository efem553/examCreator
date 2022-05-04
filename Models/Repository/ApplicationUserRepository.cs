using examCreator.Models.Data;
using examCreator.Models.Repository.Interface;

namespace examCreator.Models.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>,IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser applicationUser)
        {
            try
            {
                if (applicationUser !=null)
                _db.ApplicationUser.Update(applicationUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
