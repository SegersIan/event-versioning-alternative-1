using EventDataContracts.Events;
using EventDataContracts.JsonConversion;
using Newtonsoft.Json;

namespace EventDataContracts.Tests
{
    [TestClass]
    public class DeserializeClaimSubmittedEventTest
    {
        [TestMethod]
        public void CanDeserializeWithSupportedEnumValue()
        {
            // Arrange
            var jsonContent = @"
                {
                    ""SubmissionDate"": ""2024-01-10T00:00:00Z"",
                    ""SubmissionId"": ""8f8f9970-72a7-44aa-b5e8-4d46b0afb7d6"",
                    ""ClaimType"": ""Property""
                }
            ";
            var settings = new JsonSerializerSettings
            {
                Converters = CustomJsonConverters.GetCustomerJsonConverters()
            };

            // Act
            var claimSubmittedEvent = JsonConvert.DeserializeObject<ClaimSubmittedEvent>(jsonContent, settings);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.IsTrue(claimSubmittedEvent.ClaimType.HasValue);
            Assert.AreEqual(Types.ClaimType.Property, claimSubmittedEvent.ClaimType);
        }

        [TestMethod]
        public void CanDeserializeWithUnsupportedEnumValue()
        {
            // Arrange
            var jsonContent = @"
                {
                    ""SubmissionDate"": ""2024-01-10T00:00:00Z"",
                    ""SubmissionId"": ""8f8f9970-72a7-44aa-b5e8-4d46b0afb7d6"",
                    ""ClaimType"": ""DoesNotExist""
                }
            ";
            var settings = new JsonSerializerSettings
            {
                Converters = CustomJsonConverters.GetCustomerJsonConverters()
            };

            // Act
            var claimSubmittedEvent = JsonConvert.DeserializeObject<ClaimSubmittedEvent>(jsonContent, settings);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.AreEqual(false, claimSubmittedEvent.ClaimType.HasValue);
        }
    }
}