// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class DebuggerDisplayTestsBase : FixtureContext
    {
        private Type? _sutType;
        private DebuggerDisplayAttribute? _debuggerDisplay;
        private PropertyInfo? _debuggerDisplayPropertyInfo;
        private MethodInfo? _debuggerDisplayGetMethod;
        private object? _debuggerDisplayValue;
        protected string? DebuggerDisplayText;

        protected DebuggerDisplayTestsBase(ITestOutputHelper output)
            : base(output)
        {
        }

        protected void GetDebuggerDisplay<TSut>(TSut sut)
        {
            _sutType = sut?.GetType();

            _debuggerDisplay = _sutType?.GetCustomAttribute<DebuggerDisplayAttribute>(inherit: false);

            _debuggerDisplayPropertyInfo =
                _sutType?.GetProperty("DebuggerDisplay", BindingFlags.NonPublic | BindingFlags.Instance);

            _debuggerDisplayGetMethod = _debuggerDisplayPropertyInfo?.GetGetMethod(true);

            _debuggerDisplayValue = _debuggerDisplayGetMethod?.Invoke(sut, new object[] { });

            DebuggerDisplayText = _debuggerDisplayValue?.ToString();
        }

        [Fact]
        public void have_the_debugger_display_attribute()
        {
            _debuggerDisplay.Should().NotBeNull();
        }

        [Fact]
        public void specify_the_debugger_display_property()
        {
            if (_debuggerDisplay is null) throw new InvalidOperationException(nameof(_debuggerDisplay) + " is null");

            _debuggerDisplay.Value.Should().BeEquivalentTo("{DebuggerDisplay,nq}");
        }

        [Fact]
        public void have_the_debugger_display_private_property()
        {
            _debuggerDisplayPropertyInfo.Should().NotBeNull();
        }

        [Fact]
        public void have_a_getter_on_the_debugger_display_property()
        {
            _debuggerDisplayGetMethod.Should().NotBeNull();
        }

        [Fact]
        public void provide_a_string_debugger_display_property()
        {
            _debuggerDisplayValue.Should().BeOfType<string>();
        }

        [Fact]
        public void include_the_type_in_the_debugger_display()
        {
            if (_sutType is null) throw new InvalidOperationException(nameof(_sutType) + " is null");

            DebuggerDisplayText.Should().StartWith($"{_sutType.Name}:");
        }
    }
}
