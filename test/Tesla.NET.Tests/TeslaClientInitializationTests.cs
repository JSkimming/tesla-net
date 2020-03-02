// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using FluentAssertions;
    using Xunit;

    public class TeslaClient_should
    {
        [Fact]
        public void Be_of_Type_ITeslaClient()
        {
            // Arrange/Act
            var sut = new TeslaClient();

            // Assert
            sut.Should().BeAssignableTo<ITeslaClient>();
        }

        [Theory]
        [AutoMoqData]
        public void Use_the_specified_Base_Uri(Uri baseUri)
        {
            // Arrange/Act
            var sut = new TeslaClient(baseUri);

            // Assert
            sut.BaseUri.Should().BeSameAs(baseUri);
        }

        [Theory]
        [AutoMoqData]
        public void Use_the_specified_HTTP_Client_and_Base_Uri(Uri baseUri, HttpClient client)
        {
            // Arrange/Act
            var sut = new TeslaClient(baseUri, client);

            // Assert
            sut.BaseUri.Should().BeSameAs(baseUri);
            sut.Client.Should().BeSameAs(client);
        }

        [Theory]
        [AutoMoqData]
        public void Use_the_specified_HTTP_Client(HttpClient client)
        {
            // Arrange/Act
            var sut = new TeslaClient(client);

            // Assert
            sut.Client.Should().BeSameAs(client);
        }

        [Fact]
        public void Dispose_Is_Idempotent()
        {
            // Arrange
            var sut = new TeslaClient();
            Action action = () => sut.Dispose();

            // Act
            action();

            // Assert
            action.Should().NotThrow();
        }
    }
}
