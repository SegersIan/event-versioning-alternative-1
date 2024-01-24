using EventDataContracts.Events;
using EventDataContracts.JsonConversion;
using Newtonsoft.Json;

namespace EventDataContracts.Tests
{
    [TestClass]
    public class SerializeLiabilityDecidedEventTest
    {
        [TestMethod]
        public void SerializesValidEnumToCorrectString()
        {
            // Arrange
            var liabilityDecidedEvent = new LiabilityDecidedEvent()
            {
                Decision = Types.LiabilityDecisionType.Accepted,
                DecisionMaker = "Ian"
            };
            var settings = new JsonSerializerSettings { Converters = CustomJsonConverters.GetCustomerJsonConverters() };

            // Act
            var jsonContent = JsonConvert.SerializeObject(liabilityDecidedEvent, settings);

            // Assert
            Console.WriteLine(jsonContent);
            Assert.IsTrue(jsonContent.Contains("\"Decision\":\"Accepted\""));
        }

        [TestMethod]
        public void SerializesNotImplementedEnumToNotImplementedString()
        {
            // Arrange
            var liabilityDecidedEvent = new LiabilityDecidedEvent()
            {
                Decision = Types.LiabilityDecisionType.NotImplementedValue,
                DecisionMaker = "Ian"
            };
            var settings = new JsonSerializerSettings { Converters = CustomJsonConverters.GetCustomerJsonConverters() };

            // Act
            var jsonContent = JsonConvert.SerializeObject(liabilityDecidedEvent, settings);

            // Assert
            Console.WriteLine(jsonContent);
            Assert.IsTrue(jsonContent.Contains("\"Decision\":\"NotImplementedValue\""));
        }
    }
}
