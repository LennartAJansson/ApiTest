﻿namespace MauiForecasts.Models;

using System;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

public sealed class Value : ObservableObject
{
    public DateTime At { get; set; }
    public string TemperatureText { get; set; } = string.Empty;
    public float Temperature { get; set; }
    public string PressureText { get; set; } = string.Empty;
    public float Pressure { get; set; }
}

public sealed class Values : ObservableCollection<Value>
{
    public Values(IEnumerable<Value> values)
        : base(values)
    { }
}