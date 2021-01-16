// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The message response from the Tesla Owner API.
    /// </summary>
    public interface IMessageResponse
    {
        /// <summary>
        /// Gets the <see cref="HttpStatusCode"/>.
        /// </summary>
        HttpStatusCode HttpStatusCode { get; }

        /// <summary>
        /// Gets the raw JSON of the <see cref="IMessageResponse"/>.
        /// </summary>
        JObject? RawJson { get; }

        /// <summary>
        /// Gets the raw JSON of the <see cref="IMessageResponse"/>.
        /// </summary>
        [JsonIgnore]
        string RawJsonAsString { get; }
    }
}
