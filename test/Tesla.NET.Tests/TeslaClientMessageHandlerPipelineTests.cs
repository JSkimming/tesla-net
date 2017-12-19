// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using AutoFixture;
    using FluentAssertions;
    using Xunit;

    public class When_creating_the_message_handler_pipeline_using_only_delegates
    {
        private readonly IReadOnlyCollection<DelegatingHandler> _handlers;

        public When_creating_the_message_handler_pipeline_using_only_delegates()
        {
            IFixture fixture = new Fixture().Customize(new TeslaNetCustomization());

            _handlers = fixture.Create<DelegatingHandler[]>();
        }

        [Fact]
        public void Should_start_the_chain_with_the_first_handler()
        {
            // Act
            HttpMessageHandler result = TeslaClient.CreatePipeline(_handlers);

            // Assert
            result.Should().BeSameAs(_handlers.First());
        }

        [Fact]
        public void Should_create_a_chain_of_delegates()
        {
            // Act
            HttpMessageHandler result = TeslaClient.CreatePipeline(_handlers);

            // Assert
            HttpMessageHandler current = result;
            foreach (DelegatingHandler handler in _handlers)
            {
                current.Should().BeSameAs(handler);
                current = handler.InnerHandler;
            }
        }

        [Fact]
        public void Should_end_the_chain_with_a_HttpClientHandler()
        {
            // Act
            HttpMessageHandler result = TeslaClient.CreatePipeline(_handlers);

            // Assert
            HttpMessageHandler current = result;
            DelegatingHandler @delegate;
            while ((@delegate = current as DelegatingHandler) != null)
            {
                current = @delegate.InnerHandler;
            }

            current.Should().BeOfType<HttpClientHandler>();
        }
    }

    public class When_creating_the_message_handler_pipeline_with_a_HttpClientHandler_at_the_end
    {
        private readonly List<HttpMessageHandler> _handlers;
        private readonly HttpClientHandler _last;

        public When_creating_the_message_handler_pipeline_with_a_HttpClientHandler_at_the_end()
        {
            IFixture fixture = new Fixture().Customize(new TeslaNetCustomization());
            _last = new HttpClientHandler();
            _handlers = fixture.Create<DelegatingHandler[]>().ToList<HttpMessageHandler>();
            _handlers.Add(_last);
        }

        [Fact]
        public void Should_start_the_chain_with_the_first_handler()
        {
            // Act
            HttpMessageHandler result = TeslaClient.CreatePipeline(_handlers);

            // Assert
            result.Should().BeSameAs(_handlers.First());
        }

        [Fact]
        public void Should_create_a_chain_of_delegates()
        {
            // Act
            HttpMessageHandler result = TeslaClient.CreatePipeline(_handlers);

            // Assert
            HttpMessageHandler current = result;
            foreach (DelegatingHandler handler in _handlers.OfType<DelegatingHandler>())
            {
                current.Should().BeSameAs(handler);
                current = handler.InnerHandler;
            }
        }

        [Fact]
        public void Should_end_the_chain_with_the_last_HttpClientHandler()
        {
            // Act
            HttpMessageHandler result = TeslaClient.CreatePipeline(_handlers);

            // Assert
            HttpMessageHandler current = result;
            DelegatingHandler @delegate;
            while ((@delegate = current as DelegatingHandler) != null)
            {
                current = @delegate.InnerHandler;
            }

            current.Should().BeSameAs(_last);
        }
    }

    public class When_creating_a_pipeline_with_a_HttpClientHandler_at_the_front
    {
        private readonly List<HttpMessageHandler> _handlers;

        public When_creating_a_pipeline_with_a_HttpClientHandler_at_the_front()
        {
            IFixture fixture = new Fixture().Customize(new TeslaNetCustomization());
            _handlers = fixture.Create<DelegatingHandler[]>().ToList<HttpMessageHandler>();
            _handlers.Insert(0, new HttpClientHandler());
        }

        [Fact]
        public void Should_throw_an_ArgumentException()
        {
            // Act
            Action action = () => TeslaClient.CreatePipeline(_handlers);

            // Assert
            action.ShouldThrowExactly<ArgumentException>();
        }
    }

    public class When_initialising_a_TeslaClient_with_no_parameters
    {
        private readonly TeslaClient _sut;

        public When_initialising_a_TeslaClient_with_no_parameters()
        {
            _sut = new TeslaClient();
        }

        [Fact]
        public void Should_create_an_HttpClient()
        {
            _sut.Client.Should().NotBeNull();
        }

        [Fact]
        public void Should_use_the_default_Base_Uri()
        {
            _sut.BaseUri.Should().BeSameAs(TeslaClient.DefaultBaseUri);
        }
    }
}
