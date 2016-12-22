using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBL;

namespace CheckoutTest
{
    [TestClass]
    public class CheckoutUnitTest
    {
        [TestMethod]
        public void TestTotalCostForApplesAndOranges()
        {
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Apple", Price = 0.45m},
                new Product() {Id = 2, Name = "Apple", Price = 0.45m},
                new Product() {Id = 3, Name = "Apple", Price = 0.45m},
                new Product() {Id = 4, Name = "Apple", Price = 0.45m},
                new Product() {Id = 5, Name = "Apple", Price = 0.45m},
                new Product() {Id = 6, Name = "Orange", Price = 0.65m},
                new Product() {Id = 7, Name = "Orange", Price = 0.65m},
                new Product() {Id = 8, Name = "Orange", Price = 0.65m},
                new Product() {Id = 9, Name = "Orange", Price = 0.65m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithoutOffers(products);
            
            Assert.AreEqual(4.85m, totalCost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAllApplesAndOrangesHaveSamePrice()
        {
            // We are testing whether one product type has different prices, then throw exception
            // For example all apples should have same price, all oranges should have same price
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Apple", Price = 0.45m},
                new Product() {Id = 2, Name = "Apple", Price = 0.45m},
                new Product() {Id = 3, Name = "Apple", Price = 0.45m},
                new Product() {Id = 4, Name = "Apple", Price = 0.45m},
                new Product() {Id = 5, Name = "Apple", Price = 0.55m},
                new Product() {Id = 6, Name = "Orange", Price = 0.65m},
                new Product() {Id = 7, Name = "Orange", Price = 0.65m},
                new Product() {Id = 8, Name = "Orange", Price = 0.65m},
                new Product() {Id = 9, Name = "Orange", Price = 0.65m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithoutOffers(products);
            
        }


        [TestMethod]
        public void TestWithZeroProductsToCheckout()
        {
            var products = new List<Product>();
            var totalCost = new CheckoutService().GetTotalCostWithoutOffers(products);
            Assert.AreEqual(0.0m, totalCost);
        }

        [TestMethod]
        public void TestProductsOtherThanApplesOranges()
        {
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Banana", Price = 0.45m},
                new Product() {Id = 2, Name = "Banana", Price = 0.45m},
                new Product() {Id = 3, Name = "Banana", Price = 0.45m},
                new Product() {Id = 4, Name = "Banana", Price = 0.45m},
                new Product() {Id = 5, Name = "Banana", Price = 0.45m},
                new Product() {Id = 6, Name = "Peach", Price = 0.65m},
                new Product() {Id = 7, Name = "Peach", Price = 0.65m},
                new Product() {Id = 8, Name = "Peach", Price = 0.65m},
                new Product() {Id = 9, Name = "Peach", Price = 0.65m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithoutOffers(products);
            Assert.AreEqual(0.0m, totalCost);
        }

        [TestMethod]
        public void TestSomeOtherProductsWithApplesOranges()
        {
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Banana", Price = 0.45m},
                new Product() {Id = 2, Name = "Banana", Price = 0.45m},
                new Product() {Id = 3, Name = "Apple", Price = 0.45m},
                new Product() {Id = 4, Name = "Banana", Price = 0.45m},
                new Product() {Id = 5, Name = "Banana", Price = 0.45m},
                new Product() {Id = 6, Name = "Peach", Price = 0.65m},
                new Product() {Id = 7, Name = "Orange", Price = 0.65m},
                new Product() {Id = 8, Name = "Peach", Price = 0.65m},
                new Product() {Id = 9, Name = "Peach", Price = 0.65m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithoutOffers(products);
            Assert.AreEqual(1.10m, totalCost);
        }
    }


}