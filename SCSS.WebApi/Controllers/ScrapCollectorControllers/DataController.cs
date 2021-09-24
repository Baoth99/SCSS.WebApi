﻿using Microsoft.AspNetCore.Mvc;
using SCSS.AWSService.Interfaces;
using SCSS.Utilities.BaseResponse;
using SCSS.Utilities.Constants;
using SCSS.Utilities.Extensions;
using SCSS.Utilities.ResponseModel;
using SCSS.WebApi.AuthenticationFilter;
using SCSS.WebApi.SystemConstants;
using System.Threading.Tasks;

namespace SCSS.WebApi.Controllers.ScrapCollectorControllers
{
    [ApiVersion(ApiVersions.ApiVersionV4)]
    public class DataController : BaseScrapCollectorController
    {
        #region Services

        /// <summary>
        /// The storage BLOB s3 service
        /// </summary>
        private readonly IStorageBlobS3Service _storageBlobS3Service;

        #endregion

        #region Constructor

        public DataController(IStorageBlobS3Service storageBlobS3Service)
        {
            _storageBlobS3Service = storageBlobS3Service;
        }


        #endregion

        #region Get Image

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BaseApiResponseModel), HttpStatusCodes.Ok)]
        [ProducesResponseType(typeof(BaseApiResponseModel), HttpStatusCodes.Forbidden)]
        [ProducesResponseType(typeof(ErrorResponseModel), HttpStatusCodes.Unauthorized)]
        [Route(ScrapCollectorApiUrlDefinition.DataApiUrl.GetImage)]
        [ServiceFilter(typeof(ApiAuthenticateFilterAttribute))]
        public async Task<BaseApiResponseModel> GetImage([FromQuery] string imageUrl)
        {
            var file = await _storageBlobS3Service.GetFile(imageUrl);
            if (file == null)
            {
                return BaseApiResponse.NotFound();
            }
            var image = file.Stream.ToBitmap();
            return BaseApiResponse.OK(image);
        }

        #endregion

    }
}
