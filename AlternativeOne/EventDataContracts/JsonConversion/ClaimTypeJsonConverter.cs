using EventDataContracts.Types;
using Newtonsoft.Json;

namespace EventDataContracts.JsonConversion
{

    /// <summary>
    /// JsonConverter that handles the Deserialization of ClaimType enum in a safe way.
    /// 
    /// Use-Case: An event has a value (e.g. "Motor") that is not yet implemented/supported by the current version of the data contact.
    /// Solution: Make sure that any Enum typed property is nullable.
    /// 
    /// If a value is not recognized during Deserialization, it returns null, with the intention that the attribute on the target class is also nullable.
    /// Example: public class Claim { public ClaimType? type { get; set; } }
    /// </summary>
    public class ClaimTypeJsonConverter : JsonConverter
    {
        /// <summary>
        /// Important: Must support only the nullable variation of given enum
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(ClaimType?);
        }

        /// <summary>
        /// When the value is not recognized, default on returning null.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            if (reader.Value == null) return null;
            string enumString = (string)reader.Value;

            switch (enumString)
            {
                case "PersonalInjury":
                    return ClaimType.PersonalInjury;
                case "Property":
                    return ClaimType.Property;
                default:
                    return null;
            }
        }

        /// <summary>
        /// In case of a known Enum value, use the string value of that, else default to null.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null) throw new ArgumentNullException("value");
            ClaimType enumValue = (ClaimType)value;
            writer.WriteValue(enumValue.ToString());
        }
    }
}
