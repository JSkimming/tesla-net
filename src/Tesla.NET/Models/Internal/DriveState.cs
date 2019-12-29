// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The drive state of a <see cref="IVehicle"/>.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class DriveState : IDriveState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriveState"/> class.
        /// </summary>
        /// <param name="shiftState">The <see cref="ShiftState"/>.</param>
        /// <param name="speed">The <see cref="Speed"/>.</param>
        /// <param name="power">The <see cref="Power"/>.</param>
        /// <param name="latitude">The GPS <see cref="Latitude"/>.</param>
        /// <param name="longitude">The GPS <see cref="Longitude"/>.</param>
        /// <param name="heading">The <see cref="Heading"/>.</param>
        /// <param name="gpsAsOf">The <see cref="GpsAsOf"/>.</param>
        /// <param name="timestamp">The <see cref="Timestamp"/>.</param>
        public DriveState(
            string? shiftState = null,
            string? speed = null,
            long power = 0L,
            double latitude = 0D,
            double longitude = 0D,
            long heading = 0L,
            long gpsAsOf = 0L,
            long timestamp = 0L)
        {
            ShiftState = shiftState ?? string.Empty;
            Speed = speed ?? string.Empty;
            Power = power;
            Latitude = latitude;
            Longitude = longitude;
            Heading = heading;
            GpsAsOf = gpsAsOf;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Gets the shift state of a <see cref="IVehicle"/>.
        /// </summary>
        public string? ShiftState { get; }

        /// <summary>
        /// Gets the speed <see cref="IVehicle"/>.
        /// </summary>
        public string? Speed { get; }

        /// <summary>
        /// Gets the power <see cref="IVehicle"/>.
        /// </summary>
        public long Power { get; }

        /// <summary>
        /// Gets the GPS latitude <see cref="IVehicle"/>.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the GPS longitude <see cref="IVehicle"/>.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Gets the heading <see cref="IVehicle"/>.
        /// </summary>
        public long Heading { get; }

        /// <summary>
        /// Gets the Epoch timestamp of when the GPS data was captured.
        /// </summary>
        public long GpsAsOf { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the GPS data was captured.
        /// </summary>
        public DateTime GpsAsOfUtc => EpochConversion.FromSeconds(GpsAsOf);

        /// <summary>
        /// Gets the millisecond Epoch timestamp when the <see cref="IDriveState"/> was captured.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="IDriveState"/> was captured.
        /// </summary>
        public DateTime TimestampUtc => EpochConversion.FromMilliseconds(Timestamp);

        private string DebuggerDisplay => $"{GetType().Name}: ({Latitude},{Longitude}) @ {GpsAsOfUtc:R}";
    }
}
