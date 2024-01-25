using System.Reflection;
using System.Text;

namespace EventStoreRestApi.Model
{
    internal class BaseEvent
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventVersion { get; set; }

        public BaseEvent(Guid eventId, string eventName, string eventVersion)
        {
            EventId = eventId;
            EventName = eventName;
            EventVersion = eventVersion;
        }

        /// <summary>
        /// Prints the Event with all its properties in a (somewhat) console friendly manner.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            var type = GetType(); // Gets the runtime type of the current instance

            sb.AppendLine($"Event: {type.Name}");
            sb.AppendLine("Properties:");

            // Iterate over all public properties
            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = prop.GetValue(this, null) ?? "null";
                sb.AppendLine($"  {prop.Name}: {value}");
            }

            return sb.ToString();
        }
    }
}
