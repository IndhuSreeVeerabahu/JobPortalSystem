using Job_Portal_System.Model;

namespace Job_Portal_System.Repository
{
    public interface IUserRepository
    {
        public void Insert(UserModel userModel);
        public void Update(UserModel userModel);
        public List<JobModel> GetJob();
        public List<AppliedDetailsModel> GetApplied(long userId);

    }
}
