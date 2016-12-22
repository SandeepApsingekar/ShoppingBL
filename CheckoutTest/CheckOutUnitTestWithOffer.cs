using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBL;

namespace CheckoutTest
{
    [TestClass]
    public class CheckOutUnitTestWithOffer
    {
        [TestMethod]
        public void TestCostWithOfferForApplesOranges()
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
            var totalCost = new CheckoutService().GetTotalCostWithOffer(products);
            //Expected apples + oranges prices =   1.35 + 1.95 = 3.30
            Assert.AreEqual(3.30m, totalCost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToCheckPrices()
        {
            //This is to test whether all apples should have same price 
            //and all oranges should have same price and this will throw exception
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Orange", Price = 0.65m},
                new Product() {Id = 2, Name = "Orange", Price = 0.65m},
                new Product() {Id = 3, Name = "Orange", Price = 0.65m},
                new Product() {Id = 4, Name = "Orange", Price = 0.65m},
                new Product() {Id = 5, Name = "Apple", Price = 0.55m},
                new Product() {Id = 6, Name = "Apple", Price = 0.45m},
                new Product() {Id = 7, Name = "Apple", Price = 0.45m},
                new Product() {Id = 8, Name = "Apple", Price = 0.45m},
                new Product() {Id = 9, Name = "Apple", Price = 0.45m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithOffer(products);

        }

        [TestMethod]
        public void TestForNoFruits()
        {
            var products = new List<Product>();
            var totalCost = new CheckoutService().GetTotalCostWithOffer(products);
            //According to our function this should give a result as 0.0m 
            Assert.AreEqual(0.0m, totalCost);
        }

        [TestMethod]
        public void TestForOtherFruits()
        {
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Mango", Price = 0.45m},
                new Product() {Id = 2, Name = "Mango", Price = 0.45m},
                new Product() {Id = 3, Name = "Mango", Price = 0.45m},
                new Product() {Id = 4, Name = "Mango", Price = 0.45m},
                new Product() {Id = 5, Name = "Mango", Price = 0.45m},
                new Product() {Id = 6, Name = "Green Apple", Price = 0.65m},
                new Product() {Id = 7, Name = "Green Apple", Price = 0.65m},
                new Product() {Id = 8, Name = "Green Apple", Price = 0.65m},
                new Product() {Id = 9, Name = "Green Apple", Price = 0.65m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithOffer(products);
            //According to our logic this should give 0.0m as we have only apple and orange as fruits
            Assert.AreEqual(0.0m, totalCost);
        }

        [TestMethod]
        public void TestAllFruitsWithAppleOrange()
        {
            var products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Apple", Price = 0.45m},
                new Product() {Id = 2, Name = "Banana", Price = 0.45m},
                new Product() {Id = 3, Name = "Apple", Price = 0.45m},
                new Product() {Id = 4, Name = "Banana", Price = 0.45m},
                new Product() {Id = 5, Name = "Banana", Price = 0.45m},
                new Product() {Id = 6, Name = "Peach", Price = 0.65m},
                new Product() {Id = 7, Name = "Orange", Price = 0.65m},
                new Product() {Id = 8, Name = "Peach", Price = 0.65m},
                new Product() {Id = 9, Name = "Peach", Price = 0.65m},
            };

            var totalCost = new CheckoutService().GetTotalCostWithOffer(products);
            //According to our logic for offer, this should give 1.10 as we have two apples and one orange
            Assert.AreEqual(1.10m, totalCost);
        }

    }
}
