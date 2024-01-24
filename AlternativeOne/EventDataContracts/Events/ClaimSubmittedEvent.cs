using EventDataContracts.Types;

namespace EventDataContracts.Events
{
    /// <summary>
    /// Emitted when a Claim Submissions has been submitted.
    /// </summary>
    public class ClaimSubmittedEvent : BaseEvent
    {
        /// <summary>
        /// The date of when the claim submission was made.
        /// </summary>
        public DateTime SubmissionDate { get; set; }
        /// <summary>
        /// The Id of the Claim Submission that was registered
        /// </summary>
        public Guid SubmissionId { get; set; }
        /// <summary>
        /// The Type of the Claim
        /// </summary>
        public ClaimType? ClaimType { get; set; }
    }
}
