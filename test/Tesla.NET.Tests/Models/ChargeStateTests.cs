// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using AutoFixture;
    using FluentAssertions;
    using Newtonsoft.Json.Linq;
    using Xunit;
    using Xunit.Abstractions;

    public class When_serializing_ChargeState_Should_serialize : FixtureContext
    {
        private readonly ChargeState _sut;
        private readonly JObject _json;

        public When_serializing_ChargeState_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<ChargeState>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void forty_one_properties() => _json.Count.Should().Be(41);

        [Fact]
        public void charging_state() =>
            _json["charging_state"].Value<string>().Should().Be(_sut.ChargingState);

        [Fact]
        public void fast_charger_type() =>
            _json["fast_charger_type"].Value<string>().Should().Be(_sut.FastChargerType);

        [Fact]
        public void fast_charger_brand() =>
            _json["fast_charger_brand"].Value<string>().Should().Be(_sut.FastChargerBrand);

        [Fact]
        public void charge_limit_soc() =>
            _json["charge_limit_soc"].Value<long?>().Should().Be(_sut.ChargeLimitSoc);

        [Fact]
        public void charge_limit_soc_std() =>
            _json["charge_limit_soc_std"].Value<long?>().Should().Be(_sut.ChargeLimitSocStd);

        [Fact]
        public void charge_limit_soc_min() =>
            _json["charge_limit_soc_min"].Value<long?>().Should().Be(_sut.ChargeLimitSocMin);

        [Fact]
        public void charge_limit_soc_max() =>
            _json["charge_limit_soc_max"].Value<long?>().Should().Be(_sut.ChargeLimitSocMax);

        [Fact]
        public void charge_to_max_range() =>
            _json["charge_to_max_range"].Value<bool?>().Should().Be(_sut.ChargeToMaxRange);

        [Fact]
        public void max_range_charge_counter() =>
            _json["max_range_charge_counter"].Value<long?>().Should().Be(_sut.MaxRangeChargeCounter);

        [Fact]
        public void fast_charger_present() =>
            _json["fast_charger_present"].Value<bool?>().Should().Be(_sut.FastChargerPresent);

        [Fact]
        public void battery_range() =>
            _json["battery_range"].Value<double?>().Should().Be(_sut.BatteryRange);

        [Fact]
        public void est_battery_range() =>
            _json["est_battery_range"].Value<double?>().Should().Be(_sut.EstBatteryRange);

        [Fact]
        public void ideal_battery_range() =>
            _json["ideal_battery_range"].Value<double?>().Should().Be(_sut.IdealBatteryRange);

        [Fact]
        public void battery_level() =>
            _json["battery_level"].Value<long?>().Should().Be(_sut.BatteryLevel);

        [Fact]
        public void usable_battery_level() =>
            _json["usable_battery_level"].Value<long?>().Should().Be(_sut.UsableBatteryLevel);

        [Fact]
        public void charge_energy_added() =>
            _json["charge_energy_added"].Value<double?>().Should().Be(_sut.ChargeEnergyAdded);

        [Fact]
        public void charge_miles_added_rated() =>
            _json["charge_miles_added_rated"].Value<double?>().Should().Be(_sut.ChargeMilesAddedRated);

        [Fact]
        public void charge_miles_added_ideal() =>
            _json["charge_miles_added_ideal"].Value<long?>().Should().Be(_sut.ChargeMilesAddedIdeal);

        [Fact]
        public void charger_voltage() =>
            _json["charger_voltage"].Value<long?>().Should().Be(_sut.ChargerVoltage);

        [Fact]
        public void charger_pilot_current() =>
            _json["charger_pilot_current"].Value<long?>().Should().Be(_sut.ChargerPilotCurrent);

        [Fact]
        public void charger_actual_current() =>
            _json["charger_actual_current"].Value<long?>().Should().Be(_sut.ChargerActualCurrent);

        [Fact]
        public void charger_power() =>
            _json["charger_power"].Value<long?>().Should().Be(_sut.ChargerPower);

        [Fact]
        public void time_to_full_charge() =>
            _json["time_to_full_charge"].Value<long?>().Should().Be(_sut.TimeToFullCharge);

        [Fact]
        public void trip_charging() =>
            _json["trip_charging"].Value<bool?>().Should().Be(_sut.TripCharging);

        [Fact]
        public void charge_rate() =>
            _json["charge_rate"].Value<long?>().Should().Be(_sut.ChargeRate);

        [Fact]
        public void charge_port_door_open() =>
            _json["charge_port_door_open"].Value<bool?>().Should().Be(_sut.ChargePortDoorOpen);

        [Fact]
        public void conn_charge_cable() =>
            _json["conn_charge_cable"].Value<string>().Should().Be(_sut.ConnChargeCable);

        [Fact]
        public void scheduled_charging_start_time() =>
            _json["scheduled_charging_start_time"].Value<long?>().Should().Be(_sut.ScheduledChargingStartTime);

        [Fact]
        public void scheduled_charging_pending() =>
            _json["scheduled_charging_pending"].Value<bool?>().Should().Be(_sut.ScheduledChargingPending);

        [Fact]
        public void user_charge_enable_request() =>
            _json["user_charge_enable_request"].Value<bool?>().Should().Be(_sut.UserChargeEnableRequest);

        [Fact]
        public void charge_enable_request() =>
            _json["charge_enable_request"].Value<bool?>().Should().Be(_sut.ChargeEnableRequest);

        [Fact]
        public void charger_phases() =>
            _json["charger_phases"].Value<int?>().Should().Be(_sut.ChargerPhases);

        [Fact]
        public void charge_port_latch() =>
            _json["charge_port_latch"].Value<string>().Should().Be(_sut.ChargePortLatch);

        [Fact]
        public void charge_current_request() =>
            _json["charge_current_request"].Value<long?>().Should().Be(_sut.ChargeCurrentRequest);

        [Fact]
        public void charge_current_request_max() =>
            _json["charge_current_request_max"].Value<long?>().Should().Be(_sut.ChargeCurrentRequestMax);

        [Fact]
        public void managed_charging_active() =>
            _json["managed_charging_active"].Value<bool?>().Should().Be(_sut.ManagedChargingActive);

        [Fact]
        public void managed_charging_user_canceled() =>
            _json["managed_charging_user_canceled"].Value<bool?>().Should().Be(_sut.ManagedChargingUserCanceled);

        [Fact]
        public void managed_charging_start_time() =>
            _json["managed_charging_start_time"].Value<long?>().Should().Be(_sut.ManagedChargingStartTime);

        [Fact]
        public void battery_heater_on() =>
            _json["battery_heater_on"].Value<bool?>().Should().Be(_sut.BatteryHeaterOn);

        [Fact]
        public void not_enough_power_to_heat() =>
            _json["not_enough_power_to_heat"].Value<bool?>().Should().Be(_sut.NotEnoughPowerToHeat);

        [Fact]
        public void timestamp() =>
            _json["timestamp"].Value<long>().Should().Be(_sut.Timestamp);
    }

    public class When_serializing_and_deserializing_ChargeState : FixtureContext
    {
        private readonly ChargeState _expected;
        private readonly ChargeState _actual;

        public When_serializing_and_deserializing_ChargeState(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<ChargeState>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<ChargeState>();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.ShouldBeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_ChargeState_Should_deserialize : FixtureContext
    {
        private readonly ChargeState _sut;
        private readonly JObject _json;

        public When_deserializing_ChargeState_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.ChargeState;
            _sut = _json.ToObject<ChargeState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void charging_state() =>
            _sut.ChargingState.Should().Be(_json["charging_state"].Value<string>());

        [Fact]
        public void fast_charger_type() =>
            _sut.FastChargerType.Should().Be(_json["fast_charger_type"].Value<string>());

        [Fact]
        public void fast_charger_brand() =>
            _sut.FastChargerBrand.Should().Be(_json["fast_charger_brand"].Value<string>());

        [Fact]
        public void charge_limit_soc() =>
            _sut.ChargeLimitSoc.Should().Be(_json["charge_limit_soc"].Value<long?>());

        [Fact]
        public void charge_limit_soc_std() =>
            _sut.ChargeLimitSocStd.Should().Be(_json["charge_limit_soc_std"].Value<long?>());

        [Fact]
        public void charge_limit_soc_min() =>
            _sut.ChargeLimitSocMin.Should().Be(_json["charge_limit_soc_min"].Value<long?>());

        [Fact]
        public void charge_limit_soc_max() =>
            _sut.ChargeLimitSocMax.Should().Be(_json["charge_limit_soc_max"].Value<long?>());

        [Fact]
        public void charge_to_max_range() =>
            _sut.ChargeToMaxRange.Should().Be(_json["charge_to_max_range"].Value<bool?>());

        [Fact]
        public void max_range_charge_counter() =>
            _sut.MaxRangeChargeCounter.Should().Be(_json["max_range_charge_counter"].Value<long?>());

        [Fact]
        public void fast_charger_present() =>
            _sut.FastChargerPresent.Should().Be(_json["fast_charger_present"].Value<bool?>());

        [Fact]
        public void battery_range() =>
            _sut.BatteryRange.Should().Be(_json["battery_range"].Value<double?>());

        [Fact]
        public void est_battery_range() =>
            _sut.EstBatteryRange.Should().Be(_json["est_battery_range"].Value<double?>());

        [Fact]
        public void ideal_battery_range() =>
            _sut.IdealBatteryRange.Should().Be(_json["ideal_battery_range"].Value<double?>());

        [Fact]
        public void battery_level() =>
            _sut.BatteryLevel.Should().Be(_json["battery_level"].Value<long?>());

        [Fact]
        public void usable_battery_level() =>
            _sut.UsableBatteryLevel.Should().Be(_json["usable_battery_level"].Value<long?>());

        [Fact]
        public void charge_energy_added() =>
            _sut.ChargeEnergyAdded.Should().Be(_json["charge_energy_added"].Value<double?>());

        [Fact]
        public void charge_miles_added_rated() =>
            _sut.ChargeMilesAddedRated.Should().Be(_json["charge_miles_added_rated"].Value<double?>());

        [Fact]
        public void charge_miles_added_ideal() =>
            _sut.ChargeMilesAddedIdeal.Should().Be(_json["charge_miles_added_ideal"].Value<long?>());

        [Fact]
        public void charger_voltage() =>
            _sut.ChargerVoltage.Should().Be(_json["charger_voltage"].Value<long?>());

        [Fact]
        public void charger_pilot_current() =>
            _sut.ChargerPilotCurrent.Should().Be(_json["charger_pilot_current"].Value<long?>());

        [Fact]
        public void charger_actual_current() =>
            _sut.ChargerActualCurrent.Should().Be(_json["charger_actual_current"].Value<long?>());

        [Fact]
        public void charger_power() =>
            _sut.ChargerPower.Should().Be(_json["charger_power"].Value<long?>());

        [Fact]
        public void time_to_full_charge() =>
            _sut.TimeToFullCharge.Should().Be(_json["time_to_full_charge"].Value<long?>());

        [Fact]
        public void trip_charging() =>
            _sut.TripCharging.Should().Be(_json["trip_charging"].Value<bool?>());

        [Fact]
        public void charge_rate() =>
            _sut.ChargeRate.Should().Be(_json["charge_rate"].Value<long?>());

        [Fact]
        public void charge_port_door_open() =>
            _sut.ChargePortDoorOpen.Should().Be(_json["charge_port_door_open"].Value<bool?>());

        [Fact]
        public void conn_charge_cable() =>
            _sut.ConnChargeCable.Should().Be(_json["conn_charge_cable"].Value<string>());

        [Fact]
        public void scheduled_charging_start_time() =>
            _sut.ScheduledChargingStartTime.Should().Be(_json["scheduled_charging_start_time"].Value<long?>());

        [Fact]
        public void scheduled_charging_pending() =>
            _sut.ScheduledChargingPending.Should().Be(_json["scheduled_charging_pending"].Value<bool?>());

        [Fact]
        public void user_charge_enable_request() =>
            _sut.UserChargeEnableRequest.Should().Be(_json["user_charge_enable_request"].Value<bool?>());

        [Fact]
        public void charge_enable_request() =>
            _sut.ChargeEnableRequest.Should().Be(_json["charge_enable_request"].Value<bool?>());

        [Fact]
        public void charger_phases() =>
            _sut.ChargerPhases.Should().Be(_json["charger_phases"].Value<int?>());

        [Fact]
        public void charge_port_latch() =>
            _sut.ChargePortLatch.Should().Be(_json["charge_port_latch"].Value<string>());

        [Fact]
        public void charge_current_request() =>
            _sut.ChargeCurrentRequest.Should().Be(_json["charge_current_request"].Value<long?>());

        [Fact]
        public void charge_current_request_max() =>
            _sut.ChargeCurrentRequestMax.Should().Be(_json["charge_current_request_max"].Value<long?>());

        [Fact]
        public void managed_charging_active() =>
            _sut.ManagedChargingActive.Should().Be(_json["managed_charging_active"].Value<bool?>());

        [Fact]
        public void managed_charging_user_canceled() =>
            _sut.ManagedChargingUserCanceled.Should().Be(_json["managed_charging_user_canceled"].Value<bool?>());

        [Fact]
        public void managed_charging_start_time() =>
            _sut.ManagedChargingStartTime.Should().Be(_json["managed_charging_start_time"].Value<long?>());

        [Fact]
        public void battery_heater_on() =>
            _sut.BatteryHeaterOn.Should().Be(_json["battery_heater_on"].Value<bool?>());

        [Fact]
        public void not_enough_power_to_heat() =>
            _sut.NotEnoughPowerToHeat.Should().Be(_json["not_enough_power_to_heat"].Value<bool?>());

        [Fact]
        public void timestamp() =>
            _sut.Timestamp.Should().Be(_json["timestamp"].Value<long?>());
    }

    public class When_deserializing_ChargeState_with_minimal_data_Should_default
    {
        private readonly ChargeState _sut;
        private readonly JObject _json;

        public When_deserializing_ChargeState_with_minimal_data_Should_default(ITestOutputHelper output)
        {
            _json = SampleJson.ChargeStateMinimal;
            _sut = _json.ToObject<ChargeState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void charging_state() => _sut.ChargingState.Should().BeNull();

        [Fact]
        public void fast_charger_type() => _sut.FastChargerType.Should().BeNull();

        [Fact]
        public void fast_charger_brand() => _sut.FastChargerBrand.Should().BeNull();

        [Fact]
        public void charge_limit_soc() => _sut.ChargeLimitSoc.Should().BeNull();

        [Fact]
        public void charge_limit_soc_std() => _sut.ChargeLimitSocStd.Should().BeNull();

        [Fact]
        public void charge_limit_soc_min() => _sut.ChargeLimitSocMin.Should().BeNull();

        [Fact]
        public void charge_limit_soc_max() => _sut.ChargeLimitSocMax.Should().BeNull();

        [Fact]
        public void charge_to_max_range() => _sut.ChargeToMaxRange.Should().BeNull();

        [Fact]
        public void max_range_charge_counter() => _sut.MaxRangeChargeCounter.Should().BeNull();

        [Fact]
        public void fast_charger_present() => _sut.FastChargerPresent.Should().BeNull();

        [Fact]
        public void battery_range() => _sut.BatteryRange.Should().BeNull();

        [Fact]
        public void est_battery_range() => _sut.EstBatteryRange.Should().BeNull();

        [Fact]
        public void ideal_battery_range() => _sut.IdealBatteryRange.Should().BeNull();

        [Fact]
        public void battery_level() => _sut.BatteryLevel.Should().BeNull();

        [Fact]
        public void usable_battery_level() => _sut.UsableBatteryLevel.Should().BeNull();

        [Fact]
        public void charge_energy_added() => _sut.ChargeEnergyAdded.Should().BeNull();

        [Fact]
        public void charge_miles_added_rated() => _sut.ChargeMilesAddedRated.Should().BeNull();

        [Fact]
        public void charge_miles_added_ideal() => _sut.ChargeMilesAddedIdeal.Should().BeNull();

        [Fact]
        public void charger_voltage() => _sut.ChargerVoltage.Should().BeNull();

        [Fact]
        public void charger_pilot_current() => _sut.ChargerPilotCurrent.Should().BeNull();

        [Fact]
        public void charger_actual_current() => _sut.ChargerActualCurrent.Should().BeNull();

        [Fact]
        public void charger_power() => _sut.ChargerPower.Should().BeNull();

        [Fact]
        public void time_to_full_charge() => _sut.TimeToFullCharge.Should().BeNull();

        [Fact]
        public void trip_charging() => _sut.TripCharging.Should().BeNull();

        [Fact]
        public void charge_rate() => _sut.ChargeRate.Should().BeNull();

        [Fact]
        public void charge_port_door_open() => _sut.ChargePortDoorOpen.Should().BeNull();

        [Fact]
        public void conn_charge_cable() => _sut.ConnChargeCable.Should().BeNull();

        [Fact]
        public void scheduled_charging_start_time() => _sut.ScheduledChargingStartTime.Should().BeNull();

        [Fact]
        public void scheduled_charging_pending() => _sut.ScheduledChargingPending.Should().BeNull();

        [Fact]
        public void user_charge_enable_request() => _sut.UserChargeEnableRequest.Should().BeNull();

        [Fact]
        public void charge_enable_request() => _sut.ChargeEnableRequest.Should().BeNull();

        [Fact]
        public void charger_phases() => _sut.ChargerPhases.Should().BeNull();

        [Fact]
        public void charge_port_latch() => _sut.ChargePortLatch.Should().BeNull();

        [Fact]
        public void charge_current_request() => _sut.ChargeCurrentRequest.Should().BeNull();

        [Fact]
        public void charge_current_request_max() => _sut.ChargeCurrentRequestMax.Should().BeNull();

        [Fact]
        public void managed_charging_active() => _sut.ManagedChargingActive.Should().BeNull();

        [Fact]
        public void managed_charging_user_canceled() => _sut.ManagedChargingUserCanceled.Should().BeNull();

        [Fact]
        public void managed_charging_start_time() => _sut.ManagedChargingStartTime.Should().BeNull();

        [Fact]
        public void battery_heater_on() => _sut.BatteryHeaterOn.Should().BeNull();

        [Fact]
        public void not_enough_power_to_heat() => _sut.NotEnoughPowerToHeat.Should().BeNull();

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(_json["timestamp"].Value<long>());
    }

    public class When_running_in_the_debugger_ChargeState_Should : DebuggerDisplayTestsBase
    {
        private readonly ChargeState _sut;

        public When_running_in_the_debugger_ChargeState_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<ChargeState>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_charging_state_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.ChargingState);
        }

        [Fact]
        public void include_the_battery_level_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.BatteryLevel.ToString());
        }

        [Fact]
        public void include_the_est_battery_range_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(
                _sut.EstBatteryRange.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
        }
    }

    public class ChargeState_Should_calculate
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly ChargeState _sut;

        public ChargeState_Should_calculate(ITestOutputHelper output)
        {
            JObject json = SampleJson.ChargeState;
            _sut = json.ToObject<ChargeState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);
        }

        [Fact]
        public void ScheduledChargingStartTimeUtc() =>
            _sut.ScheduledChargingStartTimeUtc.Should().Be(Epoch.AddSeconds(
                _sut.ScheduledChargingStartTime.GetValueOrDefault()));

        [Fact]
        public void ManagedChargingStartTimeUtc() =>
            _sut.ManagedChargingStartTimeUtc.Should().Be(Epoch.AddSeconds(
                _sut.ManagedChargingStartTime.GetValueOrDefault()));

        [Fact]
        public void TimestampUtc() => _sut.TimestampUtc.Should().Be(Epoch.AddMilliseconds(_sut.Timestamp));
    }
}
