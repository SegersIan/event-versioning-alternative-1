using EventDataContracts.Events;
using EventDataContracts.JsonConversion;
using Newtonsoft.Json;

namespace EventDataContracts.Tests
{
    [TestClass]
    public class SerializeClaimSubmittedEventTest
    {
        [TestMethod]
        public void SerializesValidEnumToCorrectString()
        {
            // Arrange
            var claimSubmittedEvent = new ClaimSubmittedEvent()
            {
                SubmissionDate = DateTime.Now,
                SubmissionId = Guid.NewGuid(),
                ClaimType = Types.ClaimType.PersonalInjury
            };
            var settings = new JsonSerializerSettings { Converters = CustomJsonConverters.GetCustomerJsonConverters() };

            // Act
            var jsonContent = JsonConvert.SerializeObject(claimSubmittedEvent, settings);

            // Assert
            Console.WriteLine(jsonContent);
            Assert.IsTrue(jsonContent.Contains("\"ClaimType\":\"PersonalInjury\""));
        }

        [TestMethod]
        public void SerializesNullableEnumToNullValue()
        {
            // Arrange
            var claimSubmittedEvent = new ClaimSubmittedEvent()
            {
                SubmissionDate = DateTime.Now,
                SubmissionId = Guid.NewGuid(),
                ClaimType = null
            };
            var settings = new JsonSerializerSettings { Converters = CustomJsonConverters.GetCustomerJsonConverters() };

            // Act
            var jsonContent = JsonConvert.SerializeObject(claimSubmittedEvent, settings);

            // Assert
            Console.WriteLine(jsonContent);
            Assert.IsTrue(jsonContent.Contains("\"ClaimType\":null"));
        }
    }
}
