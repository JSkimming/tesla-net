// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    /// <inheritdoc cref="ITeslaClient" />
    public class TeslaClient : TeslaClientBase, ITeslaClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaClient(params HttpMessageHandler[] handlers)
            : base(handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="TeslaClientBase.BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaClient(Uri baseUri, params HttpMessageHandler[] handlers)
            : base(baseUri, handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name='client'>The <see cref="TeslaClientBase.Client"/>.</param>
        public TeslaClient(HttpClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="TeslaClientBase.BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='client'>The <see cref="TeslaClientBase.Client"/>.</param>
        public TeslaClient(Uri baseUri, HttpClient client)
            : base(baseUri, client)
        {
        }
    }
}
