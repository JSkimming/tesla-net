// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using AutoFixture;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;
    using Xunit.Abstractions;

    public class When_running_in_the_debugger_MessageResponse_Should : DebuggerDisplayTestsBase
    {
        private readonly MessageResponse<string> _sut;

        public When_running_in_the_debugger_MessageResponse_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<MessageResponse<string>>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_HTTP_status_code_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(_sut.HttpStatusCode.ToString("G"));
        }
    }

    public class When_getting_the_raw_JSON_MessageResponse_Should : FixtureContext
    {
        private readonly MessageResponse<ResponseDataWrapper<DriveState>> _sut;
        private readonly JObject _rawJson;
        private readonly string _rawJsonString;
        private readonly ITestOutputHelper _output;

        public When_getting_the_raw_JSON_MessageResponse_Should(ITestOutputHelper output)
            : base(output)
        {
            _output = output;
            _rawJson = SampleJson.GetDriveStateResponse;
            _rawJson["randomValue1"] = Fixture.Create("randomValue1");
            _rawJson["randomValue2"] = JObject.FromObject(new { fakeId = Guid.NewGuid() });
            JToken response = _rawJson["response"] ?? throw new InvalidOperationException("response is null.");
            response["randomValue3"] = Fixture.Create("randomValue3");
            _rawJsonString = _rawJson.ToString(Formatting.Indented);

            ResponseDataWrapper<DriveState> data =
                _rawJson.ToObject<ResponseDataWrapper<DriveState>>() ?? throw new InvalidOperationException();

            _sut = new MessageResponse<ResponseDataWrapper<DriveState>>(HttpStatusCode.OK, _rawJson, data);

            output.WriteLine("Raw JSON:" + Environment.NewLine + _rawJsonString);
        }

        [Fact]
        public void return_a_deep_clone_of_the_raw_JSON()
        {
            // Act
            JObject clone = _sut.RawJson ?? throw new InvalidOperationException();

            _output.WriteLine("Cloned JSON:" + Environment.NewLine + clone);

            // Assert
            clone.Should().NotBeSameAs(_rawJson);
            clone.ToString().Should().Be(_rawJsonString);
        }

        [Fact]
        public void not_change_the_original_JSON()
        {
            // Act
            JObject clone = _sut.RawJson ?? throw new InvalidOperationException();
            JToken response = clone["response"] ?? throw new InvalidOperationException("response is null.");
            response["randomValue3"] = Fixture.Create("updatedRandomValue3");

            _output.WriteLine("Modified JSON:" + Environment.NewLine + clone);

            // Assert
            clone.ToString().Should().NotBe(_rawJsonString);
            _sut.RawJsonAsString.Should().Be(_rawJson.ToString(Formatting.None));
        }

        [Fact]
        public void return_a_new_clone_every_time()
        {
            // Act
            JObject clone1 = _sut.RawJson ?? throw new InvalidOperationException();
            JObject clone2 = _sut.RawJson;

            // Assert
            clone2.Should().NotBeSameAs(clone1);
        }
    }

    public class When_there_is_no_raw_JSON_MessageResponse_Should
    {
        private readonly MessageResponse<ResponseDataWrapper<DriveState>> _sut;

        public When_there_is_no_raw_JSON_MessageResponse_Should()
        {
            _sut = new MessageResponse<ResponseDataWrapper<DriveState>>(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void return_a_null_raw_JSON_object()
        {
            _sut.RawJson.Should().BeNull();
        }

        [Fact]
        public void return_an_empty_string_for_the_null_JSON()
        {
            _sut.RawJsonAsString.Should().BeEmpty();
        }
    }
}
