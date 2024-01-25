namespace EventStoreRestApi.Model
{
    internal class ClaimSubmittedEvent_v2 : BaseEvent
    {
        public DateTime SubmittedOn { get; set; }
        public string SubmittedBy { get; set; }

        public ClaimSubmittedEvent_v2(Guid eventId, DateTime submittedOn, string submittedBy) : base(eventId, "ClaimSubmittedEvent", "v2")
        {
            SubmittedOn = submittedOn;
            SubmittedBy = submittedBy;
        }
    }
}
