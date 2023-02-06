namespace SmhiApiServices.Models;

using CommunityToolkit.Mvvm.ComponentModel;

using System;

public sealed class Forecast : ObservableObject
{
    public DateTime Created { get; set; }
    public Values? Values { get; set; }
}
