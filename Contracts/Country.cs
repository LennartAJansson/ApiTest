namespace Contracts;

using System.Text.Json.Serialization;

public class Country
{
    [JsonPropertyName("name")]
    public Name? Name { get; set; }
    [JsonPropertyName("cca2")]
    public string CountryCode2 { get; set; } = string.Empty;

    [JsonPropertyName("cca3")]
    public string CountryCode3 { get; set; } = string.Empty;

    [JsonPropertyName("ccn3")]
    public string IsoCountry { get; set; } = string.Empty;
    [JsonPropertyName("idd")]
    public PhonePrefix? PhonePrefix { get; set; }
}

public class Name
{
    [JsonPropertyName("common")]
    public string Common { get; set; } = string.Empty;
}

public class PhonePrefix
{
    [JsonPropertyName("root")]
    public string Prefix { get; set; } = string.Empty;
    [JsonPropertyName("suffixes")]
    public string[] Suffixes { get; set; } = Array.Empty<string>();
}

