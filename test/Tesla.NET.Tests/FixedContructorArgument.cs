// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AutoFixture.Kernel;

    internal class FixedContructorArgument<TDeclaringType, TParameterType> : ISpecimenBuilder
    {
        private readonly string _parameterName;

        private readonly Func<TParameterType> _valueFunc;

        public FixedContructorArgument(string parameterName, TParameterType value)
            : this(parameterName, () => value)
        {
        }

        public FixedContructorArgument(string parameterName, IEnumerable<TParameterType> values)
        {
            _parameterName = parameterName;

            IEnumerator<TParameterType> enumerator = values.GetEnumerator();
            _valueFunc = () =>
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }

                throw new InvalidOperationException("There's no more values to enumerate.");
            };
        }

        public FixedContructorArgument(string parameterName, Func<TParameterType> valueFunc)
        {
            _parameterName = parameterName ?? throw new ArgumentNullException(nameof(parameterName));
            _valueFunc = valueFunc ?? throw new ArgumentNullException(nameof(valueFunc));
        }

        public object? Create(object request, ISpecimenContext context)
        {
            if (!(request is ParameterInfo pi))
                return new NoSpecimen();

            if (pi.Member.DeclaringType != typeof(TDeclaringType) ||
                pi.ParameterType != typeof(TParameterType) ||
                pi.Name != _parameterName)
                return new NoSpecimen();

            return _valueFunc();
        }
    }
}
