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

    public class When_serializing_AccessTokenResponse_Should_serialize : FixtureContext
    {
        private readonly AccessTokenResponse _sut;
        private readonly JObject _json;

        public When_serializing_AccessTokenResponse_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<AccessTokenResponse>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void five_properties() => _json.Count.Should().Be(5);

        [Fact]
        public void access_token() => Get("access_token").Value<string>().Should().Be(_sut.AccessToken);

        [Fact]
        public void token_type() => Get("token_type").Value<string>().Should().Be(_sut.TokenType);

        [Fact]
        public void expires_in() => Get("expires_in").Value<long>().Should().Be(_sut.ExpiresIn);

        [Fact]
        public void refresh_token() => Get("refresh_token").Value<string>().Should().Be(_sut.RefreshToken);

        [Fact]
        public void created_at() => Get("created_at").Value<long>().Should().Be(_sut.CreatedAt);

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_serializing_and_deserializing_AccessTokenResponse : FixtureContext
    {
        private readonly AccessTokenResponse _expected;
        private readonly AccessTokenResponse _actual;

        public When_serializing_and_deserializing_AccessTokenResponse(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<AccessTokenResponse>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<AccessTokenResponse>() ?? throw new InvalidOperationException();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.Should().BeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_AccessTokenResponse_Should_deserialize
    {
        private readonly AccessTokenResponse _sut;
        private readonly JObject _json;

        public When_deserializing_AccessTokenResponse_Should_deserialize(ITestOutputHelper output)
        {
            _json = SampleJson.AccessTokenResponse;
            _sut = _json.ToObject<AccessTokenResponse>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void access_token() => _sut.AccessToken.Should().Be(Get("access_token").Value<string>());

        [Fact]
        public void token_type() => _sut.TokenType.Should().Be(Get("token_type").Value<string>());

        [Fact]
        public void expires_in() => _sut.ExpiresIn.Should().Be(Get("expires_in").Value<long>());

        [Fact]
        public void refresh_token() => _sut.RefreshToken.Should().Be(Get("refresh_token").Value<string>());

        [Fact]
        public void created_at() => _sut.CreatedAt.Should().Be(Get("created_at").Value<long>());

        private JToken Get(string name) => _json[name] ?? throw new InvalidOperationException($"'{name}' is null.");
    }

    public class When_running_in_the_debugger_AccessTokenResponse_Should : DebuggerDisplayTestsBase
    {
        private readonly AccessTokenResponse _sut;

        public When_running_in_the_debugger_AccessTokenResponse_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<AccessTokenResponse>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_truncated_access_token_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.AccessToken.Substring(0, 6) + "…");
        }

        [Fact]
        public void include_the_expires_when_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.ExpiresUtc.ToString("R"));
        }
    }

    public class AccessTokenResponse_Should_calculate
    {
        private static readonly DateTime Epoch =
            new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, DateTimeKind.Utc);

        private readonly AccessTokenResponse _sut;

        public AccessTokenResponse_Should_calculate(ITestOutputHelper output)
        {
            JObject json = SampleJson.AccessTokenResponse;
            _sut = json.ToObject<AccessTokenResponse>() ?? throw new InvalidOperationException();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);
        }

        [Fact]
        public void ExpiresInTimespan() => _sut.ExpiresInTimespan.Should().Be(TimeSpan.FromSeconds(_sut.ExpiresIn));

        [Fact]
        public void ExpiresUtc() => _sut.ExpiresUtc.Should().Be(_sut.CreatedUtc + _sut.ExpiresInTimespan);

        [Fact]
        public void CreatedUtc() => _sut.CreatedUtc.Should().Be(Epoch.AddSeconds(_sut.CreatedAt));
    }
}
