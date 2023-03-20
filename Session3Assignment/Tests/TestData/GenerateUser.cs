using DemoLearning3.DataModels;
using System;

namespace DemoLearning3.Tests.TestData
{
    public class GenerateUser
    {
        public static UserJsonModel demoUser()
        {
            return new UserJsonModel
            {
                Username = $"csvDemoUser{DateTime.Now.ToString("ddHHmmss")}",
                FirstName = "Alphinaud",
                LastName = "Leveilleur",
                Email = "csvDemoUser0031@admin.com",
                Password = "aBc1234",
                Phone = "43039501",
                UserStatus = 1
            };
        }
    }
}
