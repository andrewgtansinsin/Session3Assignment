using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using DemoLearning3.DataModels;

namespace DemoLearning3.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public UserJsonModel UserDetails { get; set; }

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
