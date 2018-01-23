// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the common properties of all state requests.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Gets the millisecond Epoch timestamp when the <see cref="IState"/> was captured.
        /// </summary>
        [JsonProperty("timestamp")]
        long Timestamp { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="IState"/> was captured.
        /// </summary>
        [JsonIgnore]
        DateTime TimestampUtc { get; }
    }
}
