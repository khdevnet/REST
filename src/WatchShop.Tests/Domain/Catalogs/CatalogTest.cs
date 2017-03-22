using Moq;
using NUnit.Framework;
using System;
using WatchShop.Domain.Catalogs;
using WatchShop.Domain.Catalogs.Extensibility;
using WatchShop.Domain.Catalogs.Extensibility.Entities;
using WatchShop.Domain.Common.Exceptions;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Tests.Domain.Catalogs
{
    [TestFixture]
    internal class CatalogTest : UnitTestBase
    {
        private const string CategoryName = Component.Name + nameof(Catalog);
        private const string RemoveProductMethodName = nameof(Catalog.RemoveProduct) + ". ";

        private const int ProductId = 123;

        private Catalog catalog;
        private Mock<IShopDataContext> shopDataContextMock;
        private Mock<IProductRepository> productRepositoryMock;

        [OneTimeSetUp]
        public void Initialize()
        {
            productRepositoryMock = MockRepository.Create<IProductRepository>();
            shopDataContextMock = MockRepository.Create<IShopDataContext>();
            catalog = new Catalog(shopDataContextMock.Object);
        }

        [Category(CategoryName)]
        [TestCase(TestName = RemoveProductMethodName + "Product removed successful")]
        public void RemoveProductTest()
        {
            productRepositoryMock.Setup(rep => rep.IsExist(ProductId)).Returns(true);
            productRepositoryMock.Setup(rep => rep.Remove(ProductId));
            shopDataContextMock
                .SetupGet(context => context.Products)
                .Returns(productRepositoryMock.Object);
            shopDataContextMock
                .Setup(context => context.SaveChanges())
                .Returns(ProductId);

            catalog.RemoveProduct(ProductId);
        }

        [Category(CategoryName)]
        [TestCase(TestName = RemoveProductMethodName + "Product Not Found Exception")]
        public void RemoveProductProductNotFoundExceptionTest()
        {
            productRepositoryMock.Setup(rep => rep.IsExist(ProductId)).Returns(false);
            shopDataContextMock
                .SetupGet(context => context.Products)
                .Returns(productRepositoryMock.Object);
            Assert.That(() => catalog.RemoveProduct(ProductId), Throws.Exception.TypeOf<NotFoundException>().With.Property("Message").EqualTo($"{nameof(Product)} with id {ProductId} not found!"));
        }
    }
}