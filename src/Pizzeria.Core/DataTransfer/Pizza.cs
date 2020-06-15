using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.DataTransfer
{
    public class Pizza : Item
    {
        public Pizza()
        {

        }

        public Pizza(Item item, ToppingType type)
           : base(item.ItemId, item.Name, item.Price, item.ImageUrl, item.ItemType)
        {
            Type = type;
        }

        public ToppingType Type { get; set; }
    }
}
