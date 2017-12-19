// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;

    /// <inheritdoc cref="ITeslaClient" />
    public partial class TeslaClient : IDisposable
    {
        /// <summary>
        /// Finalizes an instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        ~TeslaClient()
        {
            Dispose(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="TeslaClient"/> and optionally releases the managed
        /// resources.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release
        /// only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Client?.Dispose();
            }

            Client = null;
            BaseUri = null;
        }
    }
}
