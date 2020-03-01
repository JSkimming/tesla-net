// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
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
            Get("charging_state").Value<string>().Should().Be(_sut.ChargingState);

        [Fact]
        public void fast_charger_type() =>
            Get("fast_charger_type").Value<string>().Should().Be(_sut.FastChargerType);

        [Fact]
        public void fast_charger_brand() =>
            Get("fast_charger_brand").Value<string>().Should().Be(_sut.FastChargerBrand);

        [Fact]
        public void charge_limit_soc() =>
            Get("charge_limit_soc").Value<long?>().Should().Be(_sut.ChargeLimitSoc);

        [Fact]
        public void charge_limit_soc_std() =>
            Get("charge_limit_soc_std").Value<long?>().Should().Be(_sut.ChargeLimitSocStd);

        [Fact]
        public void charge_limit_soc_min() =>
            Get("charge_limit_soc_min").Value<long?>().Should().Be(_sut.ChargeLimitSocMin);

        [Fact]
        public void charge_limit_soc_max() =>
            Get("charge_limit_soc_max").Value<long?>().Should().Be(_sut.ChargeLimitSocMax);

        [Fact]
        public void charge_to_max_range() =>
            Get("charge_to_max_range").Value<bool?>().Should().Be(_sut.ChargeToMaxRange);

        [Fact]
        public void max_range_charge_counter() =>
            Get("max_range_charge_counter").Value<long?>().Should().Be(_sut.MaxRangeChargeCounter);

        [Fact]
        public void fast_charger_present() =>
            Get("fast_charger_present").Value<bool?>().Should().Be(_sut.FastChargerPresent);

        [Fact]
        public void battery_range() =>
            Get("battery_range").Value<double?>().Should().Be(_sut.BatteryRange);

        [Fact]
        public void est_battery_range() =>
            Get("est_battery_range").Value<double?>().Should().Be(_sut.EstBatteryRange);

        [Fact]
        public void ideal_battery_range() =>
            Get("ideal_battery_range").Value<double?>().Should().Be(_sut.IdealBatteryRange);

        [Fact]
        public void battery_level() =>
            Get("battery_level").Value<long?>().Should().Be(_sut.BatteryLevel);

        [Fact]
        public void usable_battery_level() =>
            Get("usable_battery_level").Value<long?>().Should().Be(_sut.UsableBatteryLevel);

        [Fact]
        public void charge_energy_added() =>
            Get("charge_energy_added").Value<double?>().Should().Be(_sut.ChargeEnergyAdded);

        [Fact]
        public void charge_miles_added_rated() =>
            Get("charge_miles_added_rated").Value<double?>().Should().Be(_sut.ChargeMilesAddedRated);

        [Fact]
        public void charge_miles_added_ideal() =>
            Get("charge_miles_added_ideal").Value<long?>().Should().Be(_sut.ChargeMilesAddedIdeal);

        [Fact]
        public void charger_voltage() =>
            Get("charger_voltage").Value<long?>().Should().Be(_sut.ChargerVoltage);

        [Fact]
        public void charger_pilot_current() =>
            Get("charger_pilot_current").Value<long?>().Should().Be(_sut.ChargerPilotCurrent);

        [Fact]
        public void charger_actual_current() =>
            Get("charger_actual_current").Value<long?>().Should().Be(_sut.ChargerActualCurrent);

        [Fact]
        public void charger_power() =>
            Get("charger_power").Value<long?>().Should().Be(_sut.ChargerPower);

        [Fact]
        public void time_to_full_charge() =>
            Get("time_to_full_charge").Value<long?>().Should().Be(_sut.TimeToFullCharge);

        [Fact]
        public void trip_charging() =>
            Get("trip_charging").Value<bool?>().Should().Be(_sut.TripCharging);

        [Fact]
        public void charge_rate() =>
            Get("charge_rate").Value<long?>().Should().Be(_sut.ChargeRate);

        [Fact]
        public void charge_port_door_open() =>
            Get("charge_port_door_open").Value<bool?>().Should().Be(_sut.ChargePortDoorOpen);

        [Fact]
        public void conn_charge_cable() =>
            Get("conn_charge_cable").Value<string>().Should().Be(_sut.ConnChargeCable);

        [Fact]
        public void scheduled_charging_start_time() =>
            Get("scheduled_charging_start_time").Value<long?>().Should().Be(_sut.ScheduledChargingStartTime);

        [Fact]
        public void scheduled_charging_pending() =>
            Get("scheduled_charging_pending").Value<bool?>().Should().Be(_sut.ScheduledChargingPending);

        [Fact]
        public void user_charge_enable_request() =>
            Get("user_charge_enable_request").Value<bool?>().Should().Be(_sut.UserChargeEnableRequest);

        [Fact]
        public void charge_enable_request() =>
            Get("charge_enable_request").Value<bool?>().Should().Be(_sut.ChargeEnableRequest);

        [Fact]
        public void charger_phases() =>
            Get("charger_phases").Value<int?>().Should().Be(_sut.ChargerPhases);

        [Fact]
        public void charge_port_latch() =>
            Get("charge_port_latch").Value<string>().Should().Be(_sut.ChargePortLatch);

        [Fact]
        public void charge_current_request() =>
            Get("charge_current_request").Value<long?>().Should().Be(_sut.ChargeCurrentRequest);

        [Fact]
        public void charge_current_request_max() =>
            Get("charge_current_request_max").Value<long?>().Should().Be(_sut.ChargeCurrentRequestMax);

        [Fact]
        public void managed_charging_active() =>
            Get("managed_charging_active").Value<bool?>().Should().Be(_sut.ManagedChargingActive);

        [Fact]
        public void managed_charging_user_canceled() =>
            Get("managed_charging_user_canceled").Value<bool?>().Should().Be(_sut.ManagedChargingUserCanceled);

        [Fact]
        public void managed_charging_start_time() =>
            Get("managed_charging_start_time").Value<long?>().Should().Be(_sut.ManagedChargingStartTime);

        [Fact]
        public void battery_heater_on() =>
            Get("battery_heater_on").Value<bool?>().Should().Be(_sut.BatteryHeaterOn);

        [Fact]
        public void not_enough_power_to_heat() =>
            Get("not_enough_power_to_heat").Value<bool?>().Should().Be(_sut.NotEnoughPowerToHeat);

        [Fact]
        public void timestamp() =>
            Get("timestamp").Value<long>().Should().Be(_sut.Timestamp);

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
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

            _actual = json.ToObject<ChargeState>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_ChargeState_Should_deserialize : FixtureContext
    {
        private readonly ChargeState _sut;
        private readonly JObject _json;

        public When_deserializing_ChargeState_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.ChargeState;
            _sut = _json.ToObject<ChargeState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void charging_state() =>
            _sut.ChargingState.Should().Be(Get("charging_state").Value<string>());

        [Fact]
        public void fast_charger_type() =>
            _sut.FastChargerType.Should().Be(Get("fast_charger_type").Value<string>());

        [Fact]
        public void fast_charger_brand() =>
            _sut.FastChargerBrand.Should().Be(Get("fast_charger_brand").Value<string>());

        [Fact]
        public void charge_limit_soc() =>
            _sut.ChargeLimitSoc.Should().Be(Get("charge_limit_soc").Value<long?>());

        [Fact]
        public void charge_limit_soc_std() =>
            _sut.ChargeLimitSocStd.Should().Be(Get("charge_limit_soc_std").Value<long?>());

        [Fact]
        public void charge_limit_soc_min() =>
            _sut.ChargeLimitSocMin.Should().Be(Get("charge_limit_soc_min").Value<long?>());

        [Fact]
        public void charge_limit_soc_max() =>
            _sut.ChargeLimitSocMax.Should().Be(Get("charge_limit_soc_max").Value<long?>());

        [Fact]
        public void charge_to_max_range() =>
            _sut.ChargeToMaxRange.Should().Be(Get("charge_to_max_range").Value<bool?>());

        [Fact]
        public void max_range_charge_counter() =>
            _sut.MaxRangeChargeCounter.Should().Be(Get("max_range_charge_counter").Value<long?>());

        [Fact]
        public void fast_charger_present() =>
            _sut.FastChargerPresent.Should().Be(Get("fast_charger_present").Value<bool?>());

        [Fact]
        public void battery_range() =>
            _sut.BatteryRange.Should().Be(Get("battery_range").Value<double?>());

        [Fact]
        public void est_battery_range() =>
            _sut.EstBatteryRange.Should().Be(Get("est_battery_range").Value<double?>());

        [Fact]
        public void ideal_battery_range() =>
            _sut.IdealBatteryRange.Should().Be(Get("ideal_battery_range").Value<double?>());

        [Fact]
        public void battery_level() =>
            _sut.BatteryLevel.Should().Be(Get("battery_level").Value<long?>());

        [Fact]
        public void usable_battery_level() =>
            _sut.UsableBatteryLevel.Should().Be(Get("usable_battery_level").Value<long?>());

        [Fact]
        public void charge_energy_added() =>
            _sut.ChargeEnergyAdded.Should().Be(Get("charge_energy_added").Value<double?>());

        [Fact]
        public void charge_miles_added_rated() =>
            _sut.ChargeMilesAddedRated.Should().Be(Get("charge_miles_added_rated").Value<double?>());

        [Fact]
        public void charge_miles_added_ideal() =>
            _sut.ChargeMilesAddedIdeal.Should().Be(Get("charge_miles_added_ideal").Value<long?>());

        [Fact]
        public void charger_voltage() =>
            _sut.ChargerVoltage.Should().Be(Get("charger_voltage").Value<long?>());

        [Fact]
        public void charger_pilot_current() =>
            _sut.ChargerPilotCurrent.Should().Be(Get("charger_pilot_current").Value<long?>());

        [Fact]
        public void charger_actual_current() =>
            _sut.ChargerActualCurrent.Should().Be(Get("charger_actual_current").Value<long?>());

        [Fact]
        public void charger_power() =>
            _sut.ChargerPower.Should().Be(Get("charger_power").Value<long?>());

        [Fact]
        public void time_to_full_charge() =>
            _sut.TimeToFullCharge.Should().Be(Get("time_to_full_charge").Value<long?>());

        [Fact]
        public void trip_charging() =>
            _sut.TripCharging.Should().Be(Get("trip_charging").Value<bool?>());

        [Fact]
        public void charge_rate() =>
            _sut.ChargeRate.Should().Be(Get("charge_rate").Value<long?>());

        [Fact]
        public void charge_port_door_open() =>
            _sut.ChargePortDoorOpen.Should().Be(Get("charge_port_door_open").Value<bool?>());

        [Fact]
        public void conn_charge_cable() =>
            _sut.ConnChargeCable.Should().Be(Get("conn_charge_cable").Value<string>());

        [Fact]
        public void scheduled_charging_start_time() =>
            _sut.ScheduledChargingStartTime.Should().Be(Get("scheduled_charging_start_time").Value<long?>());

        [Fact]
        public void scheduled_charging_pending() =>
            _sut.ScheduledChargingPending.Should().Be(Get("scheduled_charging_pending").Value<bool?>());

        [Fact]
        public void user_charge_enable_request() =>
            _sut.UserChargeEnableRequest.Should().Be(Get("user_charge_enable_request").Value<bool?>());

        [Fact]
        public void charge_enable_request() =>
            _sut.ChargeEnableRequest.Should().Be(Get("charge_enable_request").Value<bool?>());

        [Fact]
        public void charger_phases() =>
            _sut.ChargerPhases.Should().Be(Get("charger_phases").Value<int?>());

        [Fact]
        public void charge_port_latch() =>
            _sut.ChargePortLatch.Should().Be(Get("charge_port_latch").Value<string>());

        [Fact]
        public void charge_current_request() =>
            _sut.ChargeCurrentRequest.Should().Be(Get("charge_current_request").Value<long?>());

        [Fact]
        public void charge_current_request_max() =>
            _sut.ChargeCurrentRequestMax.Should().Be(Get("charge_current_request_max").Value<long?>());

        [Fact]
        public void managed_charging_active() =>
            _sut.ManagedChargingActive.Should().Be(Get("managed_charging_active").Value<bool?>());

        [Fact]
        public void managed_charging_user_canceled() =>
            _sut.ManagedChargingUserCanceled.Should().Be(Get("managed_charging_user_canceled").Value<bool?>());

        [Fact]
        public void managed_charging_start_time() =>
            _sut.ManagedChargingStartTime.Should().Be(Get("managed_charging_start_time").Value<long?>());

        [Fact]
        public void battery_heater_on() =>
            _sut.BatteryHeaterOn.Should().Be(Get("battery_heater_on").Value<bool?>());

        [Fact]
        public void not_enough_power_to_heat() =>
            _sut.NotEnoughPowerToHeat.Should().Be(Get("not_enough_power_to_heat").Value<bool?>());

        [Fact]
        public void timestamp() =>
            _sut.Timestamp.Should().Be(Get("timestamp").Value<long?>());

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_deserializing_ChargeState_with_minimal_data_Should_default
    {
        private readonly ChargeState _sut;
        private readonly JObject _json;

        public When_deserializing_ChargeState_with_minimal_data_Should_default(ITestOutputHelper output)
        {
            _json = SampleJson.ChargeStateMinimal;
            _sut = _json.ToObject<ChargeState>() ?? throw new InvalidOperationException();

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
        public void scheduled_charging_start_time_UTC() => _sut.ScheduledChargingStartTimeUtc.Should().BeNull();

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
        public void managed_charging_start_time_UTC() => _sut.ManagedChargingStartTimeUtc.Should().BeNull();

        [Fact]
        public void battery_heater_on() => _sut.BatteryHeaterOn.Should().BeNull();

        [Fact]
        public void not_enough_power_to_heat() => _sut.NotEnoughPowerToHeat.Should().BeNull();

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(Get("timestamp").Value<long>());

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
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
        private static readonly DateTime Epoch =
            new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, DateTimeKind.Utc);

        private readonly ChargeState _sut;

        public ChargeState_Should_calculate(ITestOutputHelper output)
        {
            JObject json = SampleJson.ChargeState;
            _sut = json.ToObject<ChargeState>() ?? throw new InvalidOperationException();

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
