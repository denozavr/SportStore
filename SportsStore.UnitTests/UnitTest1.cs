using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanPaginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"},
                new Product {ProductId = 6, Name = "P6"},
                });

                ProductController prod = new ProductController(mock.Object);
                prod.PageSize = 3;

                //act
                IEnumerable<Product> result = prod.List(2).Model as IEnumerable<Product>;
                
                //assert
                Product[] prodArr = result.ToArray();
                Assert.IsTrue(prodArr.Length==2);
                Assert.AreEqual(prodArr[0].Name,"P4");

        }
    }
}
