using System.Linq;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using Nop.Data;
using Nop.Plugin.Misc.ProductPromotions.Models;
using Nop.Services.Catalog;
using Nop.Services.Discounts;

namespace Nop.Plugin.Misc.ProductPromotions.Services
{
    public partial class ProductPromotionsService : IProductPromotionsService
    {
        #region Fields

        private readonly IDiscountService _discountService;
        private readonly IProductService _productService;
        private readonly IRepository<DiscountProductMapping> _dpmRepository;

        #endregion

        #region Ctor

        public ProductPromotionsService(IDiscountService discountService,
            IProductService productService,
            IRepository<DiscountProductMapping> dpmRepository)
        {
            _discountService = discountService;
            _productService = productService;
            _dpmRepository = dpmRepository;
        }

        #endregion

        #region Methods

        public ProductPromotionsListModel GetProductPromotions(Customer customer,int productId)
        {
            if (productId==0)
                return null;
            var product = _productService.GetProductById(productId);

            var discountIds = (from rep in _dpmRepository.Table
                           where rep.EntityId == productId
                           select rep.DiscountId).ToList();

            if (!discountIds.Any())
                return null;

            var promotions = new ProductPromotionsListModel();

            foreach (var discountId in discountIds)
            {
                var discount = _discountService.GetDiscountById(discountId);

                var result = _discountService.ValidateDiscount(discount , customer);

                if (!result.IsValid)
                    return null;

                var model = new ProductPromotionsModel();
                
                model.Name = discount.Name;
                model.UsePercentage = discount.UsePercentage;
                model.DiscountPercentage = discount.DiscountPercentage;
                model.DiscountAmount = discount.DiscountAmount;
                
                if (discount.UsePercentage)
                    model.DiscountAmount = (model.DiscountPercentage/100) * product.Price;
                    
                model.RequiresCouponCode = discount.RequiresCouponCode;
                model.CouponCode = discount.CouponCode;
                model.AdminComment = discount.AdminComment;
                model.MaximumDiscountAmount = discount.MaximumDiscountAmount;
                model.MaximumDiscountedQuantity = discount.MaximumDiscountedQuantity;
                
                promotions.Promotions.Add(model);

            }
            return promotions;
        }

        #endregion
    }
}
