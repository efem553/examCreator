namespace examCreator.Models.Repository.Interface
{
    public interface IApplicationUserRepository:IRepository<ApplicationUser>
    {
        public void Update (ApplicationUser applicationUser);
    }
}
