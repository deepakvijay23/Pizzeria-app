using Moq;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Managers;
using Pizzeria.Core.Service;

namespace Pizzeria.Test
{
    public abstract class BaseUnitTest
    {
        public Mock<IItemManager<Item>> MockItemManager { get; }

        public Mock<IItemManager<Topping>> MockToppingManager { get; }

        public Mock<IItemManager<Pizza>> MockPizzaManager { get; }

        public Mock<IItemManager<Crust>> MockCrustManager { get; }

        public Mock<IItemService<Item>> MockItemService { get; }

        public Mock<ITopping> MockToppingService { get; }

        public BaseUnitTest()
        {
            MockItemManager = new Mock<IItemManager<Item>>();
            MockToppingManager = new Mock<IItemManager<Topping>>();
            MockPizzaManager = new Mock<IItemManager<Pizza>>();
            MockCrustManager = new Mock<IItemManager<Crust>>();
            MockItemService = new Mock<IItemService<Item>>();
            MockToppingService = new Mock<ITopping>();
        }
    }
}
