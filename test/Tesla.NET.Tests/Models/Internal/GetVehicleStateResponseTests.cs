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

    public class When_serializing_GetVehicleStateResponse_Should_serialize : FixtureContext
    {
        private readonly ResponseDataWrapper<VehicleState> _sut;
        private readonly JObject _json;

        public When_serializing_GetVehicleStateResponse_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<ResponseDataWrapper<VehicleState>>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void one_properties() => _json.Count.Should().Be(1);
    }

    public class When_serializing_and_deserializing_GetVehicleStateResponse : FixtureContext
    {
        private readonly ResponseDataWrapper<VehicleState> _expected;
        private readonly ResponseDataWrapper<VehicleState> _actual;

        public When_serializing_and_deserializing_GetVehicleStateResponse(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<ResponseDataWrapper<VehicleState>>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<ResponseDataWrapper<VehicleState>>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_GetVehicleStateResponse_Should_deserialize : FixtureContext
    {
        private readonly ResponseDataWrapper<VehicleState> _sut;
        private readonly JObject _json;
        private readonly VehicleState _expectedResponse;

        public When_deserializing_GetVehicleStateResponse_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.GetVehicleStateResponse;
            _sut = _json.ToObject<ResponseDataWrapper<VehicleState>>() ?? throw new InvalidOperationException();
            _expectedResponse = SampleJson.VehicleState.ToObject<VehicleState>()
                                ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void response() => _sut.Response.Should().BeEquivalentTo(_expectedResponse, WithStrictOrdering);
    }
}
