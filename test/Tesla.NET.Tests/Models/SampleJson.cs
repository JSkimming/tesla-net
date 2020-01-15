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

        public static JObject ChargeState => (JObject)GetChargeStateResponse["response"];
        public static JObject ClimateState => (JObject)GetClimateStateResponse["response"];

        public static JObject ChargeStateMinimal => (JObject)GetChargeStateMinimalResponse["response"];

        public static JObject DriveState => (JObject)GetDriveStateResponse["response"];

        public static JObject DriveStateMinimal => new JObject();

        public static JObject GetChargeStateMinimalResponse => Load<JObject>(nameof(GetChargeStateMinimalResponse));

        public static JObject GetChargeStateResponse => Load<JObject>(nameof(GetChargeStateResponse));

        public static JObject GetDriveStateResponse => Load<JObject>(nameof(GetDriveStateResponse));

        public static JObject GetVehiclesResponse => Load<JObject>(nameof(GetVehiclesResponse));

        public static JObject GetVehicleStateResponse => Load<JObject>(nameof(GetVehicleStateResponse));

        public static JObject GetVehicleStateResponse2 => Load<JObject>(nameof(GetVehicleStateResponse2));
        public static JObject GetClimateStateResponse => Load<JObject>(nameof(GetClimateStateResponse));

        public static JObject Vehicle => (JObject)GetVehiclesResponse["response"][0];

        public static JObject VehicleMinimal => new JObject();

        public static JObject VehicleState => (JObject)GetVehicleStateResponse["response"];

        public static JObject VehicleStateMinimal => new JObject();
    }
}
