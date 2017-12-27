// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Tesla.NET.Models;

    /// <summary>
    /// Client for the Tesla Owner API.
    /// </summary>
    public interface ITeslaClient
    {
        /// <summary>
        /// Gets the vehicles associated with an account.
        /// </summary>
        /// <param name="accessToken">
        /// The access token used to authenticate the request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The vehicles associated with an account.</returns>
        Task<MessageResponse<ResponseDataWrapper<IReadOnlyList<Vehicle>>>> GetVehiclesAsync(
            string accessToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the vehicles associated with an account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The vehicles associated with an account.</returns>
        Task<MessageResponse<ResponseDataWrapper<IReadOnlyList<Vehicle>>>> GetVehiclesAsync(
            CancellationToken cancellationToken = default);
    }
}
