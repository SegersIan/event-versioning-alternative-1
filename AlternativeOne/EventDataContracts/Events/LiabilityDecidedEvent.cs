using EventDataContracts.Types;

namespace EventDataContracts.Events
{
    /// <summary>
    /// The Liability of a claim has been decided.
    /// </summary>
    public class LiabilityDecidedEvent : BaseEvent
    {
        /// <summary>
        /// The decision
        /// </summary>
        public LiabilityDecisionType Decision { get; set; }
        /// <summary>
        /// The name of who made the decision
        /// </summary>
        public string? DecisionMaker {  get; set; }
    }
}
