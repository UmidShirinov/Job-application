namespace JobApplication.Models
{
    public class JobApply
    {
        public Applicant? Applicant { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string>? TechStackList { get; set; }
    }
}
