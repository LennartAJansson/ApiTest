namespace SmhiApiServices.Contracts;
using System;
using System.Text.Json.Serialization;

using SmhiApiServices.Converters;

public class SmhiForecast
{
    [JsonPropertyName("approvedTime")]
    public DateTime ApprovedTime { get; set; }
    [JsonPropertyName("referenceTime")]
    public DateTime ReferenceTime { get; set; }
    [JsonPropertyName("geometry")]
    public Geometry? Geometry { get; set; }
    [JsonPropertyName("timeSeries")]
    public Timeserie[]? TimeSeries { get; set; }
}

public class Geometry
{
    [JsonPropertyName("type")]
    public string? GeometryType { get; set; }
    [JsonPropertyName("coordinates")]
    public float[][]? Coordinates { get; set; }
}

public class Timeserie
{
    [JsonPropertyName("validTime")]
    public DateTime ValidTime { get; set; }
    [JsonPropertyName("parameters")]
    public ForecastParameter[]? Parameters { get; set; }
}

public class ForecastParameter
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("levelType")]
    public string? LevelType { get; set; }
    [JsonPropertyName("level")]
    public int Level { get; set; }
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
    [JsonPropertyName("values")]
    public float[]? Values { get; set; }
}

