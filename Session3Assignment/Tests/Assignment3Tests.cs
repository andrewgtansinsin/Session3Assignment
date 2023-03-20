using Microsoft.VisualStudio.TestTools.UnitTesting;
using Session3Assignment.Helpers;
using Session3Assignment.Resources;
using Session3Assignment.DataModels;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Session3Assignment.Tests
{
    [TestClass]
    public class Assignment3Tests : ApiBaseTest
    {
        private static List<PetJsonModel> petCleanUpList = new List<PetJsonModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in petCleanUpList)
            {
                var deletePetRequest = new RestRequest(Endpoints.GetPetByPetId(data.Id));
                var deletePetResponse = await RestClient.DeleteAsync(deletePetRequest);
            }
        }

        [TestMethod]
        public async Task AssignmentGetPet()
        {
            //Arrange
            //Get Request
            var assignmentGetRequest = new RestRequest(Endpoints.GetPetByPetId(PetDetails.Id));
            petCleanUpList.Add(PetDetails);

            //Act
            //Get Response
            var assignmentGetResponse = await RestClient.ExecuteGetAsync<PetJsonModel>(assignmentGetRequest);

            //Assert
            Assert.IsNotNull(assignmentGetResponse, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.OK, assignmentGetResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(PetDetails.Name, assignmentGetResponse.Data.Name, "Pet Name did not match.");
            Assert.AreEqual(PetDetails.Category.Id, assignmentGetResponse.Data.Category.Id, "Category Id did not match.");
            Assert.AreEqual(PetDetails.Category.Name, assignmentGetResponse.Data.Category.Name, "Category Name did not match.");
            CollectionAssert.AreEqual(PetDetails.PhotoUrls, assignmentGetResponse.Data.PhotoUrls, "PhotoUrls mismatch");
            Assert.IsTrue(Enumerable.SequenceEqual(PetDetails.PhotoUrls, assignmentGetResponse.Data.PhotoUrls), "PhotoUrls mismatch");
            Assert.AreEqual(PetDetails.PhotoUrls.Length, assignmentGetResponse.Data.PhotoUrls.Length, "Photo URLS Length did not match.");
            Assert.AreEqual(PetDetails.PhotoUrls[0], assignmentGetResponse.Data.PhotoUrls[0], "Photo URLS did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Id, assignmentGetResponse.Data.Tags[0].Id, "First Tags Id did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Name, assignmentGetResponse.Data.Tags[0].Name, "First Tags Name did not match.");
            Assert.AreEqual(PetDetails.Tags[1].Id, assignmentGetResponse.Data.Tags[1].Id, "Second Tags Id did not match.");
            Assert.AreEqual(PetDetails.Tags[1].Name, assignmentGetResponse.Data.Tags[1].Name, "Second Tags Name did not match.");
            Assert.AreEqual(PetDetails.Status, assignmentGetResponse.Data.Status, "Status did not match.");
            foreach (PropertyInfo property in PetDetails.Category.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(PetDetails.Category), property.GetValue(assignmentGetResponse.Data.Category), $"Category {property} mismatch");
            }
            Assert.IsTrue(PetDetails.Tags.Intersect(assignmentGetResponse.Data.Tags, new TagsComparer()).Any(), "Tags mismatch");
        }
    }
}
