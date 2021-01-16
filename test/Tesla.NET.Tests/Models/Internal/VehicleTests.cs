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

    public class When_serializing_Vehicle_Should_serialize : FixtureContext
    {
        private readonly Vehicle _sut;
        private readonly JObject _json;

        public When_serializing_Vehicle_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<Vehicle>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void fourteen_properties() => _json.Count.Should().Be(14);

        [Fact]
        public void id() => Get("id").Value<long>().Should().Be(_sut.Id);

        [Fact]
        public void vehicle_id() => Get("vehicle_id").Value<long>().Should().Be(_sut.VehicleId);

        [Fact]
        public void vin() => Get("vin").Value<string>().Should().Be(_sut.Vin);

        [Fact]
        public void display_name() => Get("display_name").Value<string>().Should().Be(_sut.DisplayName);

        [Fact]
        public void option_codes() => Get("option_codes").Value<string>().Should().Be(_sut.OptionCodes);

        [Fact]
        public void color() => Get("color").Value<string>().Should().Be(_sut.Color);

        [Fact]
        public void tokens() =>
            Get("tokens").Select(t => t.Value<string>()).Should().BeEquivalentTo(_sut.Tokens, WithStrictOrdering);

        [Fact]
        public void state() => Get("state").Value<string>().Should().Be(_sut.State);

        [Fact]
        public void in_service() => Get("in_service").Value<string>().Should().Be(_sut.InService);

        [Fact]
        public void remote_start_enabled() =>
            Get("remote_start_enabled").Value<bool>().Should().Be(_sut.RemoteStartEnabled);

        [Fact]
        public void calendar_enabled() => Get("calendar_enabled").Value<bool>().Should().Be(_sut.CalendarEnabled);

        [Fact]
        public void notifications_enabled() =>
            Get("notifications_enabled").Value<bool>().Should().Be(_sut.NotificationsEnabled);

        [Fact]
        public void backseat_token() => Get("backseat_token").Value<string>().Should().Be(_sut.BackseatToken);

        [Fact]
        public void backseat_token_updated_at() =>
            Get("backseat_token_updated_at").Value<string>().Should().Be(_sut.BackseatTokenUpdatedAt);

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_serializing_and_deserializing_Vehicle : FixtureContext
    {
        private readonly Vehicle _expected;
        private readonly Vehicle _actual;

        public When_serializing_and_deserializing_Vehicle(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<Vehicle>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<Vehicle>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_Vehicle_Should_deserialize : FixtureContext
    {
        private readonly Vehicle _sut;
        private readonly JObject _json;

        public When_deserializing_Vehicle_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.Vehicle;
            _sut = _json.ToObject<Vehicle>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void id() => _sut.Id.Should().Be(Get("id").Value<long>());

        [Fact]
        public void vehicle_id() => _sut.VehicleId.Should().Be(Get("vehicle_id").Value<long>());

        [Fact]
        public void vin() => _sut.Vin.Should().Be(Get("vin").Value<string>());

        [Fact]
        public void display_name() => _sut.DisplayName.Should().Be(Get("display_name").Value<string>());

        [Fact]
        public void option_codes() => _sut.OptionCodes.Should().Be(Get("option_codes").Value<string>());

        [Fact]
        public void color() => _sut.Color.Should().Be(Get("color").Value<string>());

        [Fact]
        public void tokens() =>
            _sut.Tokens.Should().BeEquivalentTo(Get("tokens").Select(t => t.Value<string>()), WithStrictOrdering);

        [Fact]
        public void state() => _sut.State.Should().Be(Get("state").Value<string>());

        [Fact]
        public void in_service() => _sut.InService.Should().Be(Get("in_service").Value<string>());

        [Fact]
        public void remote_start_enabled() =>
            _sut.RemoteStartEnabled.Should().Be(Get("remote_start_enabled").Value<bool>());

        [Fact]
        public void calendar_enabled() => _sut.CalendarEnabled.Should().Be(Get("calendar_enabled").Value<bool>());

        [Fact]
        public void notifications_enabled() =>
            _sut.NotificationsEnabled.Should().Be(Get("notifications_enabled").Value<bool>());

        [Fact]
        public void backseat_token() => _sut.BackseatToken.Should().Be(Get("backseat_token").Value<string>());

        [Fact]
        public void backseat_token_updated_at() =>
            _sut.BackseatTokenUpdatedAt.Should().Be(Get("backseat_token_updated_at").Value<string>());

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_deserializing_Vehicle_with_minimal_data_Should_default
    {
        private readonly Vehicle _sut;
        private readonly JObject _json;

        public When_deserializing_Vehicle_with_minimal_data_Should_default(ITestOutputHelper output)
        {
            _json = SampleJson.VehicleMinimal;
            _sut = _json.ToObject<Vehicle>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void id() => _sut.Id.Should().Be(default);

        [Fact]
        public void vehicle_id() => _sut.VehicleId.Should().Be(default);

        [Fact]
        public void vin() => _sut.Vin.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void display_name() => _sut.DisplayName.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void option_codes() => _sut.OptionCodes.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void color() => _sut.Color.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void tokens() => _sut.Tokens.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void state() => _sut.State.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void in_service() => _sut.InService.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void remote_start_enabled() => _sut.RemoteStartEnabled.Should().BeFalse();

        [Fact]
        public void calendar_enabled() => _sut.CalendarEnabled.Should().BeFalse();

        [Fact]
        public void notifications_enabled() => _sut.NotificationsEnabled.Should().BeFalse();

        [Fact]
        public void backseat_token() => _sut.BackseatToken.Should().NotBeNull().And.BeEmpty();

        [Fact]
        public void backseat_token_updated_at() => _sut.BackseatTokenUpdatedAt.Should().NotBeNull().And.BeEmpty();
    }

    public class When_running_in_the_debugger_Vehicle_Should : DebuggerDisplayTestsBase
    {
        private readonly Vehicle _sut;

        public When_running_in_the_debugger_Vehicle_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<Vehicle>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_display_name_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.DisplayName);
        }

        [Fact]
        public void include_the_VIN_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.Vin);
        }
    }
}
