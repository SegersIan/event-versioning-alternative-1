using EventDataContracts.Types;

namespace EventDataContracts.Events
{
    /// <summary>
    /// Emitted when a Claim Submission was registered in a Core system.
    /// </summary>
    public class ClaimRegisteredEvent : BaseEvent
    {
        /// <summary>
        /// Date of the registration.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// The Id of the Claim Submission that was registered
        /// </summary>
        public Guid SubmissionId { get; set; }
        /// <summary>
        /// The Id of the registered claim.
        /// </summary>
        public Guid ClaimId { get; set; }
        /// <summary>
        /// The Type of the Claim
        /// </summary>
        public ClaimType? ClaimType { get; set; }
    }
}
