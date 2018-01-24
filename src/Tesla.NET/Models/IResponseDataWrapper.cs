// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The wrapper object for a response from the Tesla Owner API.
    /// </summary>
    /// <typeparam name="TResponse">The <see cref="Type"/> of the <see cref="Response"/>.</typeparam>
    public interface IResponseDataWrapper<out TResponse>
    {
        /// <summary>
        /// Gets the <typeparamref name="TResponse"/> object.
        /// </summary>
        [JsonProperty("response")]
        TResponse Response { get; }
    }
}
