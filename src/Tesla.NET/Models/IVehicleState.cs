// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Information about the physical state of a <see cref="IVehicle"/>.
    /// </summary>
    public interface IVehicleState : IState
    {
        /// <summary>
        /// Gets the API Version.
        /// </summary>
        [JsonProperty("api_version")]
        long ApiVersion { get; }

        /// <summary>
        /// Gets the state of auto-park.
        /// </summary>
        [JsonProperty("autopark_state")]
        string? AutoparkState { get; }

        /// <summary>
        /// Gets the state of V2 auto-park.
        /// </summary>
        [JsonProperty("autopark_state_v2")]
        string? AutoparkStateV2 { get; }

        /// <summary>
        /// Gets the style of auto-park.
        /// </summary>
        [JsonProperty("autopark_style")]
        string? AutoparkStyle { get; }

        /// <summary>
        /// Gets a value indicating whether the Calendar is supported.
        /// </summary>
        [JsonProperty("calendar_supported")]
        bool CalendarSupported { get; }

        /// <summary>
        /// Gets the car firmware version.
        /// </summary>
        [JsonProperty("car_version")]
        string? CarVersion { get; }

        /// <summary>
        /// Gets the state of the center display.
        /// </summary>
        [JsonProperty("center_display_state")]
        long CenterDisplayState { get; }

        /// <summary>
        /// Gets a value indicating whether the driver side front door is open.
        /// </summary>
        [JsonProperty("df")]
        long Df { get; }

        /// <summary>
        /// Gets a value indicating whether the driver side rear door is open.
        /// </summary>
        [JsonProperty("dr")]
        long Dr { get; }

        /// <summary>
        /// Gets a value indicating whether the front trunk is open.
        /// </summary>
        [JsonProperty("ft")]
        long Ft { get; }

        /// <summary>
        /// Gets a value indicating whether home link is near by.
        /// </summary>
        [JsonProperty("homelink_nearby")]
        bool HomelinkNearby { get; }

        /// <summary>
        /// Gets the last auto-park error.
        /// </summary>
        [JsonProperty("last_autopark_error")]
        string? LastAutoparkError { get; }

        /// <summary>
        /// Gets a value indicating whether the car is locked.
        /// </summary>
        [JsonProperty("locked")]
        bool Locked { get; }

        /// <summary>
        /// Gets a value indicating whether notifications are supported.
        /// </summary>
        [JsonProperty("notifications_supported")]
        bool NotificationsSupported { get; }

        /// <summary>
        /// Gets the car's Odometer value.
        /// </summary>
        [JsonProperty("odometer")]
        double Odometer { get; }

        /// <summary>
        /// Gets a value indicating whether parsed calendar is supported.
        /// </summary>
        [JsonProperty("parsed_calendar_supported")]
        bool ParsedCalendarSupported { get; }

        /// <summary>
        /// Gets a value indicating whether the passenger side front door is open.
        /// </summary>
        [JsonProperty("pf")]
        long Pf { get; }

        /// <summary>
        /// Gets a value indicating whether the passenger side rear door is open.
        /// </summary>
        [JsonProperty("pr")]
        long Pr { get; }

        /// <summary>
        /// Gets a value indicating whether remote start is enabled.
        /// </summary>
        [JsonProperty("remote_start")]
        bool RemoteStart { get; }

        /// <summary>
        /// Gets a value indicating whether remote start is supported.
        /// </summary>
        [JsonProperty("remote_start_supported")]
        bool RemoteStartSupported { get; }

        /// <summary>
        /// Gets a value indicating whether the rear trunk is open.
        /// </summary>
        [JsonProperty("rt")]
        long Rt { get; }

        /// <summary>
        /// Gets the percentage the sun roof is open.
        /// </summary>
        [JsonProperty("sun_roof_percent_open")]
        long? SunRoofPercentOpen { get; }

        /// <summary>
        /// Gets the state of the sunroof.
        /// </summary>
        [JsonProperty("sun_roof_state")]
        string? SunRoofState { get; }

        /// <summary>
        /// Gets a value indicating whether valet mode is enabled.
        /// </summary>
        [JsonProperty("valet_mode")]
        bool ValetMode { get; }

        /// <summary>
        /// Gets a value indicating whether valet mode pin is needed.
        /// </summary>
        [JsonProperty("valet_pin_needed")]
        bool ValetPinNeeded { get; }

        /// <summary>
        /// Gets the name of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("vehicle_name")]
        string? VehicleName { get; }
    }
}
