using RestSharp;
using DemoLearning3.DataModels;
using DemoLearning3.Resources;
using DemoLearning3.Tests.TestData;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoLearning3.Helpers
{
    /// <summary>
    /// Demo class containing all methods for users
    /// </summary>
    public class UserHelper
    {
        /// <summary>
        /// Send POST request to add new user
        /// </summary>
        ///

        public static async Task<UserJsonModel> AddNewUser(RestClient client)
        {
            var newUserData = GenerateUser.demoUser();
            var postRequest = new RestRequest(Endpoints.PostUser());

            //Send Post Request to add new user
            postRequest.AddJsonBody(newUserData);
            var postResponse = await client.ExecutePostAsync<UserJsonModel>(postRequest);

            var createdUserData = newUserData;
            return createdUserData;
        }
    }
}
