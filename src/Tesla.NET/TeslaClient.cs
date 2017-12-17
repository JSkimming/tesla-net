// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Client for the Tesla Owner API.
    /// </summary>
    public class TeslaClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="BaseUri"/> of the Tesla Owner API.</param>
        public TeslaClient(Uri baseUri)
        {
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
        }

        /// <summary>
        /// Gets the base <see cref="Uri"/> of the Tesla Owner API.
        /// </summary>
        public Uri BaseUri { get; }
    }
}
