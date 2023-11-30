using Job_Portal_System.Model;

namespace Job_Portal_System.Repository
{
    public interface IHRRepository
    {
        public void UpdateHR(HRModel hrModel);
        public void  Insert(JobModel jobModel);
        public void UpdateJob(JobModel jobModel);
        public List<AppliedDetailsModel> Get(long HRId);


    }
}
