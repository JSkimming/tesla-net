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
    using Xunit.Abstractions;

    public class When_running_in_the_debugger_ResponseDataWrapper_Should : DebuggerDisplayTestsBase
    {
        private readonly ResponseDataWrapper<IReadOnlyList<Vehicle>> _sut;

        public When_running_in_the_debugger_ResponseDataWrapper_Should(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<ResponseDataWrapper<IReadOnlyList<Vehicle>>>();
            GetDebuggerDisplay(_sut);
        }

        [Fact]
        public void include_the_type_of_the_response_in_the_debugger_display()
        {
            DebuggerDisplayText.Should().Contain(typeof(IReadOnlyList<Vehicle>).Name);
        }
    }
}
