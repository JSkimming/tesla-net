// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The climate state of a <see cref="IVehicle"/>.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ClimateState : IClimateState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateState"/> class.
        /// </summary>
        /// <param name="insideTemperature">The <see cref="InsideTemperature"/>.</param>
        /// <param name="outsideTemperature">The <see cref="OutsideTemperature"/>.</param>
        /// <param name="driverTemperatureSetting">The <see cref="DriverTemperatureSetting"/>.</param>
        /// <param name="passengerTemperatureSetting">The <see cref="PassengerTemperatureSetting"/>.</param>
        /// <param name="isFrontDefrosterOn">The <see cref="IsFrontDefrosterOn"/>.</param>
        /// <param name="isRearDefrosterOn">The <see cref="IsRearDefrosterOn"/>.</param>
        /// <param name="fanStatus">The <see cref="FanStatus"/>.</param>
        /// <param name="isClimateOn">The <see cref="IsClimateOn"/>.</param>
        /// <param name="minAvailableTemperature">The <see cref="MinAvailableTemperature"/>.</param>
        /// <param name="maxAvailableTemperature">The <see cref="MaxAvailableTemperature"/>.</param>
        /// <param name="seatHeaterLeft">The <see cref="SeatHeaterLeft"/>.</param>
        /// <param name="seatHeaterRight">The <see cref="SeatHeaterRight"/>.</param>
        /// <param name="seatHeaterRearLeft">The <see cref="SeatHeaterRearLeft"/>.</param>
        /// <param name="seatHeaterRearRight">The <see cref="SeatHeaterRearRight"/>.</param>
        /// <param name="seatHeaterRearCenter">The <see cref="SeatHeaterRearCenter"/>.</param>
        /// <param name="seatHeaterRearRightBack">The <see cref="SeatHeaterRearRightBack"/>.</param>
        /// <param name="seatHeaterRearLeftBack">The <see cref="SeatHeaterRearLeftBack"/>.</param>
        /// <param name="batterHeater">The <see cref="BatterHeater"/>.</param>
        /// <param name="batteryHeaterNoPower">The <see cref="BatteryHeaterNoPower"/>.</param>
        /// <param name="steeringWheelHeater">The <see cref="SteeringWheelHeater"/>.</param>
        /// <param name="wiperBladeHeater">The <see cref="WiperBladeHeater"/>.</param>
        /// <param name="sideMirrorHeater">The <see cref="SideMirrorHeater"/>.</param>
        /// <param name="isPreconditioning">The <see cref="IsPreconditioning"/>.</param>
        /// <param name="smartPreconditioning">The <see cref="SmartPreconditioning"/>.</param>
        /// <param name="isAutoConditioningOn">The <see cref="IsAutoConditioningOn"/>.</param>
        /// <param name="timestamp">The <see cref="Timestamp"/>.</param>
        public ClimateState(
            double? insideTemperature,
            double? outsideTemperature,
            double driverTemperatureSetting,
            double passengerTemperatureSetting,
            bool isFrontDefrosterOn,
            bool isRearDefrosterOn,
            int fanStatus,
            bool isClimateOn,
            double minAvailableTemperature,
            double maxAvailableTemperature,
            bool seatHeaterLeft,
            bool seatHeaterRight,
            bool seatHeaterRearLeft,
            bool seatHeaterRearRight,
            bool seatHeaterRearCenter,
            bool seatHeaterRearRightBack,
            bool seatHeaterRearLeftBack,
            bool batterHeater,
            bool? batteryHeaterNoPower,
            bool steeringWheelHeater,
            bool wiperBladeHeater,
            bool sideMirrorHeater,
            bool isPreconditioning,
            bool smartPreconditioning,
            bool isAutoConditioningOn,
            long timestamp)
        {
            InsideTemperature = insideTemperature;
            OutsideTemperature = outsideTemperature;
            DriverTemperatureSetting = driverTemperatureSetting;
            PassengerTemperatureSetting = passengerTemperatureSetting;
            IsFrontDefrosterOn = isFrontDefrosterOn;
            IsRearDefrosterOn = isRearDefrosterOn;
            FanStatus = fanStatus;
            IsClimateOn = isClimateOn;
            MinAvailableTemperature = minAvailableTemperature;
            MaxAvailableTemperature = maxAvailableTemperature;
            SeatHeaterLeft = seatHeaterLeft;
            SeatHeaterRight = seatHeaterRight;
            SeatHeaterRearLeft = seatHeaterRearLeft;
            SeatHeaterRearRight = seatHeaterRearRight;
            SeatHeaterRearCenter = seatHeaterRearCenter;
            SeatHeaterRearRightBack = seatHeaterRearRightBack;
            SeatHeaterRearLeftBack = seatHeaterRearLeftBack;
            BatterHeater = batterHeater;
            BatteryHeaterNoPower = batteryHeaterNoPower;
            SteeringWheelHeater = steeringWheelHeater;
            WiperBladeHeater = wiperBladeHeater;
            SideMirrorHeater = sideMirrorHeater;
            IsPreconditioning = isPreconditioning;
            SmartPreconditioning = smartPreconditioning;
            IsAutoConditioningOn = isAutoConditioningOn;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Gets the inside temperature of the vehicle.
        /// </summary>
        public double? InsideTemperature { get; }

        /// <summary>
        /// Gets the outside temperature of the vehicle.
        /// </summary>
        public double? OutsideTemperature { get; }

        /// <summary>
        /// Gets the driver temperature setting.
        /// </summary>
        public double DriverTemperatureSetting { get; }

        /// <summary>
        /// Gets the passenger temperature setting.
        /// </summary>
        public double PassengerTemperatureSetting { get; }

        /// <summary>
        /// Gets a value indicating whether the front defroster is on or off.
        /// </summary>
        public bool IsFrontDefrosterOn { get; }

        /// <summary>
        /// Gets a value indicating whether the rear defroster is on or off.
        /// </summary>
        public bool IsRearDefrosterOn { get; }

        /// <summary>
        /// Gets the fan status.
        /// </summary>
        public int FanStatus { get; }

        /// <summary>
        /// Gets a value indicating whether the climate is on or off.
        /// </summary>
        public bool IsClimateOn { get; }

        /// <summary>
        /// Gets the min available temperature.
        /// </summary>
        public double MinAvailableTemperature { get; }

        /// <summary>
        /// Gets the max available temperature.
        /// </summary>
        public double MaxAvailableTemperature { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater left is on or off.
        /// </summary>
        public bool SeatHeaterLeft { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater right is on or off.
        /// </summary>
        public bool SeatHeaterRight { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear left is on or off.
        /// </summary>
        public bool SeatHeaterRearLeft { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear right is on or off.
        /// </summary>
        public bool SeatHeaterRearRight { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear center is on or off.
        /// </summary>
        public bool SeatHeaterRearCenter { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear right back is on or off.
        /// </summary>
        public bool SeatHeaterRearRightBack { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear left back is on or off.
        /// </summary>
        public bool SeatHeaterRearLeftBack { get; }

        /// <summary>
        /// Gets a value indicating whether the battery heater is on or off.
        /// </summary>
        public bool BatterHeater { get; }

        /// <summary>
        /// Gets a value indicating whether the battery heater has no power.
        /// </summary>
        public bool? BatteryHeaterNoPower { get; }

        /// <summary>
        /// Gets a value indicating whether the steering wheel heater is on or off.
        /// </summary>
        public bool SteeringWheelHeater { get; }

        /// <summary>
        /// Gets a value indicating whether the wiper blade heater is on or off.
        /// </summary>
        public bool WiperBladeHeater { get; }

        /// <summary>
        /// Gets a value indicating whether the side mirror heater is on or off.
        /// </summary>
        public bool SideMirrorHeater { get; }

        /// <summary>
        /// Gets a value indicating whether if the vehicle is pre-pre-conditioned.
        /// </summary>
        public bool IsPreconditioning { get; }

        /// <summary>
        /// Gets a value indicating whether if the vehicle is smart-pre-conditioned.
        /// </summary>
        public bool SmartPreconditioning { get; }

        /// <summary>
        /// Gets a value indicating whether if the auto conditioning is on.
        /// </summary>
        public bool? IsAutoConditioningOn { get; }

        /// <summary>
        /// Gets the millisecond Epoch timestamp when the <see cref="IState"/> was captured.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="IClimateState"/> was captured.
        /// </summary>
        public DateTime TimestampUtc => EpochConversion.FromMilliseconds(Timestamp);

        private string DebuggerDisplay =>
            $"{GetType().Name}";
    }
}
