using Session3Assignment.DataModels;
using System;

namespace Session3Assignment.Tests.TestData
{
    public class GeneratePet
    {
        public static PetJsonModel demoPet()
        {
            return new PetJsonModel
            {
                Id = 88,
                Category = new Category
                {
                    Id = 8008,
                    Name = "Persian Cat"
                },
                Name = "Garfield",
                PhotoUrls = new string[] { "https://images.app.goo.gl/KvPjfUZwUKfeJ34M8" },
                Tags = new Tags[] { new Tags {
                    Id = 2023,
                    Name = "Andrew Tansinsin"
                },new Tags {
                    Id = 2024,
                    Name = "Andrew Tansinsin"
                }
                },
                Status = "available"
            };
        }
    }
}
