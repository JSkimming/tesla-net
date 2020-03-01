// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AutoFixture;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Tesla.NET.Models;
    using Tesla.NET.Models.Internal;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class GetVehiclesSuccessTestsBase : ClientRequestContext
    {
        private readonly ResponseDataWrapper<IReadOnlyList<Vehicle>> _expected;
        private readonly Uri _expectedRequestUri;

        protected GetVehiclesSuccessTestsBase(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output, useCustomBaseUri)
        {
            // Arrange
            _expected = Fixture.Create<ResponseDataWrapper<IReadOnlyList<Vehicle>>>();
            Handler.SetResponseContent(_expected);
            _expectedRequestUri = new Uri(BaseUri, "api/1/vehicles");
        }

        [Fact]
        public async Task Should_make_a_GET_request()
        {
            // Act
            await Sut.GetVehiclesAsync(AccessToken).ConfigureAwait(false);

            // Assert
            Handler.Request.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public async Task Should_request_the_vehicles_endpoint()
        {
            // Act
            await Sut.GetVehiclesAsync(AccessToken).ConfigureAwait(false);

            // Assert
            Handler.Request.RequestUri.Should().Be(_expectedRequestUri);
        }

        [Fact]
        public async Task Should_return_the_expected_vehicles()
        {
            // Act
            IMessageResponse<IResponseDataWrapper<IReadOnlyList<IVehicle>>> actual =
                await Sut.GetVehiclesAsync(AccessToken).ConfigureAwait(false);

            // Assert
            actual.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            actual.Data.Should().BeEquivalentTo(_expected, WithStrictOrdering);
        }

        [Fact]
        public async Task Should_set_the_bearer_token_with_the_specified_access_token()
        {
            // Act
            await Sut.GetVehiclesAsync(AccessToken).ConfigureAwait(false);

            // Assert
            Handler.Request.Headers.Authorization.Scheme.Should().Be("Bearer");
            Handler.Request.Headers.Authorization.Parameter.Should().Be(AccessToken);
        }

        [Fact]
        public async Task Should_NOT_set_the_bearer_token_if_the_access_token_is_not_specified()
        {
            // Act
            await Sut.GetVehiclesAsync().ConfigureAwait(false);

            // Assert
            Handler.Request.Headers.Authorization.Should().BeNull();
        }
    }

    public class When_getting_the_vehicles_for_an_account_using_the_default_base_Uri : GetVehiclesSuccessTestsBase
    {
        public When_getting_the_vehicles_for_an_account_using_the_default_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: false)
        {
        }
    }

    public class When_getting_the_vehicles_for_an_account_using_a_custom_base_Uri : GetVehiclesSuccessTestsBase
    {
        public When_getting_the_vehicles_for_an_account_using_a_custom_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: true)
        {
        }
    }

    public abstract class GetVehiclesFailureTestsBase : ClientRequestContext
    {
        protected GetVehiclesFailureTestsBase(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output, useCustomBaseUri)
        {
            // Arrange
            Handler.SetResponse(HttpStatusCode.BadGateway);
        }

        [Fact]
        public async Task Should_return_the_error_status_code()
        {
            // Act
            IMessageResponse actual = await Sut.GetVehiclesAsync(AccessToken).ConfigureAwait(false);

            // Assert
            actual.HttpStatusCode.Should().Be(HttpStatusCode.BadGateway);
        }
    }

    public class When_failing_to_get_the_vehicles_for_an_account_using_the_default_base_Uri
        : GetVehiclesFailureTestsBase
    {
        public When_failing_to_get_the_vehicles_for_an_account_using_the_default_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: false)
        {
        }
    }

    public class When_failing_to_get_the_vehicles_for_an_account_using_a_custom_base_Uri
        : GetVehiclesFailureTestsBase
    {
        public When_failing_to_get_the_vehicles_for_an_account_using_a_custom_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: true)
        {
        }
    }

    public class When_getting_the_vehicles_for_an_account_the_raw_JSON : ClientRequestContext
    {
        private readonly JObject _expected;

        public When_getting_the_vehicles_for_an_account_the_raw_JSON(ITestOutputHelper output)
            : base(output, useCustomBaseUri: false)
        {
            // Arrange
            _expected = SampleJson.GetVehiclesResponse;

            // Add random values to test whether it is correctly passed through.
            _expected["randomValue1"] = Fixture.Create("randomValue1");
            _expected["randomValue2"] = JObject.FromObject(new { fakeId = Guid.NewGuid() });
            JToken response = _expected["response"]?[0] ?? throw new InvalidOperationException("response is null.");
            response["randomValue3"] = Fixture.Create("randomValue3");

            Handler.SetResponseContent(_expected);
        }

        [Fact]
        public async Task Should_be_passed_through_in_the_response()
        {
            // Act
            IMessageResponse response = await Sut.GetVehiclesAsync().ConfigureAwait(false);

            // Assert
            response.RawJsonAsString.Should().Be(_expected.ToString(Formatting.None));
        }
    }
}
