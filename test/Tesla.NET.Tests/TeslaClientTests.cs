// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using Xunit;

    public class TeslaClient_should
    {
        [Theory, AutoMoqData]
        public void Be_of_Type_ITeslaClient(TeslaClient sut)
        {
            sut.Should().BeAssignableTo<ITeslaClient>();
        }

        [Theory, AutoMoqData]
        public void Use_the_specified_Base_Uri(
            [Frozen] Uri baseUri,
            TeslaClient sut)
        {
            sut.BaseUri.Should().BeSameAs(baseUri);
        }
    }
}
