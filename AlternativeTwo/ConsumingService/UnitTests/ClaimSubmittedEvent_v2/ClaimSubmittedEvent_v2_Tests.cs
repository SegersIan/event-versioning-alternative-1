using ConsumingService.Business;
using EventDataContracts.Model;
using Newtonsoft.Json;

namespace ConsumingService.UnitTests.ClaimSubmittedEvent_v2
{
    [TestClass]
    public class ClaimSubmittedEvent_v2_Tests
    {
        private static readonly string EVENT_VERSION = "v2";
        private static readonly string SUBMISSION_DATE = "2020-01-01T01:00:00Z";
        private static readonly string EVENT_TYPE = "ClaimSubmittedEvent";

        [TestMethod]
        public void CANREAD_V1_EVENT()
        {
            // Arrange
            var eventId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var eventNotification = CreateEventNotification(eventId);

            // Act
            var claimSubmittedEventJson = MyService.GetEventFromEventNotificationAsJson(eventNotification, EVENT_VERSION);
            var claimSubmittedEvent = JsonConvert.DeserializeObject<ClaimSubmittedEvent>(claimSubmittedEventJson);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.AreEqual(eventId, claimSubmittedEvent.EventId);
            Assert.AreEqual(EVENT_VERSION, claimSubmittedEvent.EventVersion);
            Assert.AreEqual(EVENT_TYPE, claimSubmittedEvent.EventName);
            Assert.AreEqual(DateTime.Parse(SUBMISSION_DATE), claimSubmittedEvent.SubmittedOn);
            Assert.AreEqual("Unknown", claimSubmittedEvent.SubmittedBy);
        }

        [TestMethod]
        public void CANREAD_V2_EVENT()
        {
            // Arrange
            var eventId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var eventNotification = CreateEventNotification(eventId);

            // Act
            var claimSubmittedEventJson = MyService.GetEventFromEventNotificationAsJson(eventNotification, EVENT_VERSION);
            var claimSubmittedEvent = JsonConvert.DeserializeObject<ClaimSubmittedEvent>(claimSubmittedEventJson);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.AreEqual(eventId, claimSubmittedEvent.EventId);
            Assert.AreEqual(EVENT_VERSION, claimSubmittedEvent.EventVersion);
            Assert.AreEqual(EVENT_TYPE, claimSubmittedEvent.EventName);
            Assert.AreEqual(DateTime.Parse(SUBMISSION_DATE), claimSubmittedEvent.SubmittedOn);
            Assert.AreEqual("Ian", claimSubmittedEvent.SubmittedBy);
        }

        [TestMethod]
        public void CANREAD_V3_EVENT()
        {
            // Arrange
            var eventId = Guid.Parse("00000000-0000-0000-0000-000000000003");
            var eventNotification = CreateEventNotification(eventId);

            // Act
            var claimSubmittedEventJson = MyService.GetEventFromEventNotificationAsJson(eventNotification, EVENT_VERSION);
            var claimSubmittedEvent = JsonConvert.DeserializeObject<ClaimSubmittedEvent>(claimSubmittedEventJson);

            // Assert
            Assert.IsNotNull(claimSubmittedEvent);
            Assert.AreEqual(eventId, claimSubmittedEvent.EventId);
            Assert.AreEqual(EVENT_VERSION, claimSubmittedEvent.EventVersion);
            Assert.AreEqual(EVENT_TYPE, claimSubmittedEvent.EventName);
            Assert.AreEqual(DateTime.Parse(SUBMISSION_DATE), claimSubmittedEvent.SubmittedOn);
            Assert.AreEqual("Ian", claimSubmittedEvent.SubmittedBy);
        }

        private EventNotification CreateEventNotification(Guid id)
        {
            return new EventNotification()
            {
                EventId = id,
                EventType = EVENT_TYPE,
                URI = $"/events/{id}"
            };
        }
    }

    public class ClaimSubmittedEvent
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventVersion { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string SubmittedBy { get; set; }
    }

}