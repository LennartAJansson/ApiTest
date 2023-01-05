namespace Contracts;

using System.Text.Json.Serialization;

using Contracts.Converters;

public class ObservationsForPeriod
{
    [JsonPropertyName("value")]
    public Observation[]? Values { get; set; }
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

public class Observation
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


public class PeriodsForStation
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? owner { get; set; }
    public string? ownerCategory { get; set; }
    public string? measuringStations { get; set; }
    public bool active { get; set; }
    public string? summary { get; set; }
    public long from { get; set; }
    public long to { get; set; }
    public Position[]? position { get; set; }
    public Link[]? link { get; set; }
    public PeriodByStation[]? period { get; set; }
}

public class PeriodByStation
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
}



public class StationsForParameter
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public string? valueType { get; set; }
    public Link[]? link { get; set; }
    public StationsetByParameter[]? stationSet { get; set; }
    public StationByParameter[]? station { get; set; }
}

public class StationsetByParameter
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
}

public class StationByParameter
{
    public string? name { get; set; }
    public string? owner { get; set; }
    public string? ownerCategory { get; set; }
    public string? measuringStations { get; set; }
    public int id { get; set; }
    public float height { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
    public bool active { get; set; }
    public long from { get; set; }
    public long to { get; set; }
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
}



public class ParametersForVersion
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
    public Resource[]? resource { get; set; }
}

public class Resource
{
    public Geobox? geoBox { get; set; }
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
}

public class Geobox
{
    public float minLatitude { get; set; }
    public float minLongitude { get; set; }
    public float maxLatitude { get; set; }
    public float maxLongitude { get; set; }
}



public class VersionsForApi
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
    public Version[]? version { get; set; }
}

public class Version
{
    public string? key { get; set; }
    public long updated { get; set; }
    public string? title { get; set; }
    public string? summary { get; set; }
    public Link[]? link { get; set; }
}
