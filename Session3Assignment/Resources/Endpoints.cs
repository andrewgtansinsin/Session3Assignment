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

        public static string GetUserByUsername(string username) => $"{baseURL}/user/{username}";

        public static string PostUser() => $"{baseURL}/user";

        public static string DeleteUserByUsername(string username) => $"{baseURL}/user/{username}";
    }
}
