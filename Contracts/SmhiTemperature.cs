namespace Contracts
{
    using System.Runtime.CompilerServices;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    //Since SMHI is using Unix dates which is a long, we need to convert it to a DateTime

    public class UnixDateConverter : JsonConverter<DateTime>
    {
        //This will convert from a unix date to datetime when reading the json
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTime.UnixEpoch.AddMilliseconds(reader.GetInt64());

        //This will convert to a unix date from datetime when writing the json
        public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options)
            => writer.WriteNumberValue(((DateTimeOffset)dateTimeValue).ToUnixTimeSeconds());
    }
    
    public class SmhiTemperature
    {
        [JsonPropertyName("value")]
        public Value[]? Values { get; set; }
        [JsonPropertyName("updated")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime Updated { get; set; }
        [JsonPropertyName("parameter")]
        public Parameter? Parameter { get; set; }
        [JsonPropertyName("station")]
        public Station? Station { get; set; }
        [JsonPropertyName("period")]
        public Period? Period { get; set; }
        [JsonPropertyName("position")]
        public Position[]? Positions { get; set; }
        [JsonPropertyName("link")]
        public Link[]? Links { get; set; }
    }

    public class Parameter
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
        [JsonPropertyName("unit")]
        public string? Unit { get; set; }
    }

    public class Station
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("owner")]
        public string? Owner { get; set; }
        [JsonPropertyName("ownerCategory")]
        public string? OwnerCategory { get; set; }
        [JsonPropertyName("measuringStations")]
        public string? MeasuringStations { get; set; }
        [JsonPropertyName("height")]
        public float Height { get; set; }
    }

    public class Period
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }
        [JsonPropertyName("from")]
        [JsonConverter(typeof(UnixDateConverter))] 
        public DateTime From { get; set; }
        [JsonPropertyName("to")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime To { get; set; }
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
        [JsonPropertyName("sampling")]
        public string? Sampling { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime Date { get; set; }
        [JsonPropertyName("value")]
        public string? Measured { get; set; }
        [JsonPropertyName("quality")]
        public string? Quality { get; set; }
    }

    public class Position
    {
        [JsonPropertyName("from")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime From { get; set; }
        [JsonPropertyName("to")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime To { get; set; }
        [JsonPropertyName("height")]
        public float Height { get; set; }
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("rel")]
        public string? Rel { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("href")]
        public string? Href { get; set; }
    }
}
 