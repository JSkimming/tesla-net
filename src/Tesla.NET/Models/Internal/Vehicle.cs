// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// The vehicle object.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Vehicle : IVehicle
    {
        private static readonly string[] EmptyTokens = Array.Empty<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">The <see cref="Id"/>.</param>
        /// <param name="vehicleId">The <see cref="VehicleId"/>.</param>
        /// <param name="vin">The <see cref="Vin"/>.</param>
        /// <param name="displayName">The <see cref="DisplayName"/>.</param>
        /// <param name="optionCodes">The <see cref="OptionCodes"/>.</param>
        /// <param name="color">The <see cref="Color"/>.</param>
        /// <param name="tokens">The <see cref="Tokens"/>.</param>
        /// <param name="state">The <see cref="State"/>.</param>
        /// <param name="inService">The <see cref="InService"/>.</param>
        /// <param name="remoteStartEnabled">The <see cref="RemoteStartEnabled"/>.</param>
        /// <param name="calendarEnabled">The <see cref="CalendarEnabled"/>.</param>
        /// <param name="notificationsEnabled">The <see cref="NotificationsEnabled"/>.</param>
        /// <param name="backseatToken">The <see cref="BackseatToken"/>.</param>
        /// <param name="backseatTokenUpdatedAt">The <see cref="BackseatTokenUpdatedAt"/>.</param>
        public Vehicle(
            long id = 0,
            long vehicleId = 0,
            string? vin = null,
            string? displayName = null,
            string? optionCodes = null,
            string? color = null,
            IReadOnlyCollection<string>? tokens = null,
            string? state = null,
            string? inService = null,
            bool remoteStartEnabled = false,
            bool calendarEnabled = false,
            bool notificationsEnabled = false,
            string? backseatToken = null,
            string? backseatTokenUpdatedAt = null)
        {
            Id = id;
            VehicleId = vehicleId;
            Vin = vin ?? string.Empty;
            DisplayName = displayName ?? string.Empty;
            OptionCodes = optionCodes ?? string.Empty;
            Color = color ?? string.Empty;
            Tokens = tokens ?? EmptyTokens;
            State = state ?? string.Empty;
            InService = inService ?? string.Empty;
            RemoteStartEnabled = remoteStartEnabled;
            CalendarEnabled = calendarEnabled;
            NotificationsEnabled = notificationsEnabled;
            BackseatToken = backseatToken ?? string.Empty;
            BackseatTokenUpdatedAt = backseatTokenUpdatedAt ?? string.Empty;
        }

        /// <summary>
        /// Gets the unique ID of the <see cref="IVehicle"/>.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the id of the <see cref="IVehicle"/>.
        /// </summary>
        public long VehicleId { get; }

        /// <summary>
        /// Gets the VIN (vehicle identification number) of the <see cref="IVehicle"/>.
        /// </summary>
        public string? Vin { get; }

        /// <summary>
        /// Gets the display name of the <see cref="IVehicle"/>.
        /// </summary>
        public string? DisplayName { get; }

        /// <summary>
        /// Gets the option codes of the <see cref="IVehicle"/>.
        /// </summary>
        public string? OptionCodes { get; }

        /// <summary>
        /// Gets the color of the <see cref="IVehicle"/>.
        /// </summary>
        public string? Color { get; }

        /// <summary>
        /// Gets the tokens of the <see cref="IVehicle"/>.
        /// </summary>
        public IReadOnlyCollection<string> Tokens { get; }

        /// <summary>
        /// Gets the state of the <see cref="IVehicle"/>.
        /// </summary>
        public string? State { get; }

        /// <summary>
        /// Gets the in service state of the <see cref="IVehicle"/>.
        /// </summary>
        public string? InService { get; }

        /// <summary>
        /// Gets a value indicating whether remote start is enabled for the <see cref="IVehicle"/>.
        /// </summary>
        public bool RemoteStartEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the calendar is enabled for the <see cref="IVehicle"/>.
        /// </summary>
        public bool CalendarEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether notifications are enabled for the <see cref="IVehicle"/>.
        /// </summary>
        public bool NotificationsEnabled { get; }

        /// <summary>
        /// Gets the <see cref="BackseatToken"/> of the <see cref="IVehicle"/>.
        /// </summary>
        public string? BackseatToken { get; }

        /// <summary>
        /// Gets the <see cref="BackseatTokenUpdatedAt"/> of the <see cref="IVehicle"/>.
        /// </summary>
        public string? BackseatTokenUpdatedAt { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {DisplayName} VIN={Vin}";
    }
}
