// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;

    /// <summary>
    /// The message response from the Tesla Owner API.
    /// </summary>
    /// <typeparam name="TData">The <see cref="Type"/> of the <see cref="Data"/>.</typeparam>
    public interface IMessageResponse<out TData> : IMessageResponse
        where TData : class
    {
        /// <summary>
        /// Gets the <typeparamref name="TData"/> object.
        /// </summary>
        TData? Data { get; }
    }
}
