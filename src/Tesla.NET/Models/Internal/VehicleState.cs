// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Information about the physical state of a <see cref="IVehicle"/>.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class VehicleState : IVehicleState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleState"/> class.
        /// </summary>
        /// <param name="apiVersion">The <see cref="ApiVersion"/>.</param>
        /// <param name="autoparkState">The <see cref="AutoparkState"/>.</param>
        /// <param name="autoparkStateV2">The <see cref="AutoparkStateV2"/>.</param>
        /// <param name="autoparkStyle">The <see cref="AutoparkStyle"/>.</param>
        /// <param name="calendarSupported">The <see cref="CalendarSupported"/>.</param>
        /// <param name="carVersion">The <see cref="CarVersion"/>.</param>
        /// <param name="centerDisplayState">The <see cref="CenterDisplayState"/>.</param>
        /// <param name="df">The <see cref="Df"/>.</param>
        /// <param name="dr">The <see cref="Dr"/>.</param>
        /// <param name="ft">The <see cref="Ft"/>.</param>
        /// <param name="homelinkNearby">The <see cref="HomelinkNearby"/>.</param>
        /// <param name="lastAutoparkError">The <see cref="LastAutoparkError"/>.</param>
        /// <param name="locked">The <see cref="Locked"/>.</param>
        /// <param name="notificationsSupported">The <see cref="NotificationsSupported"/>.</param>
        /// <param name="odometer">The <see cref="Odometer"/>.</param>
        /// <param name="parsedCalendarSupported">The <see cref="ParsedCalendarSupported"/>.</param>
        /// <param name="pf">The <see cref="Pf"/>.</param>
        /// <param name="pr">The <see cref="Pr"/>.</param>
        /// <param name="remoteStart">The <see cref="RemoteStart"/>.</param>
        /// <param name="remoteStartSupported">The <see cref="RemoteStartSupported"/>.</param>
        /// <param name="rt">The <see cref="Rt"/>.</param>
        /// <param name="sunRoofPercentOpen">The <see cref="SunRoofPercentOpen"/>.</param>
        /// <param name="sunRoofState">The <see cref="SunRoofState"/>.</param>
        /// <param name="timestamp">The <see cref="Timestamp"/>.</param>
        /// <param name="valetMode">The <see cref="ValetMode"/>.</param>
        /// <param name="valetPinNeeded">The <see cref="ValetPinNeeded"/>.</param>
        /// <param name="vehicleName">The <see cref="VehicleName"/>.</param>
        public VehicleState(
            long apiVersion = default,
            string? autoparkState = default,
            string? autoparkStateV2 = default,
            string? autoparkStyle = default,
            bool calendarSupported = default,
            string? carVersion = default,
            long centerDisplayState = default,
            long df = default,
            long dr = default,
            long ft = default,
            bool homelinkNearby = default,
            string? lastAutoparkError = default,
            bool locked = default,
            bool notificationsSupported = default,
            double odometer = default,
            bool parsedCalendarSupported = default,
            long pf = default,
            long pr = default,
            bool remoteStart = default,
            bool remoteStartSupported = default,
            long rt = default,
            long? sunRoofPercentOpen = default,
            string? sunRoofState = default,
            long timestamp = default,
            bool valetMode = default,
            bool valetPinNeeded = default,
            string? vehicleName = default)
        {
            ApiVersion = apiVersion;
            AutoparkState = autoparkState ?? string.Empty;
            AutoparkStateV2 = autoparkStateV2 ?? string.Empty;
            AutoparkStyle = autoparkStyle ?? string.Empty;
            CalendarSupported = calendarSupported;
            CarVersion = carVersion ?? string.Empty;
            CenterDisplayState = centerDisplayState;
            Df = df;
            Dr = dr;
            Ft = ft;
            HomelinkNearby = homelinkNearby;
            LastAutoparkError = lastAutoparkError ?? string.Empty;
            Locked = locked;
            NotificationsSupported = notificationsSupported;
            Odometer = odometer;
            ParsedCalendarSupported = parsedCalendarSupported;
            Pf = pf;
            Pr = pr;
            RemoteStart = remoteStart;
            RemoteStartSupported = remoteStartSupported;
            Rt = rt;
            SunRoofPercentOpen = sunRoofPercentOpen;
            SunRoofState = sunRoofState ?? string.Empty;
            Timestamp = timestamp;
            ValetMode = valetMode;
            ValetPinNeeded = valetPinNeeded;
            VehicleName = vehicleName ?? string.Empty;
        }

        /// <summary>
        /// Gets the API Version.
        /// </summary>
        public long ApiVersion { get; }

        /// <summary>
        /// Gets the state of auto-park.
        /// </summary>
        public string? AutoparkState { get; }

        /// <summary>
        /// Gets the state of V2 auto-park.
        /// </summary>
        public string? AutoparkStateV2 { get; }

        /// <summary>
        /// Gets the style of auto-park.
        /// </summary>
        public string? AutoparkStyle { get; }

        /// <summary>
        /// Gets a value indicating whether the Calendar is supported.
        /// </summary>
        public bool CalendarSupported { get; }

        /// <summary>
        /// Gets the car firmware version.
        /// </summary>
        public string? CarVersion { get; }

        /// <summary>
        /// Gets the state of the center display.
        /// </summary>
        public long CenterDisplayState { get; }

        /// <summary>
        /// Gets a value indicating whether the driver side front door is open.
        /// </summary>
        public long Df { get; }

        /// <summary>
        /// Gets a value indicating whether the driver side rear door is open.
        /// </summary>
        public long Dr { get; }

        /// <summary>
        /// Gets a value indicating whether the front trunk is open.
        /// </summary>
        public long Ft { get; }

        /// <summary>
        /// Gets a value indicating whether home link is near by.
        /// </summary>
        public bool HomelinkNearby { get; }

        /// <summary>
        /// Gets the last auto-park error.
        /// </summary>
        public string? LastAutoparkError { get; }

        /// <summary>
        /// Gets a value indicating whether the car is locked.
        /// </summary>
        public bool Locked { get; }

        /// <summary>
        /// Gets a value indicating whether notifications are supported.
        /// </summary>
        public bool NotificationsSupported { get; }

        /// <summary>
        /// Gets the car's Odometer value.
        /// </summary>
        public double Odometer { get; }

        /// <summary>
        /// Gets a value indicating whether parsed calendar is supported.
        /// </summary>
        public bool ParsedCalendarSupported { get; }

        /// <summary>
        /// Gets a value indicating whether the passenger side front door is open.
        /// </summary>
        public long Pf { get; }

        /// <summary>
        /// Gets a value indicating whether the passenger side rear door is open.
        /// </summary>
        public long Pr { get; }

        /// <summary>
        /// Gets a value indicating whether remote start is enabled.
        /// </summary>
        public bool RemoteStart { get; }

        /// <summary>
        /// Gets a value indicating whether remote start is supported.
        /// </summary>
        public bool RemoteStartSupported { get; }

        /// <summary>
        /// Gets a value indicating whether the rear trunk is open.
        /// </summary>
        public long Rt { get; }

        /// <summary>
        /// Gets the percentage the sun roof is open.
        /// </summary>
        public long? SunRoofPercentOpen { get; }

        /// <summary>
        /// Gets the state of the sunroof.
        /// </summary>
        public string? SunRoofState { get; }

        /// <summary>
        /// Gets the millisecond Epoch timestamp when the <see cref="IVehicleState"/> was captured.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="IVehicleState"/> was captured.
        /// </summary>
        public DateTime TimestampUtc => EpochConversion.FromMilliseconds(Timestamp);

        /// <summary>
        /// Gets a value indicating whether valet mode is enabled.
        /// </summary>
        public bool ValetMode { get; }

        /// <summary>
        /// Gets a value indicating whether valet mode pin is needed.
        /// </summary>
        public bool ValetPinNeeded { get; }

        /// <summary>
        /// Gets the name of the <see cref="IVehicle"/>.
        /// </summary>
        public string? VehicleName { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {VehicleName} {CarVersion} @ {TimestampUtc:R}";
    }
}
