namespace SmhiApiServices.Models;
using System;
using System.Collections.Generic;

public sealed class Forecast
{
    public DateTime Created { get; set; }
    public ICollection<Value>? Values { get; set; }
}
