using System.Reflection;
using System.Text;

namespace EventDataContracts.Events
{
    /// <summary>
    /// The Base Class of any Event
    /// </summary>
    public class BaseEvent
    {
        /// <summary>
        /// Name of the event's schema
        /// </summary>
        public string SchemaName { get; }
        /// <summary>
        /// Version of the event's schema
        /// </summary>
        public string SchemaVersion { get; }
        /// <summary>
        /// Global Unique Id of the unique occurence of the event
        /// </summary>
        public Guid Id { get; }

        public BaseEvent()
        {
            Id = Guid.NewGuid();
            SchemaName = GetType().ToString();
            SchemaVersion = GetSchemaVersion();
        }

        /// <summary>
        /// Get the version of the schema, by reading this assemblies version.
        /// </summary>
        /// <returns>Version</returns>
        private string GetSchemaVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;
            return version != null ? version.ToString() : "Unknown";
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
