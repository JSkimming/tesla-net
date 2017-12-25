// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    internal class SampleJson
    {
        public static TJson Load<TJson>(string fileName)
            where TJson : JToken
        {
            Stream stream =
                typeof(SampleJson).Assembly.GetManifestResourceStream(typeof(SampleJson), $"{fileName}.json");

            if (stream == null)
                throw new InvalidOperationException(
                    $"Unable to load Sample JSON file '{fileName}'" +
                    " - did you mark the file as an 'embedded resource'?");

            using (var sr = new StreamReader(stream))
            {
                string json = sr.ReadToEnd();
                return (TJson)JToken.Parse(json);
            }
        }

        public static JObject AccessTokenResponse => Load<JObject>(nameof(AccessTokenResponse));

        public static JObject GetVehiclesResponse => Load<JObject>(nameof(GetVehiclesResponse));

        public static JObject Vehicle => (JObject)GetVehiclesResponse["response"][0];

        public static JObject VehicleMinimal => new JObject();
    }
}
