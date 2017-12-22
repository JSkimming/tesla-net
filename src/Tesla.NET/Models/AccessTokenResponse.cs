// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// The response to an access token or refresh token request.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class AccessTokenResponse
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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
        [JsonProperty("access_token")]
        public string AccessToken { get; }

        /// <summary>
        /// Gets the type of the <see cref="AccessToken"/>.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; }

        /// <summary>
        /// Gets the expiry duration in seconds of the <see cref="AccessToken"/>.
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; }

        /// <summary>
        /// Gets the expiry duration of the <see cref="AccessToken"/>.
        /// </summary>
        [JsonIgnore]
        public TimeSpan ExpiresInTimestamp => TimeSpan.FromSeconds(ExpiresIn);

        /// <summary>
        /// Gets the date when of the <see cref="AccessToken"/> expires.
        /// </summary>
        [JsonIgnore]
        public DateTime ExpiresWhen => Epoch + TimeSpan.FromSeconds(CreatedAt + ExpiresIn);

        /// <summary>
        /// Gets the Epoch timestamp when the <see cref="AccessToken"/> was issued.
        /// </summary>
        [JsonProperty("created_at")]
        public long CreatedAt { get; }

        /// <summary>
        /// Gets the date when the <see cref="AccessToken"/> was issued.
        /// </summary>
        [JsonIgnore]
        public DateTime CreatedDate => Epoch + TimeSpan.FromSeconds(CreatedAt);

        /// <summary>
        /// Gets the refresh token that can be used to acquire a new <see cref="AccessToken"/>.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {AccessToken.Substring(0, 6)}… Expires {ExpiresWhen:R}";
    }
}
