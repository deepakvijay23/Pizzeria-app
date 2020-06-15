using Pizzeria.Core.Utils;
using System;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.DataTransfer
{
    /// <summary>
    /// Base class of all the items
    /// </summary>
    public class Item
    {
        public Item()
        {

        }

        public Item(Guid itemId, string name, float price, string imageUrl, ItemType itemType)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            ItemType = itemType;
        }

        public Guid ItemId { get; set; }

        public string Name { get; set; }
        
        public virtual float Price { get; set; }

        public string ImageUrl { get; set; } = CoreConstants.DefaultImageUrl;

        public ItemType ItemType { get; set; }
    }
}
