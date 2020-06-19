using Moq;
using NUnit.Framework;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Managers;
using Pizzeria.Core.Managers.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Test
{
    [TestFixture]
    [Category("TestSuite.Unit")]
    public class ToppingManangerTest: BaseUnitTest
    {
        IItemManager<Topping> toppingManager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            toppingManager = new ToppingManager(MockItemService.Object, MockToppingService.Object);
        }

        [Test]
        public async Task GetAllToppings_Returns_Ok()
        {
            Guid itemId = Guid.NewGuid();
            var toppingData = new Topping() { ItemId = itemId, Name = "Onion", Price = 12, ItemType = ItemType.Topping };
            var toppingList = new List<Topping> { toppingData };

            MockToppingService.Setup(x => x.GetAllTypeToppings()).ReturnsAsync(toppingList);
            var result = await toppingManager.GetAllAsync(ItemType.Topping);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Result);
            Assert.IsNotNull(result.Result.Data);
            Assert.IsNull(result.Result.ErrorInfo);
            var topping = result.Result.Data.FirstOrDefault();
            Assert.AreEqual(itemId, topping.ItemId);
        }
    }
}
