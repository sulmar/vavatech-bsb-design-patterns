﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyPattern.CanDiscountStrategies;
using StrategyPattern.DiscountStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.UnitTests
{
    [TestClass]
    public class HappyHoursPercentageOrderCalculatorTests
    {
        private OrderCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            var from = TimeSpan.Parse("09:00");
            var to = TimeSpan.Parse("15:00");

            ICanDiscountStrategy canDiscountStrategy = new HappyHoursCanDiscountStrategy(from, to);
            IDiscountStrategy discountStrategy = new PercentageDiscountStrategy(0.1m);
            
            calculator = new OrderCalculator(canDiscountStrategy, discountStrategy);
        }

        [TestMethod]
        public void CalculateDiscount_DuringHappyHours_ShouldDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2020-06-12 14:59"), new Customer(), 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(10, discount);

        }

        [TestMethod]
        public void CalculateDiscount_BeforeHappyHours_ShouldNotDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2020-06-12 08:59"), new Customer(), 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void CalculateDiscount_AfterHappyHours_ShouldNotDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2020-06-12 15:01"), new Customer(), 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(0, discount);
        }
    }
}
