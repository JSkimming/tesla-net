// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Tesla.NET.Models;
    using Tesla.NET.Requests;

    /// <inheritdoc />
    public class TeslaAuthClient : TeslaClientBase, ITeslaAuthClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaAuthClient"/> class.
        /// </summary>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaAuthClient(params HttpMessageHandler[] handlers)
            : base(handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaAuthClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="TeslaClientBase.BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaAuthClient(Uri baseUri, params HttpMessageHandler[] handlers)
            : base(baseUri, handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaAuthClient"/> class.
        /// </summary>
        /// <param name='client'>The <see cref="TeslaClientBase.Client"/>.</param>
        public TeslaAuthClient(HttpClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaAuthClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="TeslaClientBase.BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='client'>The <see cref="TeslaClientBase.Client"/>.</param>
        public TeslaAuthClient(Uri baseUri, HttpClient client)
            : base(baseUri, client)
        {
        }

        /// <inheritdoc />
        public Task<MessageResponse<AccessTokenResponse>> RequestAccessTokenAsync(
            string clientId,
            string clientSecret,
            string email,
            string password,
            CancellationToken cancellationToken = default)
        {
            return Client.RequestAccessTokenAsync(BaseUri, clientId, clientSecret, email, password, cancellationToken);
        }

        ////public async Task RefreshAccessTokenAsync(string clientId, string clientSecret, string refreshToken)
        ////{
        ////}
    }
}
