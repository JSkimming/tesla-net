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
    using Newtonsoft.Json.Linq;
    using Tesla.NET.Models;
    using Xunit;

    public abstract class RequestAccessTokenSuccessTestsBase : AuithRequestContext
    {
        private readonly AccessTokenResponse _expected;
        private readonly Uri _expectedRequestUri;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _email;
        private readonly string _password;

        protected RequestAccessTokenSuccessTestsBase(bool useCustomBaseUri)
            : base(useCustomBaseUri)
        {
            // Arrange
            _expected = Fixture.Create<AccessTokenResponse>();
            Handler.SetResponseContent(_expected);
            _expectedRequestUri = new Uri(BaseUri, "oauth/token");

            _clientId = Fixture.Create("clientId");
            _clientSecret = Fixture.Create("clientSecret");
            _email = Fixture.Create("email");
            _password = Fixture.Create("password");
        }

        [Fact]
        public async Task Should_make_a_POST_request()
        {
            // Act
            await Sut.RequestAccessTokenAsync(_clientId, _clientSecret, _email, _password)
                .ConfigureAwait(false);

            // Assert
            Handler.Request.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public async Task Should_request_the_OAuth_Token_endpoint()
        {
            // Act
            await Sut.RequestAccessTokenAsync(_clientId, _clientSecret, _email, _password)
                .ConfigureAwait(false);

            // Assert
            Handler.Request.RequestUri.Should().Be(_expectedRequestUri);
        }

        [Fact]
        public async Task Should_return_the_expected_access_token()
        {
            // Act
            MessageResponse<AccessTokenResponse> actual =
                await Sut.RequestAccessTokenAsync(_clientId, _clientSecret, _email, _password)
                    .ConfigureAwait(false);

            // Assert
            actual.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            actual.Data.AsLikeness().ShouldEqual(_expected);
        }
    }

    public class When_requesting_an_access_token_using_the_default_base_Uri : RequestAccessTokenSuccessTestsBase
    {
        public When_requesting_an_access_token_using_the_default_base_Uri()
            : base(useCustomBaseUri: false)
        {
        }
    }

    public class When_requesting_an_access_token_using_a_custom_base_Uri : RequestAccessTokenSuccessTestsBase
    {
        public When_requesting_an_access_token_using_a_custom_base_Uri()
            : base(useCustomBaseUri: true)
        {
        }
    }

    public abstract class RequestAccessTokenFailureTestsBase : AuithRequestContext
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _email;
        private readonly string _password;

        protected RequestAccessTokenFailureTestsBase(bool useCustomBaseUri)
            : base(useCustomBaseUri)
        {
            // Arrange
            Handler.SetResponseContent(new JObject(), HttpStatusCode.Unauthorized);

            _clientId = Fixture.Create("clientId");
            _clientSecret = Fixture.Create("clientSecret");
            _email = Fixture.Create("email");
            _password = Fixture.Create("password");
        }

        [Fact]
        public void Should_throw_an_HttpRequestException()
        {
            // Act
            Func<Task> action = () => Sut.RequestAccessTokenAsync(_clientId, _clientSecret, _email, _password);

            // Assert
            action.ShouldThrowExactly<HttpRequestException>();
        }
    }

    public class When_failing_to_request_an_access_token_using_the_default_base_Uri
        : RequestAccessTokenFailureTestsBase
    {
        public When_failing_to_request_an_access_token_using_the_default_base_Uri()
            : base(useCustomBaseUri: false)
        {
        }
    }

    public class When_failing_to_request_an_access_token_using_a_custom_base_Uri
        : RequestAccessTokenFailureTestsBase
    {
        public When_failing_to_request_an_access_token_using_a_custom_base_Uri()
            : base(useCustomBaseUri: true)
        {
        }
    }
}
