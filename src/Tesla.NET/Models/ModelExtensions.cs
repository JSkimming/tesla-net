// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for the models.
    /// </summary>
    public static class ModelExtensions
    {
        /// <summary>
        /// Gets a value that indicates if the <paramref name="messageResponse"/> was successful.
        /// </summary>
        /// <param name="messageResponse">A <see cref="IMessageResponse"/>.</param>
        /// <returns>
        /// <see langword="true" /> if <see cref="IMessageResponse.HttpStatusCode" /> was in the range 200-299;
        /// otherwise <see langword="false" />.
        /// </returns>
        public static bool IsSuccessStatusCode(this IMessageResponse messageResponse)
        {
            if (messageResponse == null)
                throw new ArgumentNullException(nameof(messageResponse));

            int statusCode = (int)messageResponse.HttpStatusCode;
            bool successStatusCode = statusCode >= 200 && statusCode <= 299;
            return successStatusCode;
        }
    }
}
