using JobApplication.Models;
using System.Linq;
using static JobApplication.Models.ResultEnum;

namespace JobApplication.Service
{
    public class ApplicationEvaluatot
    {

        private int minAge = 18;
        private int autoAcceptedYearOfExperience=6;
        private List<string> techStackList = new() { "C#", "RabbitMQ", "MicroSevice", "OOP", "WEB API" };
        public ApplicationResult Evalute(JobApply form)
        {
            if (form.Applicant.Age<minAge)
            {
                return ApplicationResult.AutoRejected;
            }
            var sr = GetStackSimilarityRate(form.TechStackList);
            if (sr<25)
                return ApplicationResult.AutoRejected;
            if (sr > 75 && autoAcceptedYearOfExperience>form.YearsOfExperience)
                return ApplicationResult.AutoAccepted;

            
            return ApplicationResult.AutoAccepted;
        }
        private double GetStackSimilarityRate(List<string> techStacks)
        {
            var matchCount =
                techStacks
                    .Where(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase))
                    .Count();
            var  matchPercent =(double)  (matchCount*100/techStackList.Count);

            return matchPercent;
        }
    }
}
