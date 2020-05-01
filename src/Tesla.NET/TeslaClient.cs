// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Tesla.NET.Models;
    using Tesla.NET.Requests;

    /// <inheritdoc cref="ITeslaClient" />
    public class TeslaClient : TeslaClientBase, ITeslaClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaClient(params HttpMessageHandler[] handlers)
            : base(handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="TeslaClientBase.BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='handlers'>Optional. The handlers to add to the HTTP client pipeline.</param>
        public TeslaClient(Uri baseUri, params HttpMessageHandler[] handlers)
            : base(baseUri, handlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name='client'>The <see cref="TeslaClientBase.Client"/>.</param>
        public TeslaClient(HttpClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="baseUri">The <see cref="TeslaClientBase.BaseUri"/> of the Tesla Owner API.</param>
        /// <param name='client'>The <see cref="TeslaClientBase.Client"/>.</param>
        public TeslaClient(Uri baseUri, HttpClient client)
            : base(baseUri, client)
        {
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IReadOnlyList<IVehicle>>>> GetVehiclesAsync(
            CancellationToken cancellationToken = default)
        {
            return Client.GetVehiclesAsync(BaseUri, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IReadOnlyList<IVehicle>>>> GetVehiclesAsync(
            string accessToken,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            return Client.GetVehiclesAsync(BaseUri, accessToken, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IChargeState>>> GetChargeStateAsync(
            long vehicleId,
            CancellationToken cancellationToken = default)
        {
            return Client.GetChargeStateAsync(BaseUri, vehicleId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IChargeState>>> GetChargeStateAsync(
            long vehicleId,
            string accessToken,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            return Client.GetChargeStateAsync(BaseUri, vehicleId, accessToken, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IDriveState>>> GetDriveStateAsync(
            long vehicleId,
            CancellationToken cancellationToken = default)
        {
            return Client.GetDriveStateAsync(BaseUri, vehicleId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IDriveState>>> GetDriveStateAsync(
            long vehicleId,
            string accessToken,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            return Client.GetDriveStateAsync(BaseUri, vehicleId, accessToken, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IVehicleState>>> GetVehicleStateAsync(
            long vehicleId,
            CancellationToken cancellationToken = default)
        {
            return Client.GetVehicleStateAsync(BaseUri, vehicleId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IVehicleState>>> GetVehicleStateAsync(
            long vehicleId,
            string accessToken,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            return Client.GetVehicleStateAsync(BaseUri, vehicleId, accessToken, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IClimateState>>> GetClimateStateAsync(long vehicleId, CancellationToken cancellationToken = default)
        {
            return Client.GetClimateStateAsync(BaseUri, vehicleId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<IMessageResponse<IResponseDataWrapper<IClimateState>>> GetClimateStateAsync(long vehicleId, string accessToken, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            return Client.GetClimateStateAsync(BaseUri, vehicleId, accessToken, cancellationToken);
        }
    }
}
