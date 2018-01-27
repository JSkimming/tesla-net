// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoFixture;
    using FluentAssertions;
    using Newtonsoft.Json.Linq;
    using Xunit;
    using Xunit.Abstractions;

    public class When_serializing_VehicleState_Should_serialize : FixtureContext
    {
        private readonly VehicleState _sut;
        private readonly JObject _json;

        public When_serializing_VehicleState_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<VehicleState>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void twenty_seven_properties() => _json.Count.Should().Be(27);

        [Fact]
        public void api_version() => _json["api_version"].Value<long>().Should().Be(_sut.ApiVersion);

        [Fact]
        public void autopark_state() => _json["autopark_state"].Value<string>().Should().Be(_sut.AutoparkState);

        [Fact]
        public void autopark_state_v2()
            => _json["autopark_state_v2"].Value<string>().Should().Be(_sut.AutoparkStateV2);

        [Fact]
        public void autopark_style() => _json["autopark_style"].Value<string>().Should().Be(_sut.AutoparkStyle);

        [Fact]
        public void calendar_supported()
            => _json["calendar_supported"].Value<bool>().Should().Be(_sut.CalendarSupported);

        [Fact]
        public void car_version() => _json["car_version"].Value<string>().Should().Be(_sut.CarVersion);

        [Fact]
        public void center_display_state()
            => _json["center_display_state"].Value<long>().Should().Be(_sut.CenterDisplayState);

        [Fact]
        public void df() => _json["df"].Value<long>().Should().Be(_sut.Df);

        [Fact]
        public void dr() => _json["dr"].Value<long>().Should().Be(_sut.Dr);

        [Fact]
        public void ft() => _json["ft"].Value<long>().Should().Be(_sut.Ft);

        [Fact]
        public void homelink_nearby() => _json["homelink_nearby"].Value<bool>().Should().Be(_sut.HomelinkNearby);

        [Fact]
        public void last_autopark_error()
            => _json["last_autopark_error"].Value<string>().Should().Be(_sut.LastAutoparkError);

        [Fact]
        public void locked() => _json["locked"].Value<bool>().Should().Be(_sut.Locked);

        [Fact]
        public void notifications_supported()
            => _json["notifications_supported"].Value<bool>().Should().Be(_sut.NotificationsSupported);

        [Fact]
        public void odometer() => _json["odometer"].Value<double>().Should().Be(_sut.Odometer);

        [Fact]
        public void parsed_calendar_supported()
            => _json["parsed_calendar_supported"].Value<bool>().Should().Be(_sut.ParsedCalendarSupported);

        [Fact]
        public void pf() => _json["pf"].Value<long>().Should().Be(_sut.Pf);

        [Fact]
        public void pr() => _json["pr"].Value<long>().Should().Be(_sut.Pr);

        [Fact]
        public void remote_start() => _json["remote_start"].Value<bool>().Should().Be(_sut.RemoteStart);

        [Fact]
        public void remote_start_supported()
            => _json["remote_start_supported"].Value<bool>().Should().Be(_sut.RemoteStartSupported);

        [Fact]
        public void rt() => _json["rt"].Value<long>().Should().Be(_sut.Rt);

        [Fact]
        public void sun_roof_percent_open()
            => _json["sun_roof_percent_open"].Value<long>().Should().Be(_sut.SunRoofPercentOpen);

        [Fact]
        public void sun_roof_state() => _json["sun_roof_state"].Value<string>().Should().Be(_sut.SunRoofState);

        [Fact]
        public void timestamp() => _json["timestamp"].Value<long>().Should().Be(_sut.Timestamp);

        [Fact]
        public void valet_mode() => _json["valet_mode"].Value<bool>().Should().Be(_sut.ValetMode);

        [Fact]
        public void valet_pin_needed() => _json["valet_pin_needed"].Value<bool>().Should().Be(_sut.ValetPinNeeded);

        [Fact]
        public void vehicle_name() => _json["vehicle_name"].Value<string>().Should().Be(_sut.VehicleName);
    }

    public class When_serializing_and_deserializing_VehicleState : FixtureContext
    {
        private readonly VehicleState _expected;
        private readonly VehicleState _actual;

        public When_serializing_and_deserializing_VehicleState(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<VehicleState>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<VehicleState>();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.ShouldBeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_VehicleState_Should_deserialize : FixtureContext
    {
        private readonly VehicleState _sut;
        private readonly JObject _json;

        public When_deserializing_VehicleState_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.VehicleState;
            _sut = _json.ToObject<VehicleState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void api_version() => _sut.ApiVersion.Should().Be(_json["api_version"].Value<long>());

        [Fact]
        public void autopark_state() => _sut.AutoparkState.Should().Be(_json["autopark_state"].Value<string>());

        [Fact]
        public void autopark_state_v2()
            => _sut.AutoparkStateV2.Should().Be(_json["autopark_state_v2"].Value<string>());

        [Fact]
        public void autopark_style() => _sut.AutoparkStyle.Should().Be(_json["autopark_style"].Value<string>());

        [Fact]
        public void calendar_supported()
            => _sut.CalendarSupported.Should().Be(_json["calendar_supported"].Value<bool>());

        [Fact]
        public void car_version() => _sut.CarVersion.Should().Be(_json["car_version"].Value<string>());

        [Fact]
        public void center_display_state()
            => _sut.CenterDisplayState.Should().Be(_json["center_display_state"].Value<long>());

        [Fact]
        public void df() => _sut.Df.Should().Be(_json["df"].Value<long>());

        [Fact]
        public void dr() => _sut.Dr.Should().Be(_json["dr"].Value<long>());

        [Fact]
        public void ft() => _sut.Ft.Should().Be(_json["ft"].Value<long>());

        [Fact]
        public void homelink_nearby() => _sut.HomelinkNearby.Should().Be(_json["homelink_nearby"].Value<bool>());

        [Fact]
        public void last_autopark_error()
            => _sut.LastAutoparkError.Should().Be(_json["last_autopark_error"].Value<string>());

        [Fact]
        public void locked() => _sut.Locked.Should().Be(_json["locked"].Value<bool>());

        [Fact]
        public void notifications_supported()
            => _sut.NotificationsSupported.Should().Be(_json["notifications_supported"].Value<bool>());

        [Fact]
        public void odometer() => _sut.Odometer.Should().Be(_json["odometer"].Value<double>());

        [Fact]
        public void parsed_calendar_supported()
            => _sut.ParsedCalendarSupported.Should().Be(_json["parsed_calendar_supported"].Value<bool>());

        [Fact]
        public void pf() => _sut.Pf.Should().Be(_json["pf"].Value<long>());

        [Fact]
        public void pr() => _sut.Pr.Should().Be(_json["pr"].Value<long>());

        [Fact]
        public void remote_start() => _sut.RemoteStart.Should().Be(_json["remote_start"].Value<bool>());

        [Fact]
        public void remote_start_supported()
            => _sut.RemoteStartSupported.Should().Be(_json["remote_start_supported"].Value<bool>());

        [Fact]
        public void rt() => _sut.Rt.Should().Be(_json["rt"].Value<long>());

        [Fact]
        public void sun_roof_percent_open()
            => _sut.SunRoofPercentOpen.Should().Be(_json["sun_roof_percent_open"].Value<long>());

        [Fact]
        public void sun_roof_state() => _sut.SunRoofState.Should().Be(_json["sun_roof_state"].Value<string>());

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(_json["timestamp"].Value<long>());

        [Fact]
        public void valet_mode() => _sut.ValetMode.Should().Be(_json["valet_mode"].Value<bool>());

        [Fact]
        public void valet_pin_needed() => _sut.ValetPinNeeded.Should().Be(_json["valet_pin_needed"].Value<bool>());

        [Fact]
        public void vehicle_name() => _sut.VehicleName.Should().Be(_json["vehicle_name"].Value<string>());
    }

    public class When_deserializing_VehicleState_with_minimal_data_Should_default
    {
        private readonly VehicleState _sut;
        private readonly JObject _json;

        public When_deserializing_VehicleState_with_minimal_data_Should_default(ITestOutputHelper output)
        {
            _json = SampleJson.VehicleStateMinimal;
            _sut = _json.ToObject<VehicleState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void api_version() => _sut.ApiVersion.Should().Be(default(long));

        [Fact]
        public void autopark_state() => _sut.AutoparkState.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void autopark_state_v2() => _sut.AutoparkStateV2.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void autopark_style() => _sut.AutoparkStyle.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void calendar_supported() => _sut.CalendarSupported.Should().BeFalse();

        [Fact]
        public void car_version() => _sut.CarVersion.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void center_display_state() => _sut.CenterDisplayState.Should().Be(default(long));

        [Fact]
        public void df() => _sut.Df.Should().Be(default(long));

        [Fact]
        public void dr() => _sut.Dr.Should().Be(default(long));

        [Fact]
        public void ft() => _sut.Ft.Should().Be(default(long));

        [Fact]
        public void homelink_nearby() => _sut.HomelinkNearby.Should().BeFalse();

        [Fact]
        public void last_autopark_error() => _sut.LastAutoparkError.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void locked() => _sut.Locked.Should().BeFalse();

        [Fact]
        public void notifications_supported() => _sut.NotificationsSupported.Should().BeFalse();

        [Fact]
        public void odometer() => _sut.Odometer.Should().Be(default(double));

        [Fact]
        public void parsed_calendar_supported() => _sut.ParsedCalendarSupported.Should().BeFalse();

        [Fact]
        public void pf() => _sut.Pf.Should().Be(default(long));

        [Fact]
        public void pr() => _sut.Pr.Should().Be(default(long));

        [Fact]
        public void remote_start() => _sut.RemoteStart.Should().BeFalse();

        [Fact]
        public void remote_start_supported() => _sut.RemoteStartSupported.Should().BeFalse();

        [Fact]
        public void rt() => _sut.Rt.Should().Be(default(long));

        [Fact]
        public void sun_roof_percent_open() => _sut.SunRoofPercentOpen.Should().Be(default(long));

        [Fact]
        public void sun_roof_state() => _sut.SunRoofState.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(default(long));

        [Fact]
        public void valet_mode() => _sut.ValetMode.Should().BeFalse();

        [Fact]
        public void valet_pin_needed() => _sut.ValetPinNeeded.Should().BeFalse();

        [Fact]
        public void vehicle_name() => _sut.VehicleName.Should().NotBeNull().And.BeEmpty();
    }

    public class When_running_in_the_debugger_VehicleState_Should : DebuggerDisplayTestsBase
    {
        private readonly VehicleState _sut;

        public When_running_in_the_debugger_VehicleState_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<VehicleState>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_vehicle_name_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.VehicleName);
        }

        [Fact]
        public void include_the_car_version_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.CarVersion);
        }

        [Fact]
        public void include_the_timestamp_UTC_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.TimestampUtc.ToString("R"));
        }
    }

    public class VehicleState_Should_calculate
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly VehicleState _sut;

        public VehicleState_Should_calculate(ITestOutputHelper output)
        {
            JObject json = SampleJson.VehicleState;
            _sut = json.ToObject<VehicleState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);
        }

        [Fact]
        public void TimestampUtc() => _sut.TimestampUtc.Should().Be(Epoch.AddMilliseconds(_sut.Timestamp));
    }
}
