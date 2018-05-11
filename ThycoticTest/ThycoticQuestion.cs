
#region Instructions
/*
 * You are tasked with writing an algorithm that determines the value of a used car, 
 * given several factors.
 * 
 *    AGE:    Given the number of months of how old the car is, reduce its value one-half 
 *            (0.5) percent.
 *            After 10 years, it's value cannot be reduced further by age. This is not 
 *            cumulative.
 *            
 *    MILES:    For every 1,000 miles on the car, reduce its value by one-fifth of a
 *              percent (0.2). Do not consider remaining miles. After 150,000 miles, it's 
 *              value cannot be reduced further by miles.
 *            
 *    PREVIOUS OWNER:    If the car has had more than 2 previous owners, reduce its value 
 *                       by twenty-five (25) percent. If the car has had no previous  
 *                       owners, add ten (10) percent of the FINAL car value at the end.
 *                    
 *    COLLISION:        For every reported collision the car has been in, remove two (2) 
 *                      percent of it's value up to five (5) collisions.
 *                    
 * 
 *    Each factor should be off of the result of the previous value in the order of
 *        1. AGE
 *        2. MILES
 *        3. PREVIOUS OWNER
 *        4. COLLISION
 *        
 *    E.g., Start with the current value of the car, then adjust for age, take that  
 *    result then adjust for miles, then collision, and finally previous owner. 
 *    Note that if previous owner, had a positive effect, then it should be applied 
 *    AFTER step 4. If a negative effect, then BEFORE step 4.
 */
#endregion

using System;
using NUnit.Framework;

namespace CarPricer
{
    public class Car
    {
        public decimal PurchaseValue { get; set; }
        public int AgeInMonths { get; set; }
        public int NumberOfMiles { get; set; }
        public int NumberOfPreviousOwners { get; set; }
        public int NumberOfCollisions { get; set; }
    }

    public class PriceDeterminator
    {
        private int _ageCapInMonth = 12 * 10;
        private decimal _ageDeRate = decimal.Divide(0.5m, 100);

        private int _mileAgeCap = 150000; // 150,000 miles
        private decimal _mileDeRate = decimal.Divide(0.2m, 100);

        private decimal _collisionDeRate = decimal.Divide(2, 100);
        private int _collisionCap = 5;

        private decimal _positiveOwnerEffect = 0.1m;
        private decimal _negativeOwnerEffect = -0.25m;

        public decimal DetermineCarPrice(Car car)
        {
            var price = PriceByAge(car.AgeInMonths, car.PurchaseValue);
            price = PriceByMileage(car.NumberOfMiles, price);

            return PriceByOwnerAndCollision(
                car.NumberOfPreviousOwners,
                car.NumberOfCollisions,
                price);
        }

        private decimal PriceByAge(int ageInMonth, decimal currentPrice)
        {
            // Decrease price by 0.5 percent (0.005) for every month upto 120
            var age = Math.Min(ageInMonth, _ageCapInMonth);
            var factor = decimal.Subtract(1, _ageDeRate * age);

            return decimal.Multiply(currentPrice, factor);
        }

        private decimal PriceByMileage(int miles, decimal currentPrice)
        {
            var mileage = Math.Min(_mileAgeCap, miles) / 1000;
            var factor = decimal.Subtract(1, _mileDeRate * mileage);

            return decimal.Multiply(currentPrice, factor);
        }

        private decimal PriceByOwnerAndCollision(
            int numberOwner,
            int numberCollision,
            decimal currentPrice)
        {
            // number of Collision or its max
            var c = Math.Min(_collisionCap, numberCollision);
            var cFactor = (1 - c * _collisionDeRate);

            if (numberOwner == 0)
            {
                return decimal.Multiply(
                    1 + _positiveOwnerEffect,
                    currentPrice * cFactor);
            }
            else if (numberOwner > 2)
            {
                // Decrease the price by the negative Owner effect
                var priceAfterOwnerEffect = decimal.Multiply(
                    1 + _negativeOwnerEffect,
                    currentPrice);

                // Then Decrease the price by the collision
                return decimal.Multiply(priceAfterOwnerEffect, cFactor);
            }

            return decimal.Multiply(currentPrice, cFactor);
        }
    }


    public class UnitTests
    {
        [Test]
        public void CalculateCarValue()
        {
            AssertCarValue(25313.40m, 35000m, 3 * 12, 50000, 1, 1);
            AssertCarValue(19688.20m, 35000m, 3 * 12, 150000, 1, 1);
            AssertCarValue(19688.20m, 35000m, 3 * 12, 250000, 1, 1);
            AssertCarValue(20090.00m, 35000m, 3 * 12, 250000, 1, 0);
            AssertCarValue(21657.02m, 35000m, 3 * 12, 250000, 0, 1);
        }

        [Test]
        public void EdgeCases()
        {
            AssertCarValue(19688.20m, 35000m, 3 * 12, 150001, 1, 1);
            AssertCarValue(24500m, 35000m, 5 * 12, 0, 1, 0);
            AssertCarValue(14000m, 35000m, 120, 0, 1, 0);
            AssertCarValue(14000m, 35000m, 122, 0, 1, 0);
            AssertCarValue(9800m, 35000m, 122, 151000, 1, 0);
            AssertCarValue(35000m, 35000m, 0, 0, 1, 0);
            
            AssertCarValue(9800m, 35000m, 120, 151000, 1, 0);
            AssertCarValue(9408m, 35000m, 120, 151000, 1, 2);
            AssertCarValue(12348m, 35000m, 120, 10000, 1, 6);
            //AssertCarValue(12348.00000002m, 35000m, 120, 10000, 1, 6);
        }

        private static void AssertCarValue(
            decimal expectValue,
            decimal purchaseValue,
            int ageInMonths,
            int numberOfMiles,
            int numberOfPreviousOwners,
            int numberOfCollisions)
        {
            Car car = new Car
            {
                AgeInMonths = ageInMonths,
                NumberOfCollisions = numberOfCollisions,
                NumberOfMiles = numberOfMiles,
                NumberOfPreviousOwners = numberOfPreviousOwners,
                PurchaseValue = purchaseValue
            };
            PriceDeterminator priceDeterminator = new PriceDeterminator();
            var carPrice = priceDeterminator.DetermineCarPrice(car);
            Assert.AreEqual(expectValue, carPrice);
        }
    }
}

