// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The response to an access token or refresh token request.
    /// </summary>
    public interface IAccessTokenResponse
    {
        /// <summary>
        /// Gets the access token.
        /// </summary>
        [JsonProperty("access_token")]
        string AccessToken { get; }

        /// <summary>
        /// Gets the type of the <see cref="AccessToken"/>.
        /// </summary>
        [JsonProperty("token_type")]
        string TokenType { get; }

        /// <summary>
        /// Gets the expiry duration in seconds of the <see cref="AccessToken"/>.
        /// </summary>
        [JsonProperty("expires_in")]
        long ExpiresIn { get; }

        /// <summary>
        /// Gets the expiry duration of the <see cref="AccessToken"/>.
        /// </summary>
        [JsonIgnore]
        TimeSpan ExpiresInTimespan { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="AccessToken"/> expires.
        /// </summary>
        [JsonIgnore]
        DateTime ExpiresUtc { get; }

        /// <summary>
        /// Gets the Epoch timestamp when the <see cref="AccessToken"/> was issued.
        /// </summary>
        [JsonProperty("created_at")]
        long CreatedAt { get; }

        /// <summary>
        /// Gets the UTC <see cref="DateTime"/> when the <see cref="AccessToken"/> was issued.
        /// </summary>
        [JsonIgnore]
        DateTime CreatedUtc { get; }

        /// <summary>
        /// Gets the refresh token that can be used to acquire a new <see cref="AccessToken"/>.
        /// </summary>
        [JsonProperty("refresh_token")]
        string RefreshToken { get; }
    }
}
