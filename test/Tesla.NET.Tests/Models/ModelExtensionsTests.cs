// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class Is_Success_Status_Code_Should_Return
    {
        private Mock<IMessageResponse> _messageResponseMock;

        public Is_Success_Status_Code_Should_Return()
        {
            _messageResponseMock = new Mock<IMessageResponse>();
        }

        [Fact]
        public void False_if_the_status_code_is_less_than_200()
        {
            // Arrange
            _messageResponseMock.SetupGet(r => r.HttpStatusCode).Returns((HttpStatusCode)199);

            // Act
            bool successStatusCode = _messageResponseMock.Object.IsSuccessStatusCode();

            // Assert
            successStatusCode.Should().BeFalse();
        }

        [Fact]
        public void True_if_the_status_code_is_in_the_200_range()
        {
            // Arrange
            Random rnd = new Random();
            HttpStatusCode statusCode = (HttpStatusCode)rnd.Next(200, 300);
            _messageResponseMock.SetupGet(r => r.HttpStatusCode).Returns(statusCode);

            // Act
            bool successStatusCode = _messageResponseMock.Object.IsSuccessStatusCode();

            // Assert
            successStatusCode.Should().BeTrue();
        }

        [Fact]
        public void False_if_the_status_code_is_greater_than_299()
        {
            // Arrange
            _messageResponseMock.SetupGet(r => r.HttpStatusCode).Returns((HttpStatusCode)300);

            // Act
            bool successStatusCode = _messageResponseMock.Object.IsSuccessStatusCode();

            // Assert
            successStatusCode.Should().BeFalse();
        }
    }
}
