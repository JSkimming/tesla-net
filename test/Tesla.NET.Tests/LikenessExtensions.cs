// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SemanticComparison;
    using SemanticComparison.Fluent;
    using Tesla.NET.Models;

    internal static class LikenessExtensions
    {
        public static Likeness<T, T> AsLikeness<T>(this T actual)
            where T : class
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual.AsSource().OfLikeness<T>();
        }

        public static Likeness<Vehicle, Vehicle> AsLikeness(this Vehicle actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<Vehicle>()
                .With(e => e.Tokens)
                .EqualsWhen((a, e) => a.Tokens.SequenceEqual(e.Tokens));
        }
    }
}
