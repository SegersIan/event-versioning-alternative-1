using Newtonsoft.Json;

namespace EventDataContracts.JsonConversion
{
    public static class CustomJsonConverters
    {
        public static List<JsonConverter> GetCustomerJsonConverters()
        {
            return new List<JsonConverter> {
                new LiabilityDecisionTypeJsonConverter(),
                new ClaimTypeJsonConverter(),
            };
        }
    }
}
