// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;

    /// <summary>
    /// Helper methods for converting from Unix <see cref="Epoch"/> timestamps.
    /// </summary>
    internal static class EpochConversion
    {
        /// <summary>
        /// The Unix Epoch which is 1970-01-01T00:00:00.000Z
        /// </summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Returns the UTC <see cref="DateTime"/> of the <paramref name="epoch"/> seconds.
        /// </summary>
        /// <param name="epoch">The number of seconds since the <see cref="Epoch"/>.</param>
        /// <returns>The UTC <see cref="DateTime"/> of the <paramref name="epoch"/> seconds.</returns>
        public static DateTime FromSeconds(long epoch) => Epoch + TimeSpan.FromSeconds(epoch);

        /// <summary>
        /// Returns the UTC <see cref="DateTime"/> of the <paramref name="epoch"/> milliseconds.
        /// </summary>
        /// <param name="epoch">The number of milliseconds since the <see cref="Epoch"/>.</param>
        /// <returns>The UTC <see cref="DateTime"/> of the <paramref name="epoch"/> milliseconds.</returns>
        public static DateTime FromMilliseconds(long epoch) => Epoch + TimeSpan.FromMilliseconds(epoch);
    }
}
