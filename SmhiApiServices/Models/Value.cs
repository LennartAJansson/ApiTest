namespace SmhiApiServices.Models;
using System;

public sealed class Value
{
    public DateTime At { get; set; }
    public string TemperatureText { get; set; } = string.Empty;
    public float Temperature { get; set; }
    public string PressureText { get; set; } = string.Empty;
    public float Pressure { get; set; }
}