using System;
using System.Text.RegularExpressions;

namespace Cosmos
{
    public class Program
    {
        static void Main()
        {

            Console.WriteLine("Enter spaceship type: C for Cargo or F for Family");
            var shipType = Console.ReadLine();
            ValidateType(shipType);

            Console.WriteLine("Enter year of purchase in format {yyyy}:");
            var yearOfPurchaseString = Console.ReadLine();
            var yearOfPurchaseValid = ValidateYear(yearOfPurchaseString);

            Console.WriteLine("Enter year of tax calculation in format {yyyy}:");
            var yearOfTaxCalculationString = Console.ReadLine();
            var yearOfTaxCalculationValid = ValidateYear(yearOfTaxCalculationString);


            Console.WriteLine("Enter light miles traveled:");
            var lightMilesTraveledString = Console.ReadLine();
            var lightMilesTraveledValid = ValidateMile(lightMilesTraveledString);



            var ship = new Spaceship();

            if (string.Equals(shipType, "C", StringComparison.InvariantCultureIgnoreCase))
            {
                ship.Type = SpaceshipType.Cargo;
            }
            if (string.Equals(shipType, "F", StringComparison.InvariantCultureIgnoreCase))
            {
                ship.Type = SpaceshipType.Family;
            }


            ship.CalculateTax(yearOfPurchaseValid, yearOfTaxCalculationValid, lightMilesTraveledValid);


        }
        public static void ValidateType(string shipType)
        {
            while (shipType != "C" && shipType != "c" &&
                shipType != "F" && shipType != "f")
            {
                Console.WriteLine("Please, enter the correct type of spaceship. Only C or F");
                shipType = Console.ReadLine();
            }
        }

        public static string ValidateYear(string year)
        {
            while (string.IsNullOrEmpty(year) || !Regex.IsMatch(year, @"^[0-9]{4}$"))
            {
                Console.WriteLine("Please enter the year in the correct format. Four digits.");
                year = Console.ReadLine();
                if (Regex.IsMatch(year, @"^[0-9]{4}$"))
                {
                    break;
                }
            }
            return year;

        }

        public static string ValidateMile(string mile)
        {

            while (!Regex.IsMatch(mile, "^[0-9]*$"))
            {
                Console.WriteLine("Please enter only digits.");
                mile = Console.ReadLine();
                if (Regex.IsMatch(mile, "^[0-9]*$"))
                {
                    break;
                }
            }
            return mile;
        }

    }
}



