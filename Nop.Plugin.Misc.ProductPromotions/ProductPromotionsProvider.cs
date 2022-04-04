using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Shipping;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.ProductPromotions
{
    public class ProductPromotionsProvider : BasePlugin, IMiscPlugin, IWidgetPlugin
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        #endregion

        #region Ctor
        public ProductPromotionsProvider(ILocalizationService localizationService,
            IWebHelper webHelper,
            ISettingService settingService,
            IProductService productService,
            IDiscountService discountService)
        {
            _localizationService = localizationService;
            _webHelper = webHelper;
            _settingService = settingService;
            _productService = productService;
            _discountService = discountService;
        }
        #endregion

        #region Methods

        public override void Install()
        {
            base.Install();
        }
        public override void Uninstall()
        {
            base.Uninstall();
        }
       
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsAddInfo };
        }
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "ProductPromotions";
        }
        public bool HideInWidgetList => false;



        #endregion
    }
}
