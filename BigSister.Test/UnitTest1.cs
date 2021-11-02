using Cosmos;
using NUnit.Framework;
using System;

namespace BigSister.Test
{
    public class Tests
    {
        [TestFixture]
        public class TestSpaceship
        {
         [Test]
            public void TestSpaceship_WhenIncreaseTax_ShouldCalculateCorrectly()
            {
                //Arrange
                var spaceship = new Spaceship(SpaceshipType.Cargo);
                var ligthMilesTraveled = 1000;


                //Act
                var result = spaceship.IncreaseTax(ligthMilesTraveled);


                //Assert
                Assert.AreEqual(result, 1000);
            }

            [Test]
            public void TestSpaceship_WhenDeclineTax_ShouldCalculateCorrectly()
            {
                //Arrange
                var spaceship = new Spaceship(SpaceshipType.Family);
                var yearOfPurchase = 2000;
                var yearOfTaxCalculation = 2010;


                //Act
                var result = spaceship.DeclineTax(yearOfPurchase, yearOfTaxCalculation);

                //Assert
                Assert.AreEqual(result, 3550);
            }


            [Test]

            public void TestSpaceship_CalculateTax_ShouldCalculateCorrectly()
            {
                //Arrange
                var spaceship = new Spaceship(SpaceshipType.Family);
                var yearOfPurchase = "2000";
                var yearOfTaxCalculation = "2010";
                var lightMileTraveled = "11111";


                //Act
                var result = spaceship.CalculateTax(yearOfPurchase, yearOfTaxCalculation, lightMileTraveled);

                //Assert
                Assert.AreEqual(result, 2550);
            }

            [Test]


            public void TestSpaceship_WhenYearsAreIncorrect_ShouldThrowException()
            {
                //Arrange
                var spaceship = new Spaceship(SpaceshipType.Cargo);


                //Act and Assert
                Assert.Throws<ArgumentOutOfRangeException>(() =>
               spaceship.DeclineTax(2000, 1000));

            }

            [Test]
            public void TestSpaceship_CreateNewSpaceship_ShouldCreateCorrectly()
            {
                //Arrange
                var ship = new Spaceship();


                //Act
                ship.Type = SpaceshipType.Cargo;


                //Assert
                Assert.IsTrue(ship.Type == SpaceshipType.Cargo || ship.Type == SpaceshipType.Family);
            }


        }
    }
}