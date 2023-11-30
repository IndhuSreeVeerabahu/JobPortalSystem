namespace Job_Portal_System.Model
{
    public class AppliedDetailsModel
    {
        public long UserId { get; set; }
        public long HRId { get; set; }
        public long JobId { get; set; }
        public DateTime UserAppliedOn { get; set; }
        public string RecruitmentStatus { get; set; }
    }
}
