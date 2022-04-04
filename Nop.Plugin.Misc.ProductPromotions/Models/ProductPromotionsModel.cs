using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nop.Plugin.Misc.ProductPromotions.Models
{
    public class ProductPromotionsModel : BaseNopModel
    {
        public ProductPromotionsModel()
        {
            Errors = new List<string>();
        }

        #region Properties

        public IList<string> Errors { get; set; }

        public bool Success => !Errors.Any();

        public string Name { get; set; }

        public string AdminComment { get; set; }

        public int DiscountTypeId { get; set; }

        public string DiscountTypeName { get; set; }

        public int TimesUsed { get; set; }

        public bool UsePercentage { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal? MaximumDiscountAmount { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }

        public DateTime? StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public bool RequiresCouponCode { get; set; }

        public string DiscountUrl { get; set; }

        public string CouponCode { get; set; }

        public bool IsCumulative { get; set; }

        public int DiscountLimitationId { get; set; }

        public int LimitationTimes { get; set; }

        public int? MaximumDiscountedQuantity { get; set; }

        public bool AppliedToSubCategories { get; set; }

        public string AddDiscountRequirement { get; set; }

        

        

        #endregion
    }
}