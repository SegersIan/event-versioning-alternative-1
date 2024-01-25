namespace EventStoreRestApi.Model
{
    internal class ClaimSubmittedEvent_v3 : BaseEvent
    {
        public DateTime SubmittedOn { get; set; }
        public string SubmittedBy { get; set; }
        public ClaimType ClaimType { get; set; }

        public ClaimSubmittedEvent_v3(Guid eventId, DateTime submittedOn, string submittedBy, ClaimType claimType) : base(eventId, "ClaimSubmittedEvent", "v3")
        {
            SubmittedOn = submittedOn;
            SubmittedBy = submittedBy;
            ClaimType = claimType;
        }
    }
}
