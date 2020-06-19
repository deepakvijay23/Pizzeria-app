using Moq;
using NUnit.Framework;
using Pizzeria.Core;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Service;
using Pizzeria.Core.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Test
{
    public class ToppingServiceTest : BaseUnitTest
    {
        private ITopping toppingService;
        private Mock<ITempDataStore> mockDataStore;
 
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            mockDataStore = new Mock<ITempDataStore>();
            toppingService = new ToppingService(mockDataStore.Object);
        }

        [Test]
        public async Task GetAllToppings_Returns_Ok()
        {
            Guid itemId = Guid.NewGuid();
            var toppingData = new Topping() { ItemId = itemId, Name = "Onion", Price = 12, ItemType = ItemType.Topping };
            var toppingList = new List<Topping> { toppingData };

            mockDataStore.Setup(x => x.GetAllTypeToppings()).ReturnsAsync(toppingList);
            
            var result = await toppingService.GetAllTypeToppings();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            var topping = result.FirstOrDefault();
            Assert.AreEqual(itemId, topping.ItemId);
        }
    }
}
