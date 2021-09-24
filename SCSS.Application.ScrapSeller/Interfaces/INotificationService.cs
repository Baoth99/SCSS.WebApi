﻿using SCSS.Utilities.ResponseModel;
using System;
using System.Threading.Tasks;

namespace SCSS.Application.ScrapSeller.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns></returns>
        Task<BaseApiResponseModel> GetNotifications();

        Task<BaseApiResponseModel> GetNotificationDetail(Guid id);

        /// <summary>
        /// Reads the notification.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<BaseApiResponseModel> ReadNotification(Guid id);
    }
}
