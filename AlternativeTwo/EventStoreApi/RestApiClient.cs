using EventStoreRestApi.Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EventStoreRestApi
{
    /// <summary>
    /// For simplicity we don't setup an actual HTTP server.
    /// We just expose this class as a "mock" RestApi client.
    /// </summary>
    public class RestApiClient
    {
        /// <summary>
        /// Returns an Event based on provided ID and in the version based on the "Accept" HTTP header.
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public HttpResponse GetEvent(HttpRequest httpRequest)
        {
            var eventId = ExtractEventId(httpRequest.URI);
            var eventObject = EventRepository.GetEvent(eventId);

            if(eventObject == null) throw new Exception("Event Not Found");

            var targetVersionEventObject = EventTransformer.TransformToTargetVersion(eventObject, httpRequest.HeaderAccept);
            var jsonConvertSettings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };

            var httpResponse = new HttpResponse() {
                JsonBody = JsonConvert.SerializeObject(targetVersionEventObject, jsonConvertSettings),
                HeaderContentType = httpRequest.HeaderAccept
            };

            return httpResponse;
    }

        /// <summary>
        /// URI format: "/events/<guid>"
        /// 
        /// Example: /events/4bf69fa2-65a7-4f8c-93e9-6eb912580e66
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Guid ExtractEventId(string uri)
        {
            return Guid.Parse(uri.Split("/")[2]);
        }
    }
}
