using EventDataContracts.Model;

namespace ConsumingService.Business
{
    public static class MyService
    {
        public static string GetEventFromEventNotificationAsJson(EventNotification eventNotification, string eventVersion)
        {
            var httpClient = new EventStoreRestApi.RestApiClient();
            var httpRequest = new EventStoreRestApi.HttpRequest()
            {
                HeaderAccept = eventVersion,
                URI = eventNotification.URI
            };
            var httpResponse = httpClient.GetEvent(httpRequest);
            return httpResponse.JsonBody;
        }
    }
}
