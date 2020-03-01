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

    public class TeslaAuthClient_should
    {
        [Fact]
        public void Be_of_Type_ITeslaAuthClient()
        {
            // Arrange/Act
            var sut = new TeslaAuthClient();

            // Assert
            sut.Should().BeAssignableTo<ITeslaAuthClient>();
        }

        [Theory, AutoMoqData]
        public void Use_the_specified_Base_Uri(Uri baseUri)
        {
            // Arrange/Act
            var sut = new TeslaAuthClient(baseUri);

            // Assert
            sut.BaseUri.Should().BeSameAs(baseUri);
        }

        [Theory, AutoMoqData]
        public void Use_the_specified_HTTP_Client_and_Base_Uri(Uri baseUri, HttpClient client)
        {
            // Arrange/Act
            var sut = new TeslaAuthClient(baseUri, client);

            // Assert
            sut.BaseUri.Should().BeSameAs(baseUri);
            sut.Client.Should().BeSameAs(client);
        }

        [Theory, AutoMoqData]
        public void Use_the_specified_HTTP_Client(HttpClient client)
        {
            // Arrange/Act
            var sut = new TeslaAuthClient(client);

            // Assert
            sut.Client.Should().BeSameAs(client);
        }

        [Fact]
        public void Dispose_Is_Idempotent()
        {
            // Arrange
            var sut = new TeslaAuthClient();
            Action action = () => sut.Dispose();

            // Act
            action();

            // Assert
            action.Should().NotThrow();
        }
    }
}
