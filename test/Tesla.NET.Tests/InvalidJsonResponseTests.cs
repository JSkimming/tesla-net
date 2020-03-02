// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using AutoFixture;
    using FluentAssertions;
    using Tesla.NET.HttpHandlers;
    using Tesla.NET.Models;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class InvalidJsonResponseTestsBase : ClientRequestContext
    {
        private readonly long _vehicleId;
        private readonly HttpStatusCode _statusCode;

        protected InvalidJsonResponseTestsBase(ITestOutputHelper output, HttpStatusCode statusCode)
            : base(output, useCustomBaseUri: false)
        {
            // Arrange
            _statusCode = statusCode;
            _vehicleId = Fixture.Create<long>();
            Handler.Response = CreateResponse(statusCode);
        }

        [Fact]
        public async Task It_should_return_just_the_HTTP_status_Code()
        {
            // Act
            IMessageResponse actual = await Sut.GetVehicleStateAsync(_vehicleId, AccessToken).ConfigureAwait(false);

            // Assert
            actual.HttpStatusCode.Should().Be(_statusCode);
        }

        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Act
            Func<Task> action = () => Sut.GetVehicleStateAsync(_vehicleId, AccessToken);

            // Assert
            action.Should().NotThrow();
        }

        private static HttpResponseMessage CreateResponse(HttpStatusCode statusCode)
        {
            string stringContent = "0" + Environment.NewLine + Environment.NewLine;
            var stream = new MemoryStream(32);
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 10240, leaveOpen: true))
            {
                streamWriter.Write(stringContent);
                streamWriter.Close();
            }

            stream.Seek(0, SeekOrigin.Begin);
            var httpContent = new ForcedAsyncStreamContent(stream)
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json"),
                },
            };

            HttpResponseMessage response = new HttpResponseMessage(statusCode)
            {
                Content = httpContent,
            };
            return response;
        }
    }

    /// <summary>
    /// The Tesla Owners API returns a body of <c>0</c> in an unauthorized response, but still states the
    /// <c>Content-Type</c> is <c>application/json</c>. These test is defined to ensure the Tesla.NET client does not
    /// break in such circumstances.
    /// </summary>
    /// <example>
    /// The following is an example 401 Unauthorized response.
    /// <code>
    /// HTTP/1.1 401 Unauthorized
    /// Server: nginx
    /// Date: Thu, 01 Feb 2018 07:58:39 GMT
    /// Content-Type: application/json
    /// Transfer-Encoding: chunked
    /// Connection: keep-alive
    /// X-Frame-Options: SAMEORIGIN
    /// X-XSS-Protection: 1; mode=block
    /// X-Content-Type-Options: nosniff
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// WWW-Authenticate: Bearer realm="Doorkeeper", error="invalid_token", error_description="The access token is invalid"
    /// X-Request-Id: b05b4cc2-7684-49bb-b2cc-57c548d4a2cf
    /// X-Runtime: 0.024554
    ///
    /// 0
    /// </code>
    /// </example>
    public class When_getting_invalid_JSON_in_an_unauthorised_response : InvalidJsonResponseTestsBase
    {
        public When_getting_invalid_JSON_in_an_unauthorised_response(ITestOutputHelper output)
            : base(output, HttpStatusCode.Unauthorized)
        {
        }
    }

    /// <summary>
    /// This simply tests any other error response with invalid JKSON doesn't throw an exception.
    /// </summary>
    public class When_getting_invalid_JSON_in_an_error_response : InvalidJsonResponseTestsBase
    {
        public When_getting_invalid_JSON_in_an_error_response(ITestOutputHelper output)
            : base(output, HttpStatusCode.Conflict)
        {
        }
    }
}
