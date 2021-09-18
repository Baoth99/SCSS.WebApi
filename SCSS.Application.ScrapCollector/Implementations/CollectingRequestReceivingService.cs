﻿using Microsoft.EntityFrameworkCore;
using SCSS.Application.ScrapCollector.Models.CollectingRequestModels;
using SCSS.MapService.Models;
using SCSS.Utilities.BaseResponse;
using SCSS.Utilities.Constants;
using SCSS.Utilities.Extensions;
using SCSS.Utilities.Helper;
using SCSS.Utilities.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCSS.Application.ScrapCollector.Implementations
{
    public partial class CollectingRequestService
    {
        #region Get List Of Collecting Request which was received by collector

        /// <summary>
        /// Gets the collecting request received list.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<BaseApiResponseModel> GetCollectingRequestReceivedList(CollectingRequestReceivingFilterModel model)
        {
            var filterDate = model.FilterDate.ToDateTime();

            if (filterDate != null)
            {
                if (filterDate.IsCompareDateTimeLessThan(DateTimeInDay.DATE_NOW))
                {
                    filterDate = DateTimeInDay.DATE_NOW;
                }
            }

            var collectorId = UserAuthSession.UserSession.Id;
            var receivingDataQuery = _collectingRequestRepository.GetMany(x => x.CollectorAccountId.Equals(collectorId) &&
                                                                               x.Status == CollectingRequestStatus.APPROVED &&
                                                                               (ValidatorUtil.IsBlank(filterDate) || x.CollectingRequestDate.Value.Date.CompareTo(filterDate.Value.Date) == NumberConstant.Zero))
                                                                  .Join(_locationRepository.GetAllAsNoTracking(), x => x.LocationId, y => y.Id,
                                                                               (x, y) => new
                                                                               {
                                                                                   CollectingRequestId = x.Id,
                                                                                   x.CollectingRequestCode,
                                                                                   x.CollectingRequestDate,
                                                                                   x.SellerAccountId,
                                                                                   x.TimeFrom,
                                                                                   x.TimeTo,
                                                                                   x.IsBulky,
                                                                                   y.Address,
                                                                                   y.AddressName,
                                                                                   y.Latitude,
                                                                                   y.Longitude,
                                                                               });
            if (!receivingDataQuery.Any())
            {
                return BaseApiResponse.OK(totalRecord: NumberConstant.Zero, resData: CollectionConstants.Empty<CollectingRequestReceivingViewModel>());
            }

            // Get Destination List
            var destinationCoordinateRequest = receivingDataQuery.Select(x => new DestinationCoordinateModel()
            {
                Id = x.CollectingRequestId,
                DestinationLatitude = x.Latitude.Value,
                DestinationLongtitude = x.Longitude.Value
            }).ToList();

            var mapDistanceMatrixCoordinate = new DistanceMatrixCoordinateRequestModel()
            {
                OriginLatitude = model.OriginLatitude.Value,
                OriginLongtitude = model.OriginLongtitude.Value,
                DestinationItems = destinationCoordinateRequest,
                Vehicle = Vehicle.hd
            };

            // Call to Goong Map Service to get distance between collector location and collecting request location
            var destinationDistancesRes = await _mapDistanceMatrixService.GetDistanceFromOriginToMultiDestinations(mapDistanceMatrixCoordinate);

            // Get Seller Role 
            var sellerRoleId = UnitOfWork.RoleRepository.Get(x => x.Key.Equals(AccountRole.SELLER)).Id;

            model.ScreenSize = model.ScreenSize <= NumberConstant.Zero ? NumberConstant.Ten : model.ScreenSize;

            var receivingData = destinationDistancesRes.Take(model.ScreenSize).Join(receivingDataQuery, x => x.DestinationId, y => y.CollectingRequestId,
                                                             (x, y) => new
                                                             {
                                                                 y.CollectingRequestId,
                                                                 y.CollectingRequestCode,
                                                                 y.CollectingRequestDate,
                                                                 y.TimeFrom,
                                                                 y.TimeTo,
                                                                 y.Address,
                                                                 y.AddressName,
                                                                 y.IsBulky,
                                                                 x.DistanceVal,
                                                                 x.DistanceText,
                                                                 y.SellerAccountId
                                                             })
                                                         .Join(_accountRepository.GetManyAsNoTracking(x => x.RoleId.Equals(sellerRoleId)), x => x.SellerAccountId, y => y.Id,
                                                            (x, y) => new
                                                            {
                                                                x.CollectingRequestId,
                                                                x.CollectingRequestCode,
                                                                x.CollectingRequestDate,
                                                                x.TimeFrom,
                                                                x.TimeTo,
                                                                x.Address,
                                                                x.AddressName,
                                                                x.IsBulky,
                                                                x.DistanceVal,
                                                                x.DistanceText,
                                                                SellerName = y.Name,
                                                            }).OrderBy(x => x.DistanceVal);

            var totalRecord = receivingData.Count();

            var dataResult = receivingData.Select(x => new CollectingRequestReceivingViewModel()
            {
                Id = x.CollectingRequestId,
                CollectingRequestCode = x.CollectingRequestCode,
                SellerName = x.SellerName,
                // Date
                DayOfWeek = x.CollectingRequestDate.GetDayOfWeek(),
                CollectingRequestDate = x.CollectingRequestDate.ToStringFormat(DateTimeFormat.DD_MM_yyyy),
                FromTime = x.TimeFrom.ToStringFormat(TimeSpanFormat.HH_MM),
                ToTime = x.TimeTo.ToStringFormat(TimeSpanFormat.HH_MM),
                // Location
                CollectingAddressName = x.AddressName,
                CollectingAddress = x.Address,
                IsBulky = x.IsBulky,
                Distance = x.DistanceVal,
                DistanceText = x.DistanceText,
            }).ToList();

            return BaseApiResponse.OK(totalRecord: totalRecord, resData: dataResult); ;
        }

        #endregion Get List Of Collecting Request which have received

        #region Get Collecting Request Detail which was received by collector

        /// <summary>
        /// Gets the collecting request detail received.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<BaseApiResponseModel> GetCollectingRequestDetailReceived(Guid id)
        {
            var collectingRequestEntity = await _collectingRequestRepository.GetAsyncAsNoTracking(x => x.Id.Equals(id) &&
                                                                                                       x.CollectorAccountId.Equals(UserAuthSession.UserSession.Id) &&
                                                                                                       x.Status == CollectingRequestStatus.APPROVED);
            if (collectingRequestEntity == null)
            {
                return BaseApiResponse.NotFound();
            }

            var locationEntity = _locationRepository.GetAsNoTracking(x => x.Id.Equals(collectingRequestEntity.LocationId));
            var sellerInfo = _accountRepository.GetAsNoTracking(x => x.Id.Equals(collectingRequestEntity.SellerAccountId));

            var dataResult = new CollectingRequestDetailReceivingViewModel()
            {
                Id = collectingRequestEntity.Id,
                CollectingRequestCode = collectingRequestEntity.CollectingRequestCode,
                CollectingRequestDate = collectingRequestEntity.CollectingRequestDate.ToStringFormat(DateTimeFormat.DD_MM_yyyy),
                DayOfWeek = collectingRequestEntity.CollectingRequestDate.GetDayOfWeek(),
                FromTime = collectingRequestEntity.TimeFrom.ToStringFormat(TimeSpanFormat.HH_MM),
                ToTime = collectingRequestEntity.TimeTo.ToStringFormat(TimeSpanFormat.HH_MM),
                IsBulky = collectingRequestEntity.IsBulky,
                Note = collectingRequestEntity.Note,
                ScrapImgUrl = collectingRequestEntity.ScrapImageUrl,
                // Location
                CollectingAddressName = locationEntity.AddressName,
                CollectingAddress = locationEntity.AddressName,
                Latitude = locationEntity.Latitude,
                Longtitude = locationEntity.Longitude,
                // Seller Information
                SellerName = sellerInfo.Name,
                SellerImgUrl = sellerInfo.ImageUrl,
                SellerPhone = sellerInfo.Phone
            };

            return BaseApiResponse.OK(dataResult);
        }

        #endregion Get Collecting Request Detail which was received by collector

        #region Cancel Collecting Request By Collector

        /// <summary>
        /// Cancels the collecting request received.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<BaseApiResponseModel> CancelCollectingRequestReceived(CollectingRequestReceivedCancelModel model)
        {
            var collectingRequestEntity = await _collectingRequestRepository.GetAsyncAsNoTracking(x => x.Id.Equals(model.Id) &&
                                                                                                       x.CollectorAccountId.Equals(UserAuthSession.UserSession.Id) &&
                                                                                                       x.Status == CollectingRequestStatus.APPROVED);

            if (collectingRequestEntity == null)
            {
                return BaseApiResponse.NotFound();
            }

            collectingRequestEntity.Status = CollectingRequestStatus.CANCEL_BY_COLLECTOR;
            collectingRequestEntity.CancelReason = model.CancelReason;

            try
            {
                _collectingRequestRepository.Update(collectingRequestEntity);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                return BaseApiResponse.Error(SystemMessageCode.SystemException);
            }
           
            // Push Notification to notice seller that their collecting request was canceled by collector
            var sellerId = collectingRequestEntity.SellerAccountId;
            
            string title = NotificationMessage.CollectingRequestCancelTitle(collectingRequestEntity.CollectingRequestCode);
            // TODO:
            string body = NotificationMessage.CollectingRequestCancelBody(model.CancelReason);
            await SendAndSaveNotification(sellerId, title, body);

            return BaseApiResponse.OK();
        }

        #endregion Cancel Collecting Request By Collector
    }
}