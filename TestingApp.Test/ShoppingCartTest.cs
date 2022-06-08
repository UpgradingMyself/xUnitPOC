using System;
using TestingApp.Functionality;
using Xunit;
using Moq;

namespace TestingApp.Test
{
    // public class DbServiceMock : IDbService
    // {
    //     public bool ProcessResult { get; set; }
    //     public Product ProductBeingProcessed { get; set; }
    //     public int ProductIdBeingProcessed { get; set; }

    //     public bool RemoveItemFromShoppingCart(int? prodId)
    //     {
    //         if (prodId == null) return false;

    //         ProductIdBeingProcessed = Convert.ToInt32(prodId);
    //         return true;

    //     }

    //     public bool SaveItemToSHoppingCart(Product product)
    //     {
    //         if (product == null)
    //             return false;

    //         ProductBeingProcessed = product;
    //         return true;
    //     }
    // }

    public class ShoppingCartTest
    {
        public readonly Mock<IDbService> _dbServiceMock = new();

        [Fact]
        public void AddProduct_Success()
        {
            // Given
            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = true;
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // When
            var product = new Product(1, "Shoes", 150);
            var result = shoppingCart.AddProduct(product);

            // Then
            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemToSHoppingCart(It.IsAny<Product>()), Times.Once);
            // Assert.Equal(result, dbMock.ProcessResult);
            // Assert.Equal("Shoes", dbMock.ProductBeingProcessed.Name);
        }

        [Fact]
        public void AddProduct_Failure_DueToInvalidPayload()
        {
            // Given
            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = false;
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // When
            var result = shoppingCart.AddProduct(null);

            // Then
            Assert.False(result);
            // Assert.Equal(result, dbMock.ProcessResult);
            _dbServiceMock.Verify(x => x.SaveItemToSHoppingCart(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void RemoveProduct_Success()
        {
            // Given
            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = true;
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // When
            var product = new Product(1, "Shoes", 150);
            var result = shoppingCart.AddProduct(product);
            var deleteResult = shoppingCart.DeleteProduct(product.Id);

            // Then
            Assert.True(deleteResult);
            // Assert.Equal(deleteResult, dbMock.ProcessResult);
            _dbServiceMock.Verify(x => x.SaveItemToSHoppingCart(It.IsAny<Product>()), Times.Once);

        }
    }
}