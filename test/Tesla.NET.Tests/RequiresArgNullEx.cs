// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoTest.ArgNullEx;
    using AutoTest.ArgNullEx.Xunit;
    using Tesla.NET.Models.Internal;
    using Xunit;

    public class RequiresArgNullEx
    {
        [Theory]
        [RequiresArgNullExAutoMoq(typeof(TeslaClientBase))]
        [Substitute(typeof(TeslaClientBase), typeof(TeslaAuthClient))]
        [Substitute(typeof(MessageResponse<>), typeof(MessageResponse<object>))]
        [Substitute(typeof(ResponseDataWrapper<>), typeof(ResponseDataWrapper<Guid>))]
        [Exclude(Method = "ReadJsonAsAsync", Parameter = "responseTask")]
        public Task TeslaNet(MethodData method)
        {
            return method.Execute();
        }
    }
}
