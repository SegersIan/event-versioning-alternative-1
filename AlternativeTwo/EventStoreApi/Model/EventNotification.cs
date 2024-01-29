namespace EventStoreRestApi.Model
{
    /// <summary>
    /// Notification about a new event.
    /// </summary>
    public class EventNotification
    {
        /// <summary>
        /// The ID of the event that occured
        /// </summary>
        public Guid EventId { get; set; }
        /// <summary>
        /// The type/name of the event
        /// </summary>
        public string EventType { get; set; } = "ClaimSubmittedEvent";
        /// <summary>
        /// The URI for accessing specific event
        /// </summary>
        public string URI { get; set; } = string.Empty;
        /// <summary>
        /// Lists all supportered versions for given EventType
        /// </summary>
        public List<string> SupportedVersions = new List<string>() { "v1", "v2", "v3" };
    }
}
