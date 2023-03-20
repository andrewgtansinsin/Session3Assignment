using System;
using System.Collections.Generic;
using System.Text;

namespace Session3Assignment.Resources
{
    /// <summary>
    /// Class containing all endpoints used in API tests
    /// </summary>
    public class Endpoints
    {
        //Base URL
        public const string baseURL = "https://petstore.swagger.io/v2";

        public static string GetPetByPetId(long petid) => $"{baseURL}/pet/{petid}";

        public static string PostPet() => $"{baseURL}/pet";

        public static string DeletePetByPetId(long petid) => $"{baseURL}/pet/{petid}";
    }
}
