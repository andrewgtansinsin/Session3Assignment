using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3Assignment.DataModels;

namespace Session3Assignment.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public PetJsonModel PetDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }

    }
}
