﻿using SCSS.Aplication.BackgroundService.Interfaces;
using SCSS.Data.EF.Repositories;
using SCSS.Data.EF.UnitOfWork;
using SCSS.Data.Entities;
using SCSS.Utilities.Constants;
using SCSS.Utilities.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace SCSS.Aplication.BackgroundService.Implementations
{
    public class PromotionService : BaseService, IPromotionService
    {
        #region Repositories

        /// <summary>
        /// The promotion repository/
        /// </summary>
        private readonly IRepository<Promotion> _promotionRepository;

        #endregion

        public PromotionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _promotionRepository = unitOfWork.PromotionRepository;
        }


        #region Scan Expired Promotion

        /// <summary>
        /// Scans the expired promotion.
        /// </summary>
        public async Task ScanExpiredPromotion()
        {
            var dataQuery = _promotionRepository.GetManyAsNoTracking(x => x.ToTime.Value.CompareTo(DateTimeVN.DATE_NOW) == NumberConstant.Zero).ToList();

            var updateEntities = dataQuery.Select(x =>
            {
                x.Status = PromotionStatus.DEACTIVE;
                return x;
            }).ToList();

            if (updateEntities.Any())
            {
                _promotionRepository.UpdateRange(updateEntities);
            }

            await UnitOfWork.CommitAsync();
        }

        #endregion
    }
}
