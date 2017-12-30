// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.HttpHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Adds a <see cref="Task.Yield"/> to <see cref="CreateContentReadStreamAsync"/> to ensure streams are read
    /// asynchronously.
    /// </summary>
    internal class ForcedAsyncStreamContent : StreamContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcedAsyncStreamContent"/> class.
        /// </summary>
        /// <param name="stream">The content used to initialize the <see cref="StreamContent"/>.</param>
        public ForcedAsyncStreamContent(MemoryStream stream)
            : base(stream)
        {
            Stream = stream;
        }

        /// <summary>
        /// Gets the underlying <see cref="MemoryStream"/>.
        /// </summary>
        public MemoryStream Stream { get; }

        /// <inheritdoc />
        protected override async Task<Stream> CreateContentReadStreamAsync()
        {
            Stream stream = await base.CreateContentReadStreamAsync().ConfigureAwait(false);
            await Task.Yield();
            return new ForcedAsyncStream(stream);
        }
    }
}
