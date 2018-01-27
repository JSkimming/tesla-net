// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models.Internal
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The response to an access token or refresh token request.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class AccessTokenResponse : IAccessTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">The <see cref="AccessToken"/>.</param>
        /// <param name="tokenType">The type of the <see cref="AccessToken"/>.</param>
        /// <param name="expiresIn">The expiry duration in seconds of the <see cref="AccessToken"/>.</param>
        /// <param name="createdAt">The Epoch timestamp when the <see cref="AccessToken"/> was issued.</param>
        /// <param name="refreshToken">
        /// The refresh token that can be used to acquire a new <see cref="AccessToken"/>.
        /// </param>
        public AccessTokenResponse(
            string accessToken,
            string tokenType,
            long expiresIn,
            long createdAt,
            string refreshToken)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            TokenType = tokenType ?? throw new ArgumentNullException(nameof(tokenType));
            ExpiresIn = expiresIn;
            CreatedAt = createdAt;
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets the type of the <see cref="AccessToken"/>.
        /// </summary>
        public string TokenType { get; }

        /// <summary>
        /// Gets the expiry duration in seconds of the <see cref="AccessToken"/>.
        /// </summary>
        public long ExpiresIn { get; }

        /// <summary>
        /// Gets the expiry duration of the <see cref="AccessToken"/>.
        /// </summary>
        public TimeSpan ExpiresInTimespan => TimeSpan.FromSeconds(ExpiresIn);

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="AccessToken"/> expires.
        /// </summary>
        public DateTime ExpiresUtc => EpochConversion.FromSeconds(CreatedAt + ExpiresIn);

        /// <summary>
        /// Gets the Epoch timestamp when the <see cref="AccessToken"/> was issued.
        /// </summary>
        public long CreatedAt { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="AccessToken"/> was issued.
        /// </summary>
        public DateTime CreatedUtc => EpochConversion.FromSeconds(CreatedAt);

        /// <summary>
        /// Gets the refresh token that can be used to acquire a new <see cref="AccessToken"/>.
        /// </summary>
        public string RefreshToken { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {AccessToken.Substring(0, 6)}… Expires {ExpiresUtc:R}";
    }
}
