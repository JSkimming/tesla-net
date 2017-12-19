// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    /// <inheritdoc cref="ITeslaClient" />
    public partial class TeslaClient : ITeslaClient
    {
        /// <summary>
        /// The default base <see cref="Uri"/> for the Tesla Owner API.
        /// </summary>
        public static readonly Uri DefaultBaseUri = new Uri("https://owner-api.teslamotors.com/");

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaClient(params HttpMessageHandler[] handlers)
            : this(DefaultBaseUri, handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaClient(Uri baseUri, params HttpMessageHandler[] handlers)
        {
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
            Client = new HttpClient(CreatePipeline(handlers));
        }

        /// <summary>
        /// Gets the base <see cref="Uri"/> of the Tesla Owner API.
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets the underlying HttpClient used to make requests.
        /// </summary>
        public HttpClient Client { get; private set; }

        /// <summary>
        /// Transform a collection of <see cref="HttpMessageHandler"/>s into a chain of
        /// <see cref="HttpMessageHandler"/>s.
        /// </summary>
        /// <param name="handlers">
        /// Chain of <see cref="HttpMessageHandler" /> instances.
        /// All but the last should be <see cref="DelegatingHandler"/>s.
        /// </param>
        /// <returns>A chain of <see cref="HttpMessageHandler"/>s</returns>
        public static HttpMessageHandler CreatePipeline(IReadOnlyCollection<HttpMessageHandler> handlers)
        {
            if (handlers == null)
                throw new ArgumentNullException(nameof(handlers));

            HttpMessageHandler pipeline = handlers.LastOrDefault() ?? CreateDefaultHttpClientHandler();
            if (pipeline is DelegatingHandler dHandler)
            {
                dHandler.InnerHandler = CreateDefaultHttpClientHandler();
                pipeline = dHandler;
            }

            // Wire handlers up in reverse order
            IEnumerable<HttpMessageHandler> reversedHandlers = handlers.Reverse().Skip(1);
            foreach (HttpMessageHandler handler in reversedHandlers)
            {
                dHandler = handler as DelegatingHandler;
                if (dHandler == null)
                {
                    throw new ArgumentException(
                        $"All message handlers except the last must be of type '{typeof(DelegatingHandler).Name}'.",
                        nameof(handlers));
                }

                dHandler.InnerHandler = pipeline;
                pipeline = dHandler;
            }

            return pipeline;
        }

        /// <summary>
        /// Returns a default HttpMessageHandler that supports automatic decompression.
        /// </summary>
        /// <returns>A default HttpMessageHandler that supports automatic decompression.</returns>
        public static HttpClientHandler CreateDefaultHttpClientHandler()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };

            return handler;
        }
    }
}
