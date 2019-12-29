// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The charge state of a <see cref="IVehicle"/>.
    /// </summary>
    public interface IChargeState : IState
    {
        /// <summary>
        /// Gets the charging state of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charging_state")]
        string? ChargingState { get; }

        /// <summary>
        /// Gets the type of fast charging.
        /// </summary>
        [JsonProperty("fast_charger_type")]
        string? FastChargerType { get; }

        /// <summary>
        /// Gets the brand of fast charging.
        /// </summary>
        [JsonProperty("fast_charger_brand")]
        string? FastChargerBrand { get; }

        /// <summary>
        /// Gets the charge limit <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_limit_soc")]
        long? ChargeLimitSoc { get; }

        /// <summary>
        /// Gets the standard charge limit of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_limit_soc_std")]
        long? ChargeLimitSocStd { get; }

        /// <summary>
        /// Gets the minimum change limit of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_limit_soc_min")]
        long? ChargeLimitSocMin { get; }

        /// <summary>
        /// Gets the maximum change limit of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_limit_soc_max")]
        long? ChargeLimitSocMax { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IVehicle"/> will change to max range.
        /// </summary>
        [JsonProperty("charge_to_max_range")]
        bool? ChargeToMaxRange { get; }

        /// <summary>
        /// Gets the counter of haw many times a <see cref="IVehicle"/> has been changed to maximum range.
        /// </summary>
        [JsonProperty("max_range_charge_counter")]
        long? MaxRangeChargeCounter { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IVehicle"/> is supercharging.
        /// </summary>
        [JsonProperty("fast_charger_present")]
        bool? FastChargerPresent { get; }

        /// <summary>
        /// Gets the batter range of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("battery_range")]
        double? BatteryRange { get; }

        /// <summary>
        /// Gets the estimated battery range of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("est_battery_range")]
        double? EstBatteryRange { get; }

        /// <summary>
        /// Gets the ideal battery range of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("ideal_battery_range")]
        double? IdealBatteryRange { get; }

        /// <summary>
        /// Gets the current battery level of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("battery_level")]
        long? BatteryLevel { get; }

        /// <summary>
        /// Gets the usable battery level of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("usable_battery_level")]
        long? UsableBatteryLevel { get; }

        /// <summary>
        /// Gets the energy added to a <see cref="IVehicle"/> at the last charge.
        /// </summary>
        [JsonProperty("charge_energy_added")]
        double? ChargeEnergyAdded { get; }

        /// <summary>
        /// Gets the rated miles added to a <see cref="IVehicle"/> at the last charge.
        /// </summary>
        [JsonProperty("charge_miles_added_rated")]
        double? ChargeMilesAddedRated { get; }

        /// <summary>
        /// Gets the ideal miles added to a <see cref="IVehicle"/> at the last charge.
        /// </summary>
        [JsonProperty("charge_miles_added_ideal")]
        long? ChargeMilesAddedIdeal { get; }

        /// <summary>
        /// Gets the charge voltage of a <see cref="IVehicle"/> when charging.
        /// </summary>
        [JsonProperty("charger_voltage")]
        long? ChargerVoltage { get; }

        /// <summary>
        /// Gets the charge pilot current of a <see cref="IVehicle"/> when charging.
        /// </summary>
        [JsonProperty("charger_pilot_current")]
        long? ChargerPilotCurrent { get; }

        /// <summary>
        /// Gets the charge actual current of a <see cref="IVehicle"/> when charging.
        /// </summary>
        [JsonProperty("charger_actual_current")]
        long? ChargerActualCurrent { get; }

        /// <summary>
        /// Gets the charge power of a <see cref="IVehicle"/> when charging.
        /// </summary>
        [JsonProperty("charger_power")]
        long? ChargerPower { get; }

        /// <summary>
        /// Gets the time in minutes to a full charge of a <see cref="IVehicle"/> when charging.
        /// </summary>
        [JsonProperty("time_to_full_charge")]
        long? TimeToFullCharge { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IVehicle"/> is trip charging.
        /// </summary>
        [JsonProperty("trip_charging")]
        bool? TripCharging { get; }

        /// <summary>
        /// Gets the charge rate of a <see cref="IVehicle"/> when charging.
        /// </summary>
        [JsonProperty("charge_rate")]
        long? ChargeRate { get; }

        /// <summary>
        /// Gets a value indicating whether the charge port of a <see cref="IVehicle"/> is open.
        /// </summary>
        [JsonProperty("charge_port_door_open")]
        bool? ChargePortDoorOpen { get; }

        /// <summary>
        /// Gets the type of the charge cable connected to a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("conn_charge_cable")]
        string? ConnChargeCable { get; }

        /// <summary>
        /// Gets the schedule charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("scheduled_charging_start_time")]
        long? ScheduledChargingStartTime { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> of the schedule charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonIgnore]
        DateTime? ScheduledChargingStartTimeUtc { get; }

        /// <summary>
        /// Gets a value indicating whether scheduled charging is pending for a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("scheduled_charging_pending")]
        bool? ScheduledChargingPending { get; }

        /// <summary>
        /// Gets a value indicating whether a user charge enable request has been made for a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("user_charge_enable_request")]
        bool? UserChargeEnableRequest { get; }

        /// <summary>
        /// Gets a value indicating whether a charge enable request has been made for a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_enable_request")]
        bool? ChargeEnableRequest { get; }

        /// <summary>
        /// Gets the charger phases of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charger_phases")]
        int? ChargerPhases { get; }

        /// <summary>
        /// Gets the charge port latch of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_port_latch")]
        string? ChargePortLatch { get; }

        /// <summary>
        /// Gets the charge current request of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_current_request")]
        long? ChargeCurrentRequest { get; }

        /// <summary>
        /// Gets the maximum charge current request of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("charge_current_request_max")]
        long? ChargeCurrentRequestMax { get; }

        /// <summary>
        /// Gets a value indicating whether managed charging is active for a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("managed_charging_active")]
        bool? ManagedChargingActive { get; }

        /// <summary>
        /// Gets a value indicating whether managed charging for <see cref="IVehicle"/> has been canceled by a user.
        /// </summary>
        [JsonProperty("managed_charging_user_canceled")]
        bool? ManagedChargingUserCanceled { get; }

        /// <summary>
        /// Gets the managed charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("managed_charging_start_time")]
        long? ManagedChargingStartTime { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> of the managed charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        [JsonIgnore]
        DateTime? ManagedChargingStartTimeUtc { get; }

        /// <summary>
        /// Gets a value indicating whether battery heating is on for a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("battery_heater_on")]
        bool? BatteryHeaterOn { get; }

        /// <summary>
        /// Gets a value indicating whether there is not enough power to heat a <see cref="IVehicle"/>.
        /// </summary>
        [JsonProperty("not_enough_power_to_heat")]
        bool? NotEnoughPowerToHeat { get; }
    }
}
