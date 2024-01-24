using EventDataContracts.Events;
using EventDataContracts.JsonConversion;
using Newtonsoft.Json;

namespace EventDataContracts.Tests
{
    [TestClass]
    public class DeserializeLiabilityDecidedEventTest
    {
        [TestMethod]
        public void CanDeserializeWithSupportedEnumValue()
        {
            // Arrange
            var jsonContent = @"
                {
                    ""Decision"": ""Accepted"",
                    ""DecisionMaker"": ""Ian""
                }
            ";
            var settings = new JsonSerializerSettings
            {
                Converters = CustomJsonConverters.GetCustomerJsonConverters()
            };

            // Act
            var claimSubmittedEvent = JsonConvert.DeserializeObject<LiabilityDecidedEvent>(jsonContent, settings);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.AreEqual(Types.LiabilityDecisionType.Accepted, claimSubmittedEvent.Decision);
        }

        [TestMethod]
        public void CanDeserializeWithUnsupportedEnumValue()
        {
            // Arrange
            var jsonContent = @"
                {
                    ""Decision"": ""DoesNotExist"",
                    ""DecisionMaker"": ""Ian""
                }
            ";
            var settings = new JsonSerializerSettings
            {
                Converters = CustomJsonConverters.GetCustomerJsonConverters()
            };

            // Act
            var claimSubmittedEvent = JsonConvert.DeserializeObject<LiabilityDecidedEvent>(jsonContent, settings);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.AreEqual(Types.LiabilityDecisionType.NotImplementedValue, claimSubmittedEvent.Decision);
        }
    }
}
