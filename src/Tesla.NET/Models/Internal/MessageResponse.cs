// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The message response from the Tesla Owner API.
    /// </summary>
    /// <typeparam name="TData">The <see cref="Type"/> of the <see cref="Data"/>.</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class MessageResponse<TData> : IMessageResponse<TData>
        where TData : class
    {
        private readonly JObject? _rawJson;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResponse{TData}"/> class.
        /// </summary>
        /// <param name="httpStatusCode">The <see cref="HttpStatusCode"/>.</param>
        /// <param name="rawJson">The raw JSON of the <see cref="Data"/>.</param>
        /// <param name="data">The <see cref="Data"/> object.</param>
        public MessageResponse(HttpStatusCode httpStatusCode, JObject? rawJson = null, TData? data = null)
        {
            HttpStatusCode = httpStatusCode;
            _rawJson = rawJson;
            Data = data;
        }

        /// <summary>
        /// Gets the <see cref="HttpStatusCode"/>.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; }

        /// <summary>
        /// Gets the raw JSON of the <see cref="IMessageResponse"/>.
        /// </summary>
        public JObject? RawJson => (JObject?)_rawJson?.DeepClone();

        /// <summary>
        /// Gets the raw JSON of the <see cref="IMessageResponse"/>.
        /// </summary>
        public string RawJsonAsString => _rawJson?.ToString(Formatting.None) ?? string.Empty;

        /// <summary>
        /// Gets the <typeparamref name="TData"/> object.
        /// </summary>
        public TData? Data { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {HttpStatusCode:G}";
    }
}
