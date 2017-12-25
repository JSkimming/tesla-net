// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoFixture;
    using FluentAssertions;
    using Xunit;

    public class When_running_in_the_debugger_MessageResponse_Should : DebuggerDisplayTestsBase
    {
        private readonly MessageResponse<string> _sut;

        public When_running_in_the_debugger_MessageResponse_Should()
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
}
