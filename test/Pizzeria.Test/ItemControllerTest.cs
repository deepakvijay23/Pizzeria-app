using Moq;
using NUnit.Framework;
using Pizzeria.API.Controllers;
using Pizzeria.Core.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pizzeria.Core;
using System.Threading.Tasks;
using System;
using System.Linq;
using static Pizzeria.Core.Utils.CoreEnums;
using System.Net;

namespace Pizzeria.Test
{
    [TestFixture]
    [Category("TestSuite.Unit")]
    public class ItemControllerTest : BaseUnitTest
    {
        ItemsController itemsController;
        private const string TOPPING = "Topping";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            itemsController = new ItemsController(MockItemManager.Object, MockToppingManager.Object,
                MockPizzaManager.Object, MockCrustManager.Object);
        }

        [Test]
        public async Task GetToppings_Returns_Ok()
        {
            Guid itemId = Guid.NewGuid();
            var toppingData = new Topping() { ItemId = itemId, Name = "Onion", Price = 12, ItemType = ItemType.Topping };
            var toppingList = new List<Topping> { toppingData };
            
            MockToppingManager.Setup(x => x.GetAllAsync(ItemType.Topping)).ReturnsAsync(new ApiResponse<List<Topping>>
            {
                Result = new ApiResult<List<Topping>> { Data = toppingList }
            });

            var result = await itemsController.GetByType(TOPPING) as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

            ApiResponse<List<Topping>> getAllToppings = result.Value as ApiResponse<List<Topping>>;
            Assert.IsNotNull(getAllToppings.Result.Data);
            Assert.IsNull(getAllToppings.Result.ErrorInfo);

            List<Topping> toppings = getAllToppings.Result.Data;
            var topping = toppings.FirstOrDefault();
            Assert.AreEqual(toppingData.ItemId, topping.ItemId);
            Assert.AreEqual(toppingData.Name, topping.Name);
            Assert.AreEqual(toppingData.Price, topping.Price);
            Assert.AreEqual(toppingData.ItemType, topping.ItemType);
        }
    }
}