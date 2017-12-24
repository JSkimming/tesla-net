// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Diagnostics;
    using System.Net;

    /// <summary>
    /// The message response from the Tesla Owner API.
    /// </summary>
    /// <typeparam name="TData">The <see cref="Type"/> of the <see cref="Data"/>.</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class MessageResponse<TData>
        where TData : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResponse{TData}"/> class.
        /// </summary>
        /// <param name="httpStatusCode">The <see cref="HttpStatusCode"/>.</param>
        /// <param name="data">The <see cref="Data"/> object.</param>
        public MessageResponse(HttpStatusCode httpStatusCode, TData data)
        {
            HttpStatusCode = httpStatusCode;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Gets the <see cref="HttpStatusCode"/>.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; }

        /// <summary>
        /// Gets the <typeparamref name="TData"/> object.
        /// </summary>
        public TData Data { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {HttpStatusCode:G}";
    }
}
