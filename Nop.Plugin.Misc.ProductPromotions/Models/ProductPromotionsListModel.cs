using Nop.Web.Framework.Models;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.ProductPromotions.Models
{
    public partial class ProductPromotionsListModel
    {
        public List<ProductPromotionsModel> Promotions { get; set; }
        public ProductPromotionsListModel()
        {
            Promotions = new List<ProductPromotionsModel>();
        }
    }
    
}