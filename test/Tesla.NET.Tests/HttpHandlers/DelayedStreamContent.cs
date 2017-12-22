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
    /// This override of <see cref="StreamContent"/> simply ads a delay to make the requests more representative of
    /// real HTTP requests.
    /// </summary>
    internal class DelayedStreamContent : StreamContent
    {
        public DelayedStreamContent(Stream stream)
            : base(stream)
        {
        }

        protected override async Task<Stream> CreateContentReadStreamAsync()
        {
            Stream stream = await base.CreateContentReadStreamAsync().ConfigureAwait(false);
            await Task.Yield();
            return stream;
        }
    }
}
