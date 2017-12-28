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

        protected IFixture Fixture { get; private set; } = new Fixture().Customize(new TeslaNetCustomization());

        public StringBuilderTraceWriter TraceWriter { get; private set; } = new StringBuilderTraceWriter();

        public ITestOutputHelper Output { get; private set; }

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

            Fixture = null;
            TraceWriter = null;
            Output = null;
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
            Uri baseUri = useCustomBaseUri ? Fixture.Create<Uri>() : null;

            Handler = new TestHttpHandler(output);
            Sut = baseUri == null
                ? new TeslaAuthClient(new HttpClient(Handler))
                : new TeslaAuthClient(baseUri, new HttpClient(Handler));

            BaseUri = baseUri ?? TeslaClientBase.DefaultBaseUri;
        }

        protected TestHttpHandler Handler { get; private set; }

        protected TeslaAuthClient Sut { get; private set; }

        protected Uri BaseUri { get; private set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Handler?.Dispose();
                Sut?.Dispose();
            }

            Handler = null;
            Sut = null;
            BaseUri = null;

            base.Dispose(disposing);
        }
    }

    public class ClientRequestContext : FixtureContext
    {
        protected ClientRequestContext(ITestOutputHelper output, bool useCustomBaseUri)
            : base(output)
        {
            Uri baseUri = useCustomBaseUri ? Fixture.Create<Uri>() : null;

            Handler = new TestHttpHandler(output);
            Sut = baseUri == null
                ? new TeslaClient(new HttpClient(Handler))
                : new TeslaClient(baseUri, new HttpClient(Handler));

            BaseUri = baseUri ?? TeslaClientBase.DefaultBaseUri;
            AccessToken = Fixture.Create("AccessToken");
            VehicleId = Fixture.Create<long>();
        }

        protected TestHttpHandler Handler { get; private set; }

        protected TeslaClient Sut { get; private set; }

        protected Uri BaseUri { get; private set; }

        protected string AccessToken { get; private set; }

        protected long VehicleId { get; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Handler?.Dispose();
                Sut?.Dispose();
            }

            Handler = null;
            Sut = null;
            BaseUri = null;
            AccessToken = null;

            base.Dispose(disposing);
        }
    }
}
