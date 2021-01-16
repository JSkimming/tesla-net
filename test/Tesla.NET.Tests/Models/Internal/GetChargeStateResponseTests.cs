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

    public class When_serializing_GetChargeStateResponse_Should_serialize : FixtureContext
    {
        private readonly ResponseDataWrapper<ChargeState> _sut;
        private readonly JObject _json;

        public When_serializing_GetChargeStateResponse_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<ResponseDataWrapper<ChargeState>>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void one_properties() => _json.Count.Should().Be(1);
    }

    public class When_serializing_and_deserializing_GetChargeStateResponse : FixtureContext
    {
        private readonly ResponseDataWrapper<ChargeState> _expected;
        private readonly ResponseDataWrapper<ChargeState> _actual;

        public When_serializing_and_deserializing_GetChargeStateResponse(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<ResponseDataWrapper<ChargeState>>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<ResponseDataWrapper<ChargeState>>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_GetChargeStateResponse_Should_deserialize : FixtureContext
    {
        private readonly ResponseDataWrapper<ChargeState> _sut;
        private readonly JObject _json;
        private readonly ChargeState _expectedResponse;

        public When_deserializing_GetChargeStateResponse_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.GetChargeStateResponse;
            _sut = _json.ToObject<ResponseDataWrapper<ChargeState>>() ?? throw new InvalidOperationException();
            _expectedResponse = SampleJson.ChargeState.ToObject<ChargeState>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void response() => _sut.Response.Should().BeEquivalentTo(_expectedResponse, WithStrictOrdering);
    }
}
