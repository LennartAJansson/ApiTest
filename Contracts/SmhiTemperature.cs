namespace Contracts
{
    using System.Text.Json.Serialization;

    public class SmhiTemperature
    {
        [JsonPropertyName("value")]
        public Value[]? Values { get; set; }
        [JsonPropertyName("updated")]
        public long Updated { get; set; }
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
        public long From { get; set; }
        [JsonPropertyName("to")]
        public long To { get; set; }
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
        [JsonPropertyName("sampling")]
        public string? Sampling { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("date")]
        public long Date { get; set; }
        [JsonPropertyName("value")]
        public string? Measured { get; set; }
        [JsonPropertyName("quality")]
        public string? Quality { get; set; }
    }

    public class Position
    {
        [JsonPropertyName("from")]
        public long From { get; set; }
        [JsonPropertyName("to")]
        public long To { get; set; }
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
 