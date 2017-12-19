// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        [Theory, AutoMoqData]
        public void Use_the_specified_Base_Uri(Uri baseUri)
        {
            // Arrange/Act
            var sut = new TeslaClient(baseUri);

            // Assert
            sut.BaseUri.Should().BeSameAs(baseUri);
        }

        [Fact]
        public void Dispose_The_HttpClient()
        {
            // Arrange
            var sut = new TeslaClient();

            // Act
            sut.Dispose();

            // Assert
            sut.Client.Should().BeNull();
            sut.BaseUri.Should().BeNull();
        }

        [Fact]
        public void Dispose_Is_Idempotent()
        {
            // Arrange
            var sut = new TeslaClient();

            // Act
            sut.Dispose();
            sut.Dispose();

            // Assert
            sut.Client.Should().BeNull();
            sut.BaseUri.Should().BeNull();
        }
    }
}
