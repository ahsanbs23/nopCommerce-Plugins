using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.ProductPromotions.Models;
using Nop.Plugin.Misc.ProductPromotions.Services;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;
using static Nop.Web.Models.Catalog.ProductDetailsModel;

namespace Nop.Plugin.Misc.ProductPromotions.Components
{
    [ViewComponent(Name = "ProductPromotions")]
    public class ProductPromotionsViewComponent : NopViewComponent
    {
        private readonly IProductPromotionsService _productPromotionsService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        public ProductPromotionsViewComponent(IProductPromotionsService productPromotionsService,
            ICustomerService customerService,
            IWorkContext workContext)
        {
            _productPromotionsService = productPromotionsService;
            _customerService = customerService;
            _workContext = workContext;
        }
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var customer = _workContext.CurrentCustomer;
                 
            AddToCartModel addToCartModel = (AddToCartModel)additionalData;
            
            if(addToCartModel == null || addToCartModel.ProductId==0 )
            {
                return View("~/Plugins/Misc.ProductPromotions/Views/Default.cshtml", new ProductPromotionsListModel
                {
                    Promotions =  { new ProductPromotionsModel { Errors = {"No promotion is applicable" } } }
                });
            }
            var model = _productPromotionsService.GetProductPromotions(customer,addToCartModel.ProductId);

            if(model == null)
            {
                return View("~/Plugins/Misc.ProductPromotions/Views/Default.cshtml", new ProductPromotionsListModel
                {
                    Promotions =  { new ProductPromotionsModel { Errors = { "No promotion is applicable" } } }
                });
            }

            return View("~/Plugins/Misc.ProductPromotions/Views/Default.cshtml", model);
        }
        
    }
}
