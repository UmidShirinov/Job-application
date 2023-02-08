using JobApplication.Models;
using static JobApplication.Models.ResultEnum;

namespace JobApplication.Service
{
    public class ApplicationEvaluatot
    {

        private int minAge = 18;
        public ApplicationResult Evalute(JobApply form)
        {
            if (form.Applicant.Age<minAge)
            {
                return ApplicationResult.AutoRejected;
            }
            return ApplicationResult.AutoAccepted;
        }
    }
}
