using RestSharp;
using Session3Assignment.DataModels;
using Session3Assignment.Resources;
using Session3Assignment.Tests.TestData;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Session3Assignment.Helpers
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
