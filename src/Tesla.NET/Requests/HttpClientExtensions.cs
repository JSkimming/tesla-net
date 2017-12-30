// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Requests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Tesla.NET.Models;

    /// <summary>
    /// Extension methods on <see cref="HttpClient"/> to wrap the Tesla Owner API.
    /// </summary>
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// Requests an access token for access to the Tesla Owner API.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="baseUri">The base <see cref="Uri"/> of the Tesla Owner API.</param>
        /// <param name="clientId">The unique ID of the client.</param>
        /// <param name="clientSecret">The secret for the <paramref name="clientId"/>.</param>
        /// <param name="email">The unique email address of a Tesla Owner.</param>
        /// <param name="password">The password for the <paramref name="email"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The response to the request for an access token.</returns>
        public static Task<MessageResponse<AccessTokenResponse>> RequestAccessTokenAsync(
            this HttpClient client,
            Uri baseUri,
            string clientId,
            string clientSecret,
            string email,
            string password,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));
            if (string.IsNullOrWhiteSpace(clientId))
                throw new ArgumentNullException(nameof(clientId));
            if (string.IsNullOrWhiteSpace(clientSecret))
                throw new ArgumentNullException(nameof(clientSecret));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            Uri requestUri = new Uri(baseUri, "oauth/token");
            IEnumerable<KeyValuePair<string, string>> parameters = GetRequestAccessTokenParameters();

            return
                client
                    .PostFormAsync(requestUri, parameters, cancellationToken)
                    .ReadJsonAsAsync<AccessTokenResponse>(cancellationToken);

            IEnumerable<KeyValuePair<string, string>> GetRequestAccessTokenParameters()
            {
                yield return new KeyValuePair<string, string>("grant_type", "password");
                yield return new KeyValuePair<string, string>("client_id", clientId);
                yield return new KeyValuePair<string, string>("client_secret", clientSecret);
                yield return new KeyValuePair<string, string>("email", email);
                yield return new KeyValuePair<string, string>("password", password);
            }
        }

        /// <summary>
        /// Refreshes an access token for access to the Tesla Owner API.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="baseUri">The base <see cref="Uri"/> of the Tesla Owner API.</param>
        /// <param name="clientId">The unique ID of the client.</param>
        /// <param name="clientSecret">The secret for the <paramref name="clientId"/>.</param>
        /// <param name="refreshToken">A refresh token for a Tesla Owner.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The response to the request for an access token.</returns>
        public static Task<MessageResponse<AccessTokenResponse>> RefreshAccessTokenAsync(
            this HttpClient client,
            Uri baseUri,
            string clientId,
            string clientSecret,
            string refreshToken,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));
            if (string.IsNullOrWhiteSpace(clientId))
                throw new ArgumentNullException(nameof(clientId));
            if (string.IsNullOrWhiteSpace(clientSecret))
                throw new ArgumentNullException(nameof(clientSecret));
            if (string.IsNullOrWhiteSpace(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken));

            Uri requestUri = new Uri(baseUri, "oauth/token");
            IEnumerable<KeyValuePair<string, string>> parameters = GetRefreshAccessTokenParameters();

            return
                client
                    .PostFormAsync(requestUri, parameters, cancellationToken)
                    .ReadJsonAsAsync<AccessTokenResponse>(cancellationToken);

            IEnumerable<KeyValuePair<string, string>> GetRefreshAccessTokenParameters()
            {
                yield return new KeyValuePair<string, string>("grant_type", "refresh_token");
                yield return new KeyValuePair<string, string>("client_id", clientId);
                yield return new KeyValuePair<string, string>("client_secret", clientSecret);
                yield return new KeyValuePair<string, string>("refresh_token", refreshToken);
            }
        }

        /// <summary>
        /// Gets the vehicles associated with an account.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="baseUri">The base <see cref="Uri"/> of the Tesla Owner API.</param>
        /// <param name="accessToken">
        /// The access token used to authenticate the request; can be <see langword="null"/> if the authentication is
        /// added by default.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The vehicles associated with an account.</returns>
        public static Task<MessageResponse<ResponseDataWrapper<IReadOnlyList<Vehicle>>>> GetVehiclesAsync(
            this HttpClient client,
            Uri baseUri,
            string accessToken = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            Uri requestUri = new Uri(baseUri, "api/1/vehicles");

            return
                client
                    .GetWithAuthAsync(requestUri, accessToken, cancellationToken)
                    .ReadJsonAsAsync<ResponseDataWrapper<IReadOnlyList<Vehicle>>>(cancellationToken);
        }

        /// <summary>
        /// Gets the <see cref="DriveState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="baseUri">The base <see cref="Uri"/> of the Tesla Owner API.</param>
        /// <param name="vehicleId">The unique <see cref="Vehicle.Id"/> of a <see cref="Vehicle"/>.</param>
        /// <param name="accessToken">
        /// The access token used to authenticate the request; can be <see langword="null"/> if the authentication is
        /// added by default.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>
        /// The <see cref="DriveState"/> of the <see cref="Vehicle"/> with the specified <see cref="Vehicle.Id"/>.
        /// </returns>
        public static Task<MessageResponse<ResponseDataWrapper<DriveState>>> GetDriveStateAsync(
            this HttpClient client,
            Uri baseUri,
            long vehicleId,
            string accessToken = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            Uri requestUri = new Uri(baseUri, $"api/1/vehicles/{vehicleId}/data_request/drive_state");

            return
                client
                    .GetWithAuthAsync(requestUri, accessToken, cancellationToken)
                    .ReadJsonAsAsync<ResponseDataWrapper<DriveState>>(cancellationToken);
        }

        /// <summary>
        /// Gets the <see cref="VehicleState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="baseUri">The base <see cref="Uri"/> of the Tesla Owner API.</param>
        /// <param name="vehicleId">The unique <see cref="Vehicle.Id"/> of a <see cref="Vehicle"/>.</param>
        /// <param name="accessToken">
        /// The access token used to authenticate the request; can be <see langword="null"/> if the authentication is
        /// added by default.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>
        /// The <see cref="VehicleState"/> of the <see cref="Vehicle"/> with the specified <see cref="Vehicle.Id"/>.
        /// </returns>
        public static Task<MessageResponse<ResponseDataWrapper<VehicleState>>> GetVehicleStateAsync(
            this HttpClient client,
            Uri baseUri,
            long vehicleId,
            string accessToken = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            Uri requestUri = new Uri(baseUri, $"api/1/vehicles/{vehicleId}/data_request/vehicle_state");

            return
                client
                    .GetWithAuthAsync(requestUri, accessToken, cancellationToken)
                    .ReadJsonAsAsync<ResponseDataWrapper<VehicleState>>(cancellationToken);
        }

        /// <summary>
        /// Posts the form <paramref name="parameters"/> to the <paramref name="requestUri"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The request <see cref="Uri"/>.</param>
        /// <param name="parameters">The form parameters to post.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> to the request.</returns>
        private static async Task<HttpResponseMessage> PostFormAsync(
            this HttpClient client,
            Uri requestUri,
            IEnumerable<KeyValuePair<string, string>> parameters,
            CancellationToken cancellationToken)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new FormUrlEncodedContent(parameters),
            };

            using (requestMessage)
            {
                return await client.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sends a <see cref="HttpMethod.Get"/> request to the <paramref name="requestUri"/> authenticated using the
        /// <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The request <see cref="Uri"/>.</param>
        /// <param name="accessToken">
        /// The access token used to authenticate the request; can be <see langword="null"/> if the authentication is
        /// added by default.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> to the request.</returns>
        private static async Task<HttpResponseMessage> GetWithAuthAsync(
            this HttpClient client,
            Uri requestUri,
            string accessToken = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            using (requestMessage)
            {
                return await client.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Reads the JSON from the <paramref name="responseTask"/> and deserializes it to the type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the object to deserialize.</typeparam>
        /// <param name="responseTask">
        /// The asynchronous <see cref="Task{T}"/> of a <see cref="HttpResponseMessage"/>.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The deserialized object of type <typeparamref name="T"/>.</returns>
        private static async Task<MessageResponse<T>> ReadJsonAsAsync<T>(
            this Task<HttpResponseMessage> responseTask,
            CancellationToken cancellationToken)
            where T : class
        {
            if (responseTask == null)
                throw new ArgumentNullException(nameof(responseTask));

            HttpResponseMessage responseMessage = await responseTask.ConfigureAwait(false);
            using (responseMessage)
            {
                responseMessage.EnsureSuccessStatusCode();

                (T data, JObject rawJson) =
                    await responseMessage.ReadJsonAsAsync<T>(cancellationToken).ConfigureAwait(false);
                MessageResponse<T> response = new MessageResponse<T>(responseMessage.StatusCode, rawJson, data);
                return response;
            }
        }

        /// <summary>
        /// Reads the JSON from the <paramref name="response"/> and deserializes it to the type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the object to deserialize.</typeparam>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The deserialized object of type <typeparamref name="T"/>.</returns>
        private static async Task<(T data, JObject rawJson)> ReadJsonAsAsync<T>(
            this HttpResponseMessage response,
            CancellationToken cancellationToken)
            where T : class
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var sr = new StreamReader(stream))
            using (var reader = new JsonTextReader(sr))
            {
                JObject rawJson = await JObject.LoadAsync(reader, cancellationToken).ConfigureAwait(false);

                JsonSerializer serializer = JsonSerializer.CreateDefault();
                T data = rawJson.ToObject<T>(serializer);

                return (data, rawJson);
            }
        }
    }
}
