﻿namespace SmhiApiServices.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SmhiApiServices.Contracts;

using SmhiApiServices.Converters;

public class ManualSmhiForecastApiHttpClient
{
}

public class ManualSmhiObservationApiHttpClient
{
    //Task<ObservationsForPeriod> GetObservationsForPeriod(string version, string parameter, string station, string period)
    //{
    //    using HttpClient client = new HttpClient();

    //    var json = await client.GetStringAsync($"https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station/107420/period/latest-months/data.json");
    //    if (json is not null)
    //    {
    //        //If we control the Serialize/Deserialize on our own we will need a converter for Unix DateTime to NET DateTime
    //        //Using Refit autogenerated clients we will have this mapping handled automatically
    //        var options = new JsonSerializerOptions();
    //        options.Converters.Add(new UnixDateConverter());

    //        ObservationsForPeriod? temperatures = JsonSerializer.Deserialize<ObservationsForPeriod>(json, options);
    //        if (temperatures is not null && temperatures.Values is not null)
    //        {
    //            await Console.Out.WriteLineAsync($"{temperatures?.Station?.Name} {temperatures?.Parameter?.Name}:");
    //            foreach (Observation? value in temperatures!.Values)
    //            {
    //                await Console.Out.WriteLineAsync($"{value.Date}\t{value.Measured} {temperatures?.Parameter?.Unit}");
    //            }
    //        }
    //    }

    //}
}
