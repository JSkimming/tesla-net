// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The vehicle object.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Gets the unique ID of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("id")]
        long Id { get; }

        /// <summary>
        /// Gets the id of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("vehicle_id")]
        long VehicleId { get; }

        /// <summary>
        /// Gets the VIN (vehicle identification number) of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("vin")]
        string? Vin { get; }

        /// <summary>
        /// Gets the display name of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("display_name")]
        string? DisplayName { get; }

        /// <summary>
        /// Gets the option codes of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("option_codes")]
        string? OptionCodes { get; }

        /// <summary>
        /// Gets the color of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("color")]
        string? Color { get; }

        /// <summary>
        /// Gets the tokens of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("tokens")]
        IReadOnlyCollection<string> Tokens { get; }

        /// <summary>
        /// Gets the state of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("state")]
        string? State { get; }

        /// <summary>
        /// Gets the in service state of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("in_service")]
        string? InService { get; }

        /// <summary>
        /// Gets a value indicating whether remote start is enabled for the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("remote_start_enabled")]
        bool RemoteStartEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the calendar is enabled for the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("calendar_enabled")]
        bool CalendarEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether notifications are enabled for the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("notifications_enabled")]
        bool NotificationsEnabled { get; }

        /// <summary>
        /// Gets the <see cref="BackseatToken"/> of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("backseat_token")]
        string? BackseatToken { get; }

        /// <summary>
        /// Gets the <see cref="BackseatTokenUpdatedAt"/> of the <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("backseat_token_updated_at")]
        string? BackseatTokenUpdatedAt { get; }
    }
}
