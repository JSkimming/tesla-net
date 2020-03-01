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

    public class When_serializing_DriveState_Should_serialize : FixtureContext
    {
        private readonly DriveState _sut;
        private readonly JObject _json;

        public When_serializing_DriveState_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<DriveState>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void eight_properties() => _json.Count.Should().Be(8);

        [Fact]
        public void shift_state() => Get("shift_state").Value<string>().Should().Be(_sut.ShiftState);

        [Fact]
        public void speed() => Get("speed").Value<string>().Should().Be(_sut.Speed);

        [Fact]
        public void power() => Get("power").Value<long>().Should().Be(_sut.Power);

        [Fact]
        public void latitude() => Get("latitude").Value<double>().Should().Be(_sut.Latitude);

        [Fact]
        public void longitude() => Get("longitude").Value<double>().Should().Be(_sut.Longitude);

        [Fact]
        public void heading() => Get("heading").Value<long>().Should().Be(_sut.Heading);

        [Fact]
        public void gps_as_of() => Get("gps_as_of").Value<long>().Should().Be(_sut.GpsAsOf);

        [Fact]
        public void timestamp() => Get("timestamp").Value<long>().Should().Be(_sut.Timestamp);

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_serializing_and_deserializing_DriveState : FixtureContext
    {
        private readonly DriveState _expected;
        private readonly DriveState _actual;

        public When_serializing_and_deserializing_DriveState(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<DriveState>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<DriveState>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_DriveState_Should_deserialize : FixtureContext
    {
        private readonly DriveState _sut;
        private readonly JObject _json;

        public When_deserializing_DriveState_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.DriveState;
            _sut = _json.ToObject<DriveState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void shift_state() => _sut.ShiftState.Should().Be(Get("shift_state").Value<string>());

        [Fact]
        public void speed() => _sut.Speed.Should().Be(Get("speed").Value<string>());

        [Fact]
        public void power() => _sut.Power.Should().Be(Get("power").Value<long>());

        [Fact]
        public void latitude() => _sut.Latitude.Should().Be(Get("latitude").Value<double>());

        [Fact]
        public void longitude() => _sut.Longitude.Should().Be(Get("longitude").Value<double>());

        [Fact]
        public void heading() => _sut.Heading.Should().Be(Get("heading").Value<long>());

        [Fact]
        public void gps_as_of() => _sut.GpsAsOf.Should().Be(Get("gps_as_of").Value<long>());

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(Get("timestamp").Value<long>());

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_deserializing_DriveState_with_minimal_data_Should_default
    {
        private readonly DriveState _sut;
        private readonly JObject _json;

        public When_deserializing_DriveState_with_minimal_data_Should_default(ITestOutputHelper output)
        {
            _json = SampleJson.DriveStateMinimal;
            _sut = _json.ToObject<DriveState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void shift_state() => _sut.ShiftState.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void speed() => _sut.Speed.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void power() => _sut.Power.Should().Be(default);

        [Fact]
        public void latitude() => _sut.Latitude.Should().Be(default);

        [Fact]
        public void longitude() => _sut.Longitude.Should().Be(default);

        [Fact]
        public void heading() => _sut.Heading.Should().Be(default);

        [Fact]
        public void gps_as_of() => _sut.GpsAsOf.Should().Be(default);

        [Fact]
        public void timestamp() => _sut.Timestamp.Should().Be(default);
    }

    public class When_running_in_the_debugger_DriveState_Should : DebuggerDisplayTestsBase
    {
        private readonly DriveState _sut;

        public When_running_in_the_debugger_DriveState_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<DriveState>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_latitude_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.Latitude.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void include_the_longitude_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.Longitude.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void include_the_GPS_as_of_UTC_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.GpsAsOfUtc.ToString("R"));
        }
    }

    public class DriveState_Should_calculate
    {
        private static readonly DateTime Epoch =
            new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, DateTimeKind.Utc);

        private readonly DriveState _sut;

        public DriveState_Should_calculate(ITestOutputHelper output)
        {
            JObject json = SampleJson.DriveState;
            _sut = json.ToObject<DriveState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);
        }

        [Fact]
        public void GpsAsOfUtc() => _sut.GpsAsOfUtc.Should().Be(Epoch.AddSeconds(_sut.GpsAsOf));

        [Fact]
        public void TimestampUtc() => _sut.TimestampUtc.Should().Be(Epoch.AddMilliseconds(_sut.Timestamp));
    }
}
