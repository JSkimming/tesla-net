// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using AutoFixture;
    using Tesla.NET.HttpHandlers;

    public abstract class FixtureContext : IDisposable
    {
        protected FixtureContext()
        {
            Fixture = new Fixture().Customize(new TeslaNetCustomization());
        }

        ~FixtureContext()
        {
            Dispose(false);
        }

        protected IFixture Fixture { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            Fixture = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class AuthRequestContext : FixtureContext
    {
        protected AuthRequestContext(bool useCustomBaseUri)
        {
            Uri baseUri = useCustomBaseUri ? Fixture.Create<Uri>() : null;

            Handler = new TestHttpHandler();
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
        }
    }
}
