// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.HttpHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit.Abstractions;

    public class TestHttpHandler : HttpMessageHandler
    {
        private readonly ITestOutputHelper _output;

        private int _responseIndex;

        public TestHttpHandler(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public HttpRequestMessage Request
        {
            get => Requests.Count == 0 ? null : Requests[Requests.Count - 1];
            set
            {
                Requests.Clear();
                Requests.Add(value);
            }
        }

        public List<HttpRequestMessage> Requests { get; } = new List<HttpRequestMessage>(1);

        public List<HttpResponseMessage> Responses { get; } = new List<HttpResponseMessage>(1);

        public List<string> RequestContents { get; } = new List<string>(1);

        public HttpResponseMessage Response
        {
            get => Responses.Count == 0 ? null : Responses[Responses.Count - 1];
            set
            {
                _responseIndex = 0;
                Responses.Clear();
                Responses.Add(value);
            }
        }

        public Func<HttpRequestMessage, Task<HttpRequestMessage>> OnSendingRequest { get; set; }

        public void SetResponse(HttpStatusCode code) => SetResponseContent(null, code);

        public void SetResponseContent(object content, HttpStatusCode code = HttpStatusCode.OK)
        {
            Response = CreateResponse(content, code);
        }

        public void AddResponseContent(object content, HttpStatusCode code = HttpStatusCode.OK)
        {
            Responses.Add(CreateResponse(content, code));
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string requestContent = await GetStringContent(request.Content).ConfigureAwait(false);
            RequestContents.Add(requestContent);

            _output.WriteLine($"Started {request.Method} '{request.RequestUri}'");
            if (requestContent != null)
            {
                _output.WriteLine(requestContent);
            }

            if (OnSendingRequest != null)
            {
                Requests.Add(await OnSendingRequest(request).ConfigureAwait(false));
            }
            else
            {
                Requests.Add(request);
            }

            // Ensure the task continues asynchronously.
            await Task.Yield();

            HttpResponseMessage responseMessage =
                _responseIndex < Responses.Count
                    ? Responses[_responseIndex++]
                    : CreateResponse(string.Empty);

            responseMessage.RequestMessage = request;

            _output.WriteLine(
                $"Completed {request.Method} '{request.RequestUri}' " +
                $"with {responseMessage.StatusCode:G} ({responseMessage.StatusCode:D})");

            string responseContent = await GetStringContent(responseMessage.Content).ConfigureAwait(false);
            if (responseContent != null)
            {
                _output.WriteLine(responseContent);
            }

            return responseMessage;
        }

        private static async Task<string> GetStringContent(HttpContent content)
        {
            if (content == null)
                return null;

            string contentData;
            if (content is ForcedAsyncStreamContent delayedContent)
            {
                using (var s = new StreamReader(delayedContent.Stream, Encoding.UTF8, true, 10240, leaveOpen:true))
                {
                    contentData = s.ReadToEnd();
                }

                delayedContent.Stream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                contentData = await content.ReadAsStringAsync().ConfigureAwait(false);
            }

            bool? isJson = content.Headers?.ContentType?.ToString().Equals("application/json");
            if (isJson.GetValueOrDefault())
            {
                contentData = JToken.Parse(contentData).ToString(Formatting.Indented);
            }

            return contentData;
        }

        private static HttpResponseMessage CreateResponse(object content, HttpStatusCode code = HttpStatusCode.OK)
        {
            if (content == null)
            {
                return new HttpResponseMessage(code);
            }

            var stream = new MemoryStream(10240);
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 10240, leaveOpen: true))
            {
                JToken jsonContent = content as JToken ?? JObject.FromObject(content);
                string json = jsonContent.ToString(Formatting.None);

                streamWriter.Write(json);
                streamWriter.Close();
            }

            stream.Seek(0, SeekOrigin.Begin);
            var httpContent = new ForcedAsyncStreamContent(stream)
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json"),
                }
            };

            return new HttpResponseMessage(code)
            {
                Content = httpContent,
            };
        }
    }
}
