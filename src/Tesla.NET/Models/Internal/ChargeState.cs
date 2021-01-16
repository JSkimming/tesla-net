// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// The charge state of a <see cref="IVehicle"/>.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ChargeState : IChargeState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeState"/> class.
        /// </summary>
        /// <param name="chargingState">The <see cref="ChargingState"/>.</param>
        /// <param name="fastChargerType">The <see cref="FastChargerType"/>.</param>
        /// <param name="fastChargerBrand">The <see cref="FastChargerBrand"/>.</param>
        /// <param name="chargeLimitSoc">The <see cref="ChargeLimitSoc"/>.</param>
        /// <param name="chargeLimitSocStd">The <see cref="ChargeLimitSocStd"/>.</param>
        /// <param name="chargeLimitSocMin">The <see cref="ChargeLimitSocMin"/>.</param>
        /// <param name="chargeLimitSocMax">The <see cref="ChargeLimitSocMax"/>.</param>
        /// <param name="chargeToMaxRange">The <see cref="ChargeToMaxRange"/>.</param>
        /// <param name="maxRangeChargeCounter">The <see cref="MaxRangeChargeCounter"/>.</param>
        /// <param name="fastChargerPresent">The <see cref="FastChargerPresent"/>.</param>
        /// <param name="batteryRange">The <see cref="BatteryRange"/>.</param>
        /// <param name="estBatteryRange">The <see cref="EstBatteryRange"/>.</param>
        /// <param name="idealBatteryRange">The <see cref="IdealBatteryRange"/>.</param>
        /// <param name="batteryLevel">The <see cref="BatteryLevel"/>.</param>
        /// <param name="usableBatteryLevel">The <see cref="UsableBatteryLevel"/>.</param>
        /// <param name="chargeEnergyAdded">The <see cref="ChargeEnergyAdded"/>.</param>
        /// <param name="chargeMilesAddedRated">The <see cref="ChargeMilesAddedRated"/>.</param>
        /// <param name="chargeMilesAddedIdeal">The <see cref="ChargeMilesAddedIdeal"/>.</param>
        /// <param name="chargerVoltage">The <see cref="ChargerVoltage"/>.</param>
        /// <param name="chargerPilotCurrent">The <see cref="ChargerPilotCurrent"/>.</param>
        /// <param name="chargerActualCurrent">The <see cref="ChargerActualCurrent"/>.</param>
        /// <param name="chargerPower">The <see cref="ChargerPower"/>.</param>
        /// <param name="timeToFullCharge">The <see cref="TimeToFullCharge"/>.</param>
        /// <param name="tripCharging">The <see cref="TripCharging"/>.</param>
        /// <param name="chargeRate">The <see cref="ChargeRate"/>.</param>
        /// <param name="chargePortDoorOpen">The <see cref="ChargePortDoorOpen"/>.</param>
        /// <param name="connChargeCable">The <see cref="ConnChargeCable"/>.</param>
        /// <param name="scheduledChargingStartTime">The <see cref="ScheduledChargingStartTime"/>.</param>
        /// <param name="scheduledChargingPending">The <see cref="ScheduledChargingPending"/>.</param>
        /// <param name="userChargeEnableRequest">The <see cref="UserChargeEnableRequest"/>.</param>
        /// <param name="chargeEnableRequest">The <see cref="ChargeEnableRequest"/>.</param>
        /// <param name="chargerPhases">The <see cref="ChargerPhases"/>.</param>
        /// <param name="chargePortLatch">The <see cref="ChargePortLatch"/>.</param>
        /// <param name="chargeCurrentRequest">The <see cref="ChargeCurrentRequest"/>.</param>
        /// <param name="chargeCurrentRequestMax">The <see cref="ChargeCurrentRequestMax"/>.</param>
        /// <param name="managedChargingActive">The <see cref="ManagedChargingActive"/>.</param>
        /// <param name="managedChargingUserCanceled">The <see cref="ManagedChargingUserCanceled"/>.</param>
        /// <param name="managedChargingStartTime">The <see cref="ManagedChargingStartTime"/>.</param>
        /// <param name="batteryHeaterOn">The <see cref="BatteryHeaterOn"/>.</param>
        /// <param name="notEnoughPowerToHeat">The <see cref="NotEnoughPowerToHeat"/>.</param>
        /// <param name="timestamp">The <see cref="Timestamp"/>.</param>
        public ChargeState(
            string? chargingState = null,
            string? fastChargerType = null,
            string? fastChargerBrand = null,
            long? chargeLimitSoc = null,
            long? chargeLimitSocStd = null,
            long? chargeLimitSocMin = null,
            long? chargeLimitSocMax = null,
            bool? chargeToMaxRange = null,
            long? maxRangeChargeCounter = null,
            bool? fastChargerPresent = null,
            double? batteryRange = null,
            double? estBatteryRange = null,
            double? idealBatteryRange = null,
            long? batteryLevel = null,
            long? usableBatteryLevel = null,
            double? chargeEnergyAdded = null,
            double? chargeMilesAddedRated = null,
            long? chargeMilesAddedIdeal = null,
            long? chargerVoltage = null,
            long? chargerPilotCurrent = null,
            long? chargerActualCurrent = null,
            long? chargerPower = null,
            long? timeToFullCharge = null,
            bool? tripCharging = null,
            long? chargeRate = null,
            bool? chargePortDoorOpen = null,
            string? connChargeCable = null,
            long? scheduledChargingStartTime = null,
            bool? scheduledChargingPending = null,
            bool? userChargeEnableRequest = null,
            bool? chargeEnableRequest = null,
            int? chargerPhases = null,
            string? chargePortLatch = null,
            long? chargeCurrentRequest = null,
            long? chargeCurrentRequestMax = null,
            bool? managedChargingActive = null,
            bool? managedChargingUserCanceled = null,
            long? managedChargingStartTime = null,
            bool? batteryHeaterOn = null,
            bool? notEnoughPowerToHeat = null,
            long timestamp = 0)
        {
            ChargingState = chargingState;
            FastChargerType = fastChargerType;
            FastChargerBrand = fastChargerBrand;
            ChargeLimitSoc = chargeLimitSoc;
            ChargeLimitSocStd = chargeLimitSocStd;
            ChargeLimitSocMin = chargeLimitSocMin;
            ChargeLimitSocMax = chargeLimitSocMax;
            ChargeToMaxRange = chargeToMaxRange;
            MaxRangeChargeCounter = maxRangeChargeCounter;
            FastChargerPresent = fastChargerPresent;
            BatteryRange = batteryRange;
            EstBatteryRange = estBatteryRange;
            IdealBatteryRange = idealBatteryRange;
            BatteryLevel = batteryLevel;
            UsableBatteryLevel = usableBatteryLevel;
            ChargeEnergyAdded = chargeEnergyAdded;
            ChargeMilesAddedRated = chargeMilesAddedRated;
            ChargeMilesAddedIdeal = chargeMilesAddedIdeal;
            ChargerVoltage = chargerVoltage;
            ChargerPilotCurrent = chargerPilotCurrent;
            ChargerActualCurrent = chargerActualCurrent;
            ChargerPower = chargerPower;
            TimeToFullCharge = timeToFullCharge;
            TripCharging = tripCharging;
            ChargeRate = chargeRate;
            ChargePortDoorOpen = chargePortDoorOpen;
            ConnChargeCable = connChargeCable;
            ScheduledChargingStartTime = scheduledChargingStartTime;
            ScheduledChargingPending = scheduledChargingPending;
            UserChargeEnableRequest = userChargeEnableRequest;
            ChargeEnableRequest = chargeEnableRequest;
            ChargerPhases = chargerPhases;
            ChargePortLatch = chargePortLatch;
            ChargeCurrentRequest = chargeCurrentRequest;
            ChargeCurrentRequestMax = chargeCurrentRequestMax;
            ManagedChargingActive = managedChargingActive;
            ManagedChargingUserCanceled = managedChargingUserCanceled;
            ManagedChargingStartTime = managedChargingStartTime;
            BatteryHeaterOn = batteryHeaterOn;
            NotEnoughPowerToHeat = notEnoughPowerToHeat;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Gets the charging state of a <see cref="IVehicle"/>.
        /// </summary>
        public string? ChargingState { get; }

        /// <summary>
        /// Gets the type of fast charging.
        /// </summary>
        public string? FastChargerType { get; }

        /// <summary>
        /// Gets the brand of fast charging.
        /// </summary>
        public string? FastChargerBrand { get; }

        /// <summary>
        /// Gets the charge limit <see cref="IVehicle"/>.
        /// </summary>
        public long? ChargeLimitSoc { get; }

        /// <summary>
        /// Gets the standard charge limit of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ChargeLimitSocStd { get; }

        /// <summary>
        /// Gets the minimum change limit of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ChargeLimitSocMin { get; }

        /// <summary>
        /// Gets the maximum change limit of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ChargeLimitSocMax { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IVehicle"/> will change to max range.
        /// </summary>
        public bool? ChargeToMaxRange { get; }

        /// <summary>
        /// Gets the counter of haw many times a <see cref="IVehicle"/> has been changed to maximum range.
        /// </summary>
        public long? MaxRangeChargeCounter { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IVehicle"/> is supercharging.
        /// </summary>
        public bool? FastChargerPresent { get; }

        /// <summary>
        /// Gets the batter range of a <see cref="IVehicle"/>.
        /// </summary>
        public double? BatteryRange { get; }

        /// <summary>
        /// Gets the estimated battery range of a <see cref="IVehicle"/>.
        /// </summary>
        public double? EstBatteryRange { get; }

        /// <summary>
        /// Gets the ideal battery range of a <see cref="IVehicle"/>.
        /// </summary>
        public double? IdealBatteryRange { get; }

        /// <summary>
        /// Gets the current battery level of a <see cref="IVehicle"/>.
        /// </summary>
        public long? BatteryLevel { get; }

        /// <summary>
        /// Gets the usable battery level of a <see cref="IVehicle"/>.
        /// </summary>
        public long? UsableBatteryLevel { get; }

        /// <summary>
        /// Gets the energy added to a <see cref="IVehicle"/> at the last charge.
        /// </summary>
        public double? ChargeEnergyAdded { get; }

        /// <summary>
        /// Gets the rated miles added to a <see cref="IVehicle"/> at the last charge.
        /// </summary>
        public double? ChargeMilesAddedRated { get; }

        /// <summary>
        /// Gets the ideal miles added to a <see cref="IVehicle"/> at the last charge.
        /// </summary>
        public long? ChargeMilesAddedIdeal { get; }

        /// <summary>
        /// Gets the charge voltage of a <see cref="IVehicle"/> when charging.
        /// </summary>
        public long? ChargerVoltage { get; }

        /// <summary>
        /// Gets the charge pilot current of a <see cref="IVehicle"/> when charging.
        /// </summary>
        public long? ChargerPilotCurrent { get; }

        /// <summary>
        /// Gets the charge actual current of a <see cref="IVehicle"/> when charging.
        /// </summary>
        public long? ChargerActualCurrent { get; }

        /// <summary>
        /// Gets the charge power of a <see cref="IVehicle"/> when charging.
        /// </summary>
        public long? ChargerPower { get; }

        /// <summary>
        /// Gets the time in minutes to a full charge of a <see cref="IVehicle"/> when charging.
        /// </summary>
        public long? TimeToFullCharge { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IVehicle"/> is trip charging.
        /// </summary>
        public bool? TripCharging { get; }

        /// <summary>
        /// Gets the charge rate of a <see cref="IVehicle"/> when charging.
        /// </summary>
        public long? ChargeRate { get; }

        /// <summary>
        /// Gets a value indicating whether the charge port of a <see cref="IVehicle"/> is open.
        /// </summary>
        public bool? ChargePortDoorOpen { get; }

        /// <summary>
        /// Gets the type of the charge cable connected to a <see cref="IVehicle"/>.
        /// </summary>
        public string? ConnChargeCable { get; }

        /// <summary>
        /// Gets the schedule charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ScheduledChargingStartTime { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> of the schedule charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        public DateTime? ScheduledChargingStartTimeUtc => EpochConversion.FromSeconds(ScheduledChargingStartTime);

        /// <summary>
        /// Gets a value indicating whether scheduled charging is pending for a <see cref="IVehicle"/>.
        /// </summary>
        public bool? ScheduledChargingPending { get; }

        /// <summary>
        /// Gets a value indicating whether a user charge enable request has been made for a <see cref="IVehicle"/>.
        /// </summary>
        public bool? UserChargeEnableRequest { get; }

        /// <summary>
        /// Gets a value indicating whether a charge enable request has been made for a <see cref="IVehicle"/>.
        /// </summary>
        public bool? ChargeEnableRequest { get; }

        /// <summary>
        /// Gets the charger phases of a <see cref="IVehicle"/>.
        /// </summary>
        public int? ChargerPhases { get; }

        /// <summary>
        /// Gets the charge port latch of a <see cref="IVehicle"/>.
        /// </summary>
        public string? ChargePortLatch { get; }

        /// <summary>
        /// Gets the charge current request of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ChargeCurrentRequest { get; }

        /// <summary>
        /// Gets the maximum charge current request of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ChargeCurrentRequestMax { get; }

        /// <summary>
        /// Gets a value indicating whether managed charging is active for a <see cref="IVehicle"/>.
        /// </summary>
        public bool? ManagedChargingActive { get; }

        /// <summary>
        /// Gets a value indicating whether managed charging for <see cref="IVehicle"/> has been canceled by a user.
        /// </summary>
        public bool? ManagedChargingUserCanceled { get; }

        /// <summary>
        /// Gets the managed charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        public long? ManagedChargingStartTime { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> of the managed charging start time of a <see cref="IVehicle"/>.
        /// </summary>
        public DateTime? ManagedChargingStartTimeUtc => EpochConversion.FromSeconds(ManagedChargingStartTime);

        /// <summary>
        /// Gets a value indicating whether battery heating is on for a <see cref="IVehicle"/>.
        /// </summary>
        public bool? BatteryHeaterOn { get; }

        /// <summary>
        /// Gets a value indicating whether there is not enough power to heat a <see cref="IVehicle"/>.
        /// </summary>
        public bool? NotEnoughPowerToHeat { get; }

        /// <summary>
        /// Gets the millisecond Epoch timestamp when the <see cref="IChargeState"/> was captured.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="IChargeState"/> was captured.
        /// </summary>
        public DateTime TimestampUtc => EpochConversion.FromMilliseconds(Timestamp);

        private string DebuggerDisplay =>
            $"{GetType().Name}: {ChargingState} @ {BatteryLevel}% giving " +
            $"{EstBatteryRange.GetValueOrDefault().ToString(CultureInfo.InvariantCulture)}";
    }
}
