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
    /// Authentication client for the Tesla Owner API.
    /// </summary>
    public interface ITeslaAuthClient
    {
        /// <summary>
        /// Requests an access token for access to the Tesla Owner API.
        /// </summary>
        /// <param name="clientId">The unique ID of the client.</param>
        /// <param name="clientSecret">The secret for the <paramref name="clientId"/>.</param>
        /// <param name="email">The unique email address of a Tesla Owner.</param>
        /// <param name="password">The password for the <paramref name="email"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The response to the request for an access token.</returns>
        Task<IMessageResponse<IAccessTokenResponse>> RequestAccessTokenAsync(
            string clientId,
            string clientSecret,
            string email,
            string password,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Refreshes an access token for access to the Tesla Owner API.
        /// </summary>
        /// <param name="clientId">The unique ID of the client.</param>
        /// <param name="clientSecret">The secret for the <paramref name="clientId"/>.</param>
        /// <param name="refreshToken">A refresh token for a Tesla Owner.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The response to the request for an access token.</returns>
        Task<IMessageResponse<IAccessTokenResponse>> RefreshAccessTokenAsync(
            string clientId,
            string clientSecret,
            string refreshToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Revokes the accessToken issued by the token request.
        /// </summary>
        /// <param name="accessToken">The access token issued by the token request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to complete.</param>
        /// <returns>200 for ok. </returns>
        Task<IMessageResponse> RevokeAccessTokenAsync(
            string accessToken,
            CancellationToken cancellationToken = default);
    }
}
