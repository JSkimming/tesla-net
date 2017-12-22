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
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class TestHttpHandler : HttpMessageHandler
    {
        private int _responseIndex;

        public TestHttpHandler()
        {
            Requests = new List<HttpRequestMessage>(1);
            Responses = new List<HttpResponseMessage>(1);
            RequestContents = new List<string>(1);
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

        public List<HttpRequestMessage> Requests { get; }
        public List<string> RequestContents { get; }

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

        public List<HttpResponseMessage> Responses { get; set; }

        public Func<HttpRequestMessage, Task<HttpRequestMessage>> OnSendingRequest { get; set; }

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
            string content = request.Content == null
                ? null
                : await request.Content.ReadAsStringAsync().ConfigureAwait(false);
            RequestContents.Add(content);

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

            if (_responseIndex < Responses.Count)
            {
                return Responses[_responseIndex++];
            }

            return CreateResponse(string.Empty);
        }

        private static HttpResponseMessage CreateResponse(object content, HttpStatusCode code = HttpStatusCode.OK)
        {
            var stream = new MemoryStream(10240);
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 10240, leaveOpen: true))
            {
                JToken jsonContent = content as JToken ?? JObject.FromObject(content);
                string json = jsonContent.ToString(Formatting.None);

                streamWriter.Write(json);
                streamWriter.Close();
            }

            stream.Seek(0, SeekOrigin.Begin);
            return new HttpResponseMessage(code)
            {
                Content = new DelayedStreamContent(stream),
            };
        }
    }
}
