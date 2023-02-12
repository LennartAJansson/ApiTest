namespace MauiForecasts.Models;

using System;

using CommunityToolkit.Mvvm.ComponentModel;

public sealed class Forecast : ObservableObject
{
    public DateTime Created { get; set; }
    public Values Values { get; set; }
}
