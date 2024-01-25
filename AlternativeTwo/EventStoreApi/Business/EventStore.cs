namespace EventStoreRestApi.Logic
{
    internal static class EventStore
    {
        public static Model.BaseEvent? GetEvent(Guid id)
        {
            var dateTime = DateTime.Parse("2020-01-01T01:00:00Z");

            switch(id.ToString()) {
                case "00000000-0000-0000-0000-000000000001":
                    return new Model.ClaimSubmittedEvent_v1(id, dateTime);
                case "00000000-0000-0000-0000-000000000002":
                    return new Model.ClaimSubmittedEvent_v2(id, dateTime, "Ian");
                case "00000000-0000-0000-0000-000000000003":
                    return new Model.ClaimSubmittedEvent_v3(id, dateTime, "Ian", Model.ClaimType.Property);
                default: return null;
            }
        }
    }
}