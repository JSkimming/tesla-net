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
        public void api_version() => Get("api_version").Value<long>().Should().Be(_sut.ApiVersion);

        [Fact]
        public void autopark_state() => Get("autopark_state").Value<string>().Should().Be(_sut.AutoparkState);

        [Fact]
        public void autopark_state_v2()
            => Get("autopark_state_v2").Value<string>().Should().Be(_sut.AutoparkStateV2);

        [Fact]
        public void autopark_style() => Get("autopark_style").Value<string>().Should().Be(_sut.AutoparkStyle);

        [Fact]
        public void calendar_supported()
            => Get("calendar_supported").Value<bool>().Should().Be(_sut.CalendarSupported);

        [Fact]
        public void car_version() => Get("car_version").Value<string>().Should().Be(_sut.CarVersion);

        [Fact]
        public void center_display_state()
            => Get("center_display_state").Value<long>().Should().Be(_sut.CenterDisplayState);

        [Fact]
        public void df() => Get("df").Value<long>().Should().Be(_sut.Df);

        [Fact]
        public void dr() => Get("dr").Value<long>().Should().Be(_sut.Dr);

        [Fact]
        public void ft() => Get("ft").Value<long>().Should().Be(_sut.Ft);

        [Fact]
        public void homelink_nearby() => Get("homelink_nearby").Value<bool>().Should().Be(_sut.HomelinkNearby);

        [Fact]
        public void last_autopark_error()
            => Get("last_autopark_error").Value<string>().Should().Be(_sut.LastAutoparkError);

        [Fact]
        public void locked() => Get("locked").Value<bool>().Should().Be(_sut.Locked);

        [Fact]
        public void notifications_supported()
            => Get("notifications_supported").Value<bool>().Should().Be(_sut.NotificationsSupported);

        [Fact]
        public void odometer() => Get("odometer").Value<double>().Should().Be(_sut.Odometer);

        [Fact]
        public void parsed_calendar_supported()
            => Get("parsed_calendar_supported").Value<bool>().Should().Be(_sut.ParsedCalendarSupported);

        [Fact]
        public void pf() => Get("pf").Value<long>().Should().Be(_sut.Pf);

        [Fact]
        public void pr() => Get("pr").Value<long>().Should().Be(_sut.Pr);

        [Fact]
        public void remote_start() => Get("remote_start").Value<bool>().Should().Be(_sut.RemoteStart);

        [Fact]
        public void remote_start_supported()
            => Get("remote_start_supported").Value<bool>().Should().Be(_sut.RemoteStartSupported);

        [Fact]
        public void rt() => Get("rt").Value<long>().Should().Be(_sut.Rt);

        [Fact]
        public void sun_roof_percent_open()
            => Get("sun_roof_percent_open").Value<long>().Should().Be(_sut.SunRoofPercentOpen);

        [Fact]
        public void sun_roof_state() => Get("sun_roof_state").Value<string>().Should().Be(_sut.SunRoofState);

        [Fact]
        public void timestamp() => Get("timestamp").Value<long>().Should().Be(_sut.Timestamp);

        [Fact]
        public void valet_mode() => Get("valet_mode").Value<bool>().Should().Be(_sut.ValetMode);

        [Fact]
        public void valet_pin_needed() => Get("valet_pin_needed").Value<bool>().Should().Be(_sut.ValetPinNeeded);

        [Fact]
        public void vehicle_name() => Get("vehicle_name").Value<string>().Should().Be(_sut.VehicleName);

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
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

            _actual = json.ToObject<VehicleState>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_VehicleState_Should_deserialize : FixtureContext
    {
        private readonly VehicleState _sut;
        private readonly JObject _json;

        public When_deserializing_VehicleState_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.VehicleState;
            _sut = _json.ToObject<VehicleState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void api_version() => _sut.ApiVersion.Should().Be(Get("api_version").Value<long>());

        [Fact]
        public void autopark_state() => _sut.AutoparkState.Should().Be(Get("autopark_state").Value<string>());

        [Fact]
        public void autopark_state_v2()
            => _sut.AutoparkStateV2.Should().Be(Get("autopark_state_v2").Value<string>());

        [Fact]
        public void autopark_style() => _sut.AutoparkStyle.Should().Be(Get("autopark_style").Value<string>());

        [Fact]
        public void calendar_supported()
            => _sut.CalendarSupported.Should().Be(Get("calendar_supported").Value<bool>());

        [Fact]
        public void car_version() => _sut.CarVersion.Should().Be(Get("car_version").Value<string>());

        [Fact]
        public void center_display_state()
            => _sut.CenterDisplayState.Should().Be(Get("center_display_state").Value<long>());

        [Fact]
        public void df() => _sut.Df.Should().Be(Get("df").Value<long>());

        [Fact]
        public void dr() => _sut.Dr.Should().Be(Get("dr").Value<long>());

        [Fact]
        public void ft() => _sut.Ft.Should().Be(Get("ft").Value<long>());

        [Fact]
        public void homelink_nearby() => _sut.HomelinkNearby.Should().Be(Get("homelink_nearby").Value<bool>());

        [Fact]
        public void last_autopark_error()
            => _sut.LastAutoparkError.Should().Be(Get("last_autopark_error").Value<string>());

        [Fact]
        public void locked() => _sut.Locked.Should().Be(Get("locked").Value<bool>());

        [Fact]
        public void notifications_supported()
            => _sut.NotificationsSupported.Should().Be(Get("notifications_supported").Value<bool>());

        [Fact]
        public void odometer() => _sut.Odometer.Should().Be(Get("odometer").Value<double>());

        [Fact]
        public void parsed_calendar_supported()
            => _sut.ParsedCalendarSupported.Should().Be(Get("parsed_calendar_supported").Value<bool>());

        [Fact]
        public void pf() => _sut.Pf.Should().Be(Get("pf").Value<long>());

        [Fact]
        public void pr() => _sut.Pr.Should().Be(Get("pr").Value<long>());

        [Fact]
        public void remote_start() => _sut.RemoteStart.Should().Be(Get("remote_start").Value<bool>());

        [Fact]
        public void remote_start_supported()
            => _sut.RemoteStartSupported.Should().Be(Get("remote_start_supported").Value<bool>());

        [Fact]
        public void rt() => _sut.Rt.Should().Be(Get("rt").Value<long>());

        [Fact]
        public void sun_roof_percent_open()
            => _sut.SunRoofPercentOpen.Should().Be(Get("sun_roof_percent_open").Value<long>());

        [Fact]
        public void sun_roof_state() => _sut.SunRoofState.Should().Be(Get("sun_roof_state").Value<string>());

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(Get("timestamp").Value<long>());

        [Fact]
        public void valet_mode() => _sut.ValetMode.Should().Be(Get("valet_mode").Value<bool>());

        [Fact]
        public void valet_pin_needed() => _sut.ValetPinNeeded.Should().Be(Get("valet_pin_needed").Value<bool>());

        [Fact]
        public void vehicle_name() => _sut.VehicleName.Should().Be(Get("vehicle_name").Value<string>());

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_deserializing_VehicleState_with_minimal_data_Should_default
    {
        private readonly VehicleState _sut;
        private readonly JObject _json;

        public When_deserializing_VehicleState_with_minimal_data_Should_default(ITestOutputHelper output)
        {
            _json = SampleJson.VehicleStateMinimal;
            _sut = _json.ToObject<VehicleState>() ?? throw new InvalidOperationException();

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
        public void center_display_state() => _sut.CenterDisplayState.Should().Be(default);

        [Fact]
        public void df() => _sut.Df.Should().Be(default);

        [Fact]
        public void dr() => _sut.Dr.Should().Be(default);

        [Fact]
        public void ft() => _sut.Ft.Should().Be(default);

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
        public void sun_roof_percent_open() => _sut.SunRoofPercentOpen.Should().Be(default(long?));

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
        private static readonly DateTime Epoch =
            new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, DateTimeKind.Utc);

        private readonly VehicleState _sut;

        public VehicleState_Should_calculate(ITestOutputHelper output)
        {
            JObject json = SampleJson.VehicleState;
            _sut = json.ToObject<VehicleState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);
        }

        [Fact]
        public void TimestampUtc() => _sut.TimestampUtc.Should().Be(Epoch.AddMilliseconds(_sut.Timestamp));
    }
}
