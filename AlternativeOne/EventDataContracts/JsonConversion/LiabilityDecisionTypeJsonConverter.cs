using EventDataContracts.Types;
using Newtonsoft.Json;

namespace EventDataContracts.JsonConversion
{
    /// <summary>
    /// JsonConverter that handles the Deserialization of LiabilityDecisionType enum in a safe way.
    /// 
    /// Use-Case: An event has a value (e.g. "Motor") that is not yet implemented/supported by the current version of the data contact.
    /// Solution: Make sure that any Enum has some "Fallback" or "Default" value (e.g. "NotImplementedValue") which is created with the initial values of the Enum.
    /// 
    /// </summary>
    public class LiabilityDecisionTypeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(LiabilityDecisionType);
        }

        /// <summary>
        /// When the value is not recognized, default to the "NotImplementedValue" enum value
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return LiabilityDecisionType.NotImplementedValue;
            if (reader.Value == null) return LiabilityDecisionType.NotImplementedValue;

            string enumString = (string)reader.Value;

            switch (enumString)
            {
                case "Accepted":
                    return LiabilityDecisionType.Accepted;
                case "Rejected":
                    return LiabilityDecisionType.Rejected;
                default:
                    return LiabilityDecisionType.NotImplementedValue;
            }
        }

        /// <summary>
        /// Serialize the enum as their String value, "NotImplementedValue" will serialize as "NotImplementedValue"
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null) throw new ArgumentNullException("value");
            LiabilityDecisionType enumValue = (LiabilityDecisionType)value;
            writer.WriteValue(enumValue.ToString());
        }
    }
}
