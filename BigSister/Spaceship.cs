using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos
{
    public class Spaceship
    {
        public SpaceshipType Type;

        private int yearOfPurchase;

        private int yearOfTaxCalculation;

        private int lightMilesTraveled;
        public int YearOfPurchase
        {
            get
            {
                return this.yearOfPurchase;
            }
            set
            {
                this.yearOfPurchase = value;
            }
        }

        public int YearOfTaxCalculation
        {
            get
            {
                return this.yearOfTaxCalculation;
            }
            set
            {

                this.yearOfTaxCalculation = value;
            }
        }
        public int LightMilesTraveled
        {
            get
            {
                return this.lightMilesTraveled;
            }
            set
            {
                this.lightMilesTraveled = value;
            }
        }


        public Spaceship()
        { }

        public Spaceship(SpaceshipType type)
        {
            this.Type = type;
        }

        public int IncreaseTax(int lightMilesTraveled)
        {
            var increasedTax = 0;
            for (int i = 1; i <= lightMilesTraveled / 1000; i++)
            {

                if (Type == SpaceshipType.Cargo)
                {
                    increasedTax += 1000;
                }
                else if (Type == SpaceshipType.Family)
                {
                    increasedTax += 100;
                }
            }
            return increasedTax;
        }

        public int DeclineTax(int yearOfPurchase, int yearOfTaxCalculation)
        {
            var declinedTax = 0;
            var yearsOfUse = yearOfTaxCalculation - yearOfPurchase;
            if (yearsOfUse >= 1)
            {

                for (int i = 0; i < yearsOfUse; i++)
                {
                    if (Type == SpaceshipType.Cargo)
                    {
                        declinedTax -= 736;
                    }
                    else if (Type == SpaceshipType.Family)
                    {
                        declinedTax -= 355;
                    }

                }


            }
            if (yearsOfUse < 1)
            {
                throw new ArgumentOutOfRangeException($"{yearOfTaxCalculation} must be greater than {yearOfPurchase}. Try again.");

            }
            return Math.Abs(declinedTax);

        }



        public int CalculateTax(string yearOfPurchaseString, string yearOfTaxCalculationString, string lightMilesTraveledString)
        {
            int yearOfPurchase = int.Parse(yearOfPurchaseString);
            int yearOfTaxCalculation = int.Parse(yearOfTaxCalculationString);
            int lightMilesTraveled = int.Parse(lightMilesTraveledString);
            var initialTax = 0;
            if (Type == SpaceshipType.Cargo)
            {
                initialTax = 10000;
            }
            if (Type == SpaceshipType.Family)
            {
                initialTax = 5000;
            }
            var taxForIncrease = IncreaseTax(lightMilesTraveled);

            var taxForDecline = DeclineTax(yearOfPurchase, yearOfTaxCalculation);


            var result = initialTax + taxForIncrease - taxForDecline;
            Console.WriteLine($"{Type} spaceship bought in {yearOfPurchase} has " +
                 $"traveled {lightMilesTraveled} light miles, so in {yearOfTaxCalculation} " +
                 $"owes: \n{initialTax} + {taxForIncrease} - {taxForDecline} = {result} DVS");
            return result;


        }

    }
}
