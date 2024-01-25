using EventStoreRestApi.Model;

namespace EventStoreRestApi.Logic
{
    internal static class EventTransformer
    {
        /// <summary>
        /// Transforms any Event Type from the version it was persisted in, to the target version specified.
        /// 
        /// Note: This down/upcasting logic can obviously be done better, but we want to illustrate what's happening.
        /// </summary>
        /// <param name="eventObject"></param>
        /// <param name="targetVersion"></param>
        /// <returns></returns>
        public static BaseEvent TransformToTargetVersion(BaseEvent eventObject, string targetVersion)
        {
            if (eventObject is ClaimSubmittedEvent_v1)
            {
                var sourceVersionObj = (ClaimSubmittedEvent_v1)eventObject;
                switch(targetVersion)
                {
                    case "v1": 
                        return sourceVersionObj;
                    case "v2":
                        return new ClaimSubmittedEvent_v2(sourceVersionObj.EventId, sourceVersionObj.SubmittedOn, "Unknown");
                    case "v3":
                        return new ClaimSubmittedEvent_v3(sourceVersionObj.EventId, sourceVersionObj.SubmittedOn, "Unknown", ClaimType.Unknown);
                    default:
                        throw new NotImplementedException("Transformation not Supported.");
                }
            }

            if (eventObject is ClaimSubmittedEvent_v2)
            {
                var sourceVersionObj = (ClaimSubmittedEvent_v2)eventObject;
                switch (targetVersion)
                {
                    case "v1":
                        return new ClaimSubmittedEvent_v1(sourceVersionObj.EventId, sourceVersionObj.SubmittedOn);
                    case "v2":
                        return sourceVersionObj;
                    case "v3":
                        return new ClaimSubmittedEvent_v3(sourceVersionObj.EventId, sourceVersionObj.SubmittedOn, sourceVersionObj.SubmittedBy, ClaimType.Unknown);
                    default:
                        throw new NotImplementedException("Transformation not Supported.");
                }
            }

            if(eventObject is ClaimSubmittedEvent_v3)
            {
                var sourceVersionObj = (ClaimSubmittedEvent_v3)eventObject;
                switch (targetVersion)
                {
                    case "v1":
                        return new ClaimSubmittedEvent_v1(sourceVersionObj.EventId, sourceVersionObj.SubmittedOn);
                    case "v2":
                        return new ClaimSubmittedEvent_v2(sourceVersionObj.EventId, sourceVersionObj.SubmittedOn, sourceVersionObj.SubmittedBy);
                    case "v3":
                        return sourceVersionObj;
                    default:
                        throw new NotImplementedException("Transformation not Supported.");
                }
            }

            throw new NotImplementedException("Transformation not Supported.");
        }
    }
}
