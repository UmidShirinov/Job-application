using JobApplication.Models;
using JobApplication.Service;
using JobApplication.Services;
using Moq; 

namespace JobApplication.Unit.Test
{
    public class ApplicationEvaluateTest
    {


        [Test]
        public void Application_WithUnderAge_TransferrredToAutoRejected()
        {
            //Arrange
            var evaluater = new ApplicationEvaluatot(null);
            var form = new JobApply()
            {
                Applicant= new Applicant() {
                    Age = 17

                },

                
            };

            //action
            var appResult = evaluater.Evalute(form);

            //Assert
            Assert.AreEqual(appResult, ResultEnum.ApplicationResult.AutoRejected);





        }

        [Test]
        public void Application_WithListStack_TransferrredToAutoAccepted()
        {
            //Arrange

            var mockValidator = new Mock<IIdentityValidator>();
            var evaluater = new ApplicationEvaluatot(mockValidator.Object);
            var form = new JobApply()
            {
                Applicant = new Applicant() { Age= 19 },
                TechStackList = new List<string>() { "C#", "RabbitMQ", "MicroSevice", "OOP" },
                YearsOfExperience = 7


            };

            //action
            var appResult = evaluater.Evalute(form);

            //Assert
            Assert.AreEqual(appResult, ResultEnum.ApplicationResult.AutoAccepted);





        }

   

        [Test]
        public void Application_WitListStack_TransferrredToAutoRejected()
        {
            //Arrange
            var evaluater = new ApplicationEvaluatot(null);
            var form = new JobApply()
            {
                Applicant = new Applicant() { Age = 19 },
                TechStackList = new List<string>() { "" },
                YearsOfExperience = 5


            };

            //action
            var appResult = evaluater.Evalute(form);

            //Assert
            Assert.AreEqual(appResult, ResultEnum.ApplicationResult.AutoRejected);





        }
    }
}