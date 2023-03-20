using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoLearning3.Helpers;
using DemoLearning3.Resources;
using DemoLearning3.DataModels;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoLearning3.Tests
{
    [TestClass]
    public class Demo3Tests : ApiBaseTest
    {
        private static List<UserJsonModel> userCleanUpList = new List<UserJsonModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            UserDetails = await UserHelper.AddNewUser(RestClient);
        }

        [TestMethod]
        public async Task DemoGetUser()
        {
            //Arrange
            var demoGetRequest = new RestRequest(Endpoints.GetUserByUsername(UserDetails.Username));
            userCleanUpList.Add(UserDetails);

            //Act
            var demoResponse = await RestClient.ExecuteGetAsync<UserJsonModel>(demoGetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, demoResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(UserDetails.Username, demoResponse.Data.Username);
            Assert.AreEqual(UserDetails.FirstName, demoResponse.Data.FirstName);
            Assert.AreEqual(UserDetails.LastName, demoResponse.Data.LastName);
            Assert.AreEqual(UserDetails.Email, demoResponse.Data.Email);
            Assert.AreEqual(UserDetails.Password, demoResponse.Data.Password);
            Assert.AreEqual(UserDetails.Phone, demoResponse.Data.Phone);
            Assert.AreEqual(UserDetails.UserStatus, demoResponse.Data.UserStatus);
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in userCleanUpList)
            {
                var deleteUserRequest = new RestRequest(Endpoints.GetUserByUsername(data.Username));
                var deleteUserResponse = await RestClient.DeleteAsync(deleteUserRequest);
            }
        }
    }
}
