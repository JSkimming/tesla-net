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
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Primitives;
    using Tesla.NET.Models;
    using Tesla.NET.Models.Internal;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class RevokeAccessTokenTests : AuthRequestContext
    {
        private readonly Uri _expectedRequestUri;
        private readonly string _accessToken;

        protected RevokeAccessTokenTests(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output, useCustomBaseUri)
        {
            // Arrange
            Handler.SetResponseContent(new object());
            _expectedRequestUri = new Uri(BaseUri, "oauth/revoke");

            _accessToken = Fixture.Create("accessToken");
        }

        [Fact]
        public async Task Should_make_a_POST_request()
        {
            // Act
            await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            Handler.Request.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public async Task Should_request_the_OAuth_Token_endpoint()
        {
            // Act
            await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            Handler.Request.RequestUri.Should().Be(_expectedRequestUri);
        }

        [Fact]
        public async Task Should_set_the_bearer_token_with_the_specified_access_token()
        {
            // Act
            await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            Handler.Request.Headers.Authorization.Scheme.Should().Be("Bearer");
            Handler.Request.Headers.Authorization.Parameter.Should().Be(_accessToken);
        }

        [Fact]
        public async Task Should_return_the_expected_response()
        {
            // Act
            IMessageResponse actual = await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            actual.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            actual.RawJsonAsString.Should().Be("{}");
        }

        [Fact]
        public async Task Should_POST_1_parameters()
        {
            // Act
            await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            string? requestContent = Handler.RequestContents[0];
            Dictionary<string, StringValues> formParameters = QueryHelpers.ParseQuery(requestContent);

            formParameters.Should().HaveCount(1);
        }

        [Fact]
        public async Task Should_POST_the_token_parameter()
        {
            // Act
            await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            string? requestContent = Handler.RequestContents[0];
            Dictionary<string, StringValues> formParameters = QueryHelpers.ParseQuery(requestContent);

            formParameters
                .Should().ContainKey("token")
                .WhichValue.Should().HaveCount(1)
                .And.ContainSingle(_accessToken);
        }
    }

    public class When_revoking_an_access_token_using_the_default_base_Uri : RevokeAccessTokenTests
    {
        public When_revoking_an_access_token_using_the_default_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: false)
        {
        }
    }

    public class When_revoking_an_access_token_using_a_custom_base_Uri : RevokeAccessTokenTests
    {
        public When_revoking_an_access_token_using_a_custom_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: true)
        {
        }
    }

    public abstract class RevokeAccessTokenFailureTestsBase : AuthRequestContext
    {
        private readonly string _accessToken;

        protected RevokeAccessTokenFailureTestsBase(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output, useCustomBaseUri)
        {
            // Arrange
            Handler.SetResponseContent(new { response = "authorization_required" }, HttpStatusCode.Unauthorized);

            _accessToken = Fixture.Create("accessToken");
        }

        [Fact]
        public async Task  Should_return_the_error_status_code()
        {
            // Act
            IMessageResponse actual = await Sut.RevokeAccessTokenAsync(_accessToken).ConfigureAwait(false);

            // Assert
            actual.HttpStatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }

    public class When_failing_to_revoke_an_access_token_using_the_default_base_Uri
        : RevokeAccessTokenFailureTestsBase
    {
        public When_failing_to_revoke_an_access_token_using_the_default_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: false)
        {
        }
    }

    public class When_failing_to_revoke_an_access_token_using_a_custom_base_Uri
        : RevokeAccessTokenFailureTestsBase
    {
        public When_failing_to_revoke_an_access_token_using_a_custom_base_Uri(ITestOutputHelper output)
            : base(output, useCustomBaseUri: true)
        {
        }
    }
}
