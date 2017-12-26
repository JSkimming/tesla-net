// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// The wrapper object for a response from the Tesla Owner API.
    /// </summary>
    /// <typeparam name="TResponse">The <see cref="Type"/> of the <see cref="Response"/>.</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ResponseDataWrapper<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseDataWrapper{TResponse}"/> class.
        /// </summary>
        /// <param name="response">The <see cref="Response"/> object.</param>
        public ResponseDataWrapper(TResponse response = default)
        {
            Response = response;
        }

        /// <summary>
        /// Gets the <typeparamref name="TResponse"/> object.
        /// </summary>
        [JsonProperty("response")]
        public TResponse Response { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {typeof(TResponse).Name}";
    }
}
