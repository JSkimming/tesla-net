// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The climate state of a <see cref="IVehicle"/>.
    /// </summary>
    public interface IClimateState : IState
    {
        /// <summary>
        /// Gets the inside temperature of the vehicle.
        /// </summary>
        [JsonProperty("inside_temp")]
        double? InsideTemperature { get; }

        /// <summary>
        /// Gets the outside temperature of the vehicle.
        /// </summary>
        [JsonProperty("outside_temp")]
        double? OutsideTemperature { get; }

        /// <summary>
        /// Gets the driver temperature setting.
        /// </summary>
        [JsonProperty("driver_temp_setting")]
        double DriverTemperatureSetting { get; }

        /// <summary>
        /// Gets the passenger temperature setting.
        /// </summary>
        [JsonProperty("passenger_temp_setting")]
        double PassengerTemperatureSetting { get; }

        /// <summary>
        /// Gets a value indicating whether the front defroster is on or off.
        /// </summary>
        [JsonProperty("is_front_defroster_on")]
        bool IsFrontDefrosterOn { get; }

        /// <summary>
        /// Gets a value indicating whether the rear defroster is on or off.
        /// </summary>
        [JsonProperty("is_rear_defroster_on")]
        bool IsRearDefrosterOn { get; }

        /// <summary>
        /// Gets the fan status.
        /// </summary>
        [JsonProperty("fan_status")]
        int FanStatus { get; }

        /// <summary>
        /// Gets a value indicating whether the climate is on or off.
        /// </summary>
        [JsonProperty("is_climate_on")]
        bool IsClimateOn { get; }

        /// <summary>
        /// Gets the min available temperature.
        /// </summary>
        [JsonProperty("min_avail_temp")]
        double MinAvailableTemperature { get; }

        /// <summary>
        /// Gets the max available temperature.
        /// </summary>
        [JsonProperty("max_avail_temp")]
        double MaxAvailableTemperature { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater left is on or off.
        /// </summary>
        [JsonProperty("seat_heater_left")]
        bool SeatHeaterLeft { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater right is on or off.
        /// </summary>
        [JsonProperty("seat_heater_right")]
        bool SeatHeaterRight { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear left is on or off.
        /// </summary>
        [JsonProperty("seat_heater_rear_left")]
        bool SeatHeaterRearLeft { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear right is on or off.
        /// </summary>
        [JsonProperty("seat_heater_rear_right")]
        bool SeatHeaterRearRight { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear center is on or off.
        /// </summary>
        [JsonProperty("seat_heater_rear_center")]
        bool SeatHeaterRearCenter { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear right back is on or off.
        /// </summary>
        [JsonProperty("seat_heater_rear_right_back")]
        bool SeatHeaterRearRightBack { get; }

        /// <summary>
        /// Gets a value indicating whether the seat heater rear left back is on or off.
        /// </summary>
        [JsonProperty("seat_heater_rear_left_back")]
        bool SeatHeaterRearLeftBack { get; }

        /// <summary>
        /// Gets a value indicating whether the battery heater is on or off.
        /// </summary>
        [JsonProperty("battery_heater")]
        bool BatterHeater { get; }

        /// <summary>
        /// Gets a value indicating whether the battery heater has no power.
        /// </summary>
        [JsonProperty("battery_heater_no_power")]
        bool? BatteryHeaterNoPower { get; }

        /// <summary>
        /// Gets a value indicating whether the steering wheel heater is on or off.
        /// </summary>
        [JsonProperty("steering_wheel_heater")]
        bool SteeringWheelHeater { get; }

        /// <summary>
        /// Gets a value indicating whether the wiper blade heater is on or off.
        /// </summary>
        [JsonProperty("wiper_blade_heater")]
        bool WiperBladeHeater { get; }

        /// <summary>
        /// Gets a value indicating whether the side mirror heater is on or off.
        /// </summary>
        [JsonProperty("side_mirror_heaters")]
        bool SideMirrorHeater { get; }

        /// <summary>
        /// Gets a value indicating whether if the vehicle is pre-pre-conditioned.
        /// </summary>
        [JsonProperty("is_preconditioning")]
        bool IsPreconditioning { get; }

        /// <summary>
        /// Gets a value indicating whether if the vehicle is smart-pre-conditioned.
        /// </summary>
        [JsonProperty("smart_preconditioning")]
        bool SmartPreconditioning { get; }

        /// <summary>
        /// Gets a value indicating whether if the auto conditioning is on.
        /// </summary>
        [JsonProperty("is_auto_conditioning_on")]
        bool? IsAutoConditioningOn { get; }
    }
}
