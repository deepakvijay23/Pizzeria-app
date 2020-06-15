using System.Collections.Generic;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.DataTransfer
{
    public class Crust : Item
    {
        public Crust()
        {

        }

        public Crust(Item item, List<CrustSize> availableSizes)
            : base(item.ItemId, item.Name, item.Price, item.ImageUrl, item.ItemType)
        {
            AvailableSizes = availableSizes;
        }

        public List<CrustSize> AvailableSizes { get; set; }
    }

    public class CrustSize
    {
        // Regular, Medium, Large
        public CrustSizeType CrustSizeType { get; set; }

        // Price of crust will vary based on the size.
        public float SizeToPriceRatio { get; set; }
    }
}
