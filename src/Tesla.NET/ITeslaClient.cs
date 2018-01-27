// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Tesla.NET.Models;

    /// <summary>
    /// Client for the Tesla Owner API.
    /// </summary>
    public interface ITeslaClient
    {
        /// <summary>
        /// Gets the vehicles associated with an account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The vehicles associated with an account.</returns>
        Task<IMessageResponse<IResponseDataWrapper<IReadOnlyList<IVehicle>>>> GetVehiclesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the vehicles associated with an account.
        /// </summary>
        /// <param name="accessToken">
        /// The access token used to authenticate the request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>The vehicles associated with an account.</returns>
        Task<IMessageResponse<IResponseDataWrapper<IReadOnlyList<IVehicle>>>> GetVehiclesAsync(
            string accessToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the <see cref="ChargeState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
        /// <param name="vehicleId">The unique <see cref="Vehicle.Id"/> of a <see cref="Vehicle"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>
        /// The <see cref="ChargeState"/> of the <see cref="Vehicle"/> with the specified <see cref="Vehicle.Id"/>.
        /// </returns>
        Task<IMessageResponse<IResponseDataWrapper<IChargeState>>> GetChargeStateAsync(
            long vehicleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the <see cref="ChargeState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
        /// <param name="vehicleId">The unique <see cref="Vehicle.Id"/> of a <see cref="Vehicle"/>.</param>
        /// <param name="accessToken">
        /// The access token used to authenticate the request; can be <see langword="null"/> if the authentication is
        /// added by default.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>
        /// The <see cref="ChargeState"/> of the <see cref="Vehicle"/> with the specified <see cref="Vehicle.Id"/>.
        /// </returns>
        Task<IMessageResponse<IResponseDataWrapper<IChargeState>>> GetChargeStateAsync(
            long vehicleId,
            string accessToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the <see cref="DriveState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
        /// <param name="vehicleId">The unique <see cref="Vehicle.Id"/> of a <see cref="Vehicle"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>
        /// The <see cref="DriveState"/> of the <see cref="Vehicle"/> with the specified <see cref="Vehicle.Id"/>.
        /// </returns>
        Task<IMessageResponse<IResponseDataWrapper<IDriveState>>> GetDriveStateAsync(
            long vehicleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the <see cref="DriveState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
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
        Task<IMessageResponse<IResponseDataWrapper<IDriveState>>> GetDriveStateAsync(
            long vehicleId,
            string accessToken,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the <see cref="VehicleState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
        /// <param name="vehicleId">The unique <see cref="Vehicle.Id"/> of a <see cref="Vehicle"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for a task to
        /// complete.</param>
        /// <returns>
        /// The <see cref="VehicleState"/> of the <see cref="Vehicle"/> with the specified <see cref="Vehicle.Id"/>.
        /// </returns>
        Task<IMessageResponse<IResponseDataWrapper<IVehicleState>>> GetVehicleStateAsync(
            long vehicleId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the <see cref="VehicleState"/> of the <see cref="Vehicle"/> with the specified
        /// <see cref="Vehicle.Id"/>.
        /// </summary>
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
        Task<IMessageResponse<IResponseDataWrapper<IVehicleState>>> GetVehicleStateAsync(
            long vehicleId,
            string accessToken,
            CancellationToken cancellationToken = default);
    }
}
