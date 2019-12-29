// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The drive state of a <see cref="IVehicle"/>.
    /// </summary>
    public interface IDriveState : IState
    {
        /// <summary>
        /// Gets the shift state of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("shift_state")]
        string? ShiftState { get; }

        /// <summary>
        /// Gets the speed <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("speed")]
        string? Speed { get; }

        /// <summary>
        /// Gets the power <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("power")]
        long Power { get; }

        /// <summary>
        /// Gets the GPS latitude <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("latitude")]
        double Latitude { get; }

        /// <summary>
        /// Gets the GPS longitude <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("longitude")]
        double Longitude { get; }

        /// <summary>
        /// Gets the heading <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("heading")]
        long Heading { get; }

        /// <summary>
        /// Gets the Epoch timestamp of when the GPS data was captured.
        /// </summary>
        [JsonProperty("gps_as_of")]
        long GpsAsOf { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the GPS data was captured.
        /// </summary>
        [JsonIgnore]
        DateTime GpsAsOfUtc { get; }
    }
}
