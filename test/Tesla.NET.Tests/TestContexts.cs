// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using AutoFixture;
    using FluentAssertions.Equivalency;
    using Tesla.NET.HttpHandlers;
    using Xunit.Abstractions;

    public abstract class FixtureContext : IDisposable
    {
        protected FixtureContext(ITestOutputHelper output)
        {
            Output = output;
        }

        ~FixtureContext()
        {
            Dispose(false);
        }

        protected IFixture Fixture { get; } = new Fixture().Customize(new TeslaNetCustomization());

        public StringBuilderTraceWriter TraceWriter { get; } = new StringBuilderTraceWriter();

        public ITestOutputHelper Output { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Output any trace from fluent assertions.
                string faTrace = TraceWriter.ToString().Trim();
                if (!string.IsNullOrWhiteSpace(faTrace))
                {
                    Output.WriteLine("Fluent Assertions Trace:");
                    Output.WriteLine(faTrace);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public EquivalencyAssertionOptions<T> WithStrictOrdering<T>(EquivalencyAssertionOptions<T> config)
        {
            return config.WithStrictOrdering().WithTracing(TraceWriter);
        }
    }

    public class AuthRequestContext : FixtureContext
    {
        protected AuthRequestContext(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output)
        {
            Uri? baseUri = useCustomBaseUri ? Fixture.Create<Uri>() : null;

            Handler = new TestHttpHandler(output);
            Sut = baseUri == null
                ? new TeslaAuthClient(new HttpClient(Handler))
                : new TeslaAuthClient(baseUri, new HttpClient(Handler));

            BaseUri = baseUri ?? TeslaClientBase.DefaultBaseUri;
        }

        protected TestHttpHandler Handler { get; }

        protected TeslaAuthClient Sut { get; }

        protected Uri BaseUri { get; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Handler?.Dispose();
                Sut?.Dispose();
            }

            base.Dispose(disposing);
        }
    }

    public class ClientRequestContext : FixtureContext
    {
        protected ClientRequestContext(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output)
        {
            Uri? baseUri = useCustomBaseUri ? Fixture.Create<Uri>() : null;

            Handler = new TestHttpHandler(output);
            Sut = baseUri == null
                ? new TeslaClient(new HttpClient(Handler))
                : new TeslaClient(baseUri, new HttpClient(Handler));

            BaseUri = baseUri ?? TeslaClientBase.DefaultBaseUri;
            AccessToken = Fixture.Create("AccessToken");
            VehicleId = Fixture.Create<long>();
        }

        protected TestHttpHandler Handler { get; }

        protected TeslaClient Sut { get; }

        protected Uri BaseUri { get; }

        protected string AccessToken { get; }

        protected long VehicleId { get; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Handler?.Dispose();
                Sut?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
