﻿using SCSS.Application.ScrapDealer.Models.AccountModels;
using SCSS.Utilities.ResponseModel;
using System.Threading.Tasks;

namespace SCSS.Application.ScrapDealer.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Sends the otp to register.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> SendOtpToRegister(SendOTPRequestModel model);

        /// <summary>
        /// Sends the otp restore pass.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> SendOtpRestorePass(SendOTPRequestModel model);

        /// <summary>
        /// Registers the dealer account.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> RegisterDealerAccount(DealerAccountRegisterRequestModel model);

        /// <summary>
        /// Updates the dealer account.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> UpdateDealerAccount(DealerAccountUpdateRequestModel model);

        /// <summary>
        /// Updates the device identifier.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> UpdateDeviceId(DeviceIdUpdateModel model);

        /// <summary>
        /// Gets the dealer account information.
        /// </summary>
        /// <returns></returns>
        Task<BaseApiResponseModel> GetDealerAccountInfo();

        /// <summary>
        /// Gets the dealer leader list.
        /// </summary>
        /// <returns></returns>
        Task<BaseApiResponseModel> GetDealerLeaderList();
    }
}
