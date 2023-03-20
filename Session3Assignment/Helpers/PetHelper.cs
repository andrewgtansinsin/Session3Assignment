using RestSharp;
using Session3Assignment.DataModels;
using Session3Assignment.Resources;
using Session3Assignment.Tests.TestData;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Session3Assignment.Helpers
{
    /// <summary>
    /// Class containing all methods for pets
    /// </summary>
    public class PetHelper
    {
        /// <summary>
        /// Send POST request to add new pet
        /// </summary>
        ///

        public static async Task<PetJsonModel> AddNewPet(RestClient client)
        {
            var newPetData = GeneratePet.demoPet();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new pet
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<PetJsonModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
