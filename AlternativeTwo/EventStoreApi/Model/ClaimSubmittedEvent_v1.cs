namespace EventStoreRestApi.Model
{
    internal class ClaimSubmittedEvent_v1 : BaseEvent
    {
        public DateTime SubmittedOn { get; set; }

        public ClaimSubmittedEvent_v1(Guid eventId, DateTime submittedOn) : base(eventId, "ClaimSubmittedEvent", "v1")
        {
            SubmittedOn = submittedOn;
        }
    }
}
