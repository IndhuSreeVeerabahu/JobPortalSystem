using Job_Portal_System.Model;

namespace Job_Portal_System.Repository
{
    public interface IAdminRepository
    {
        void Insert(UserModel userModel);
        void Update(UserModel userModel);
        void Insert(HRModel hrModel);
        void Update(HRModel hrModel);
        List<AppliedDetailsModel> get();

        List<UserModel> GetUser();
        List<HRModel> GetHR();
        List<JobModel> GetJob();
    }
}
