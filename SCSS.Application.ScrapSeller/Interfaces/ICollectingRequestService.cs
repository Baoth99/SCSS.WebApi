﻿using SCSS.Application.ScrapSeller.Models.CollectingRequestModels;
using SCSS.Utilities.ResponseModel;
using System.Threading.Tasks;

namespace SCSS.Application.ScrapSeller.Interfaces
{
    public interface ICollectingRequestService
    {
        /// <summary>
        /// Gets the operating time range.
        /// </summary>
        /// <returns></returns>
        Task<BaseApiResponseModel> GetOperatingTimeRange();

        /// <summary>
        /// Requests the scrap collecting.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> RequestScrapCollecting(CollectingRequestCreateModel model);

        /// <summary>
        /// Cancels the collecting request.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<CollectingRequestResponseModel> CancelCollectingRequest(CollectingRequestCancelModel model);

        /// <summary>
        /// Gets the number of remaining days.
        /// </summary>
        /// <returns></returns>
        Task<BaseApiResponseModel> GetRemainingDays();

        /// <summary>
        /// Checks the seller request ability.
        /// </summary>
        /// <returns></returns>
        Task<BaseApiResponseModel> CheckSellerRequestAbility();
    }
}
