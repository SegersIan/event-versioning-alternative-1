# Alternative One

## Implementation

Use the CustomJsonConverters and C# language features to set default values, if they did not exist in the JSON while deserializing. Optionally validate if all mandatory fields are set before proceeding.

CustomerJsonConverters must be co-located in the project that contains the data contracts. All consumers must be sure to use provided CustomJsonConverters to avoid runtime exceptions at deserialization.

## Rules

* Deserialization
    * Exists on json and C# class -> value from json
    * Exists on json but not on C# class -> NOP/Ignore
    * Exists on C# class but not in json -> default value
* No renaming of fields (preferably)
    * Can be handle by providing old and new attributes with same value or a CustomJSONConverter.
    * Better to avoid the complexity.
* Enums: When using Enum Types, you must either make them nullable or provide some fallback Enum value (e.g. `NotImplemented`) to handle deserialization of an enum value that the consuming service does not support yet (by not updating to the latest DataContract).
* Events must contain a property that contains the version of the event schema (e.g. DataContract version).
* [Optional] Have validation logic that all mandatory fields are set after deserialization.