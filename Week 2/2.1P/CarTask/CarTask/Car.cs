using System;
namespace CarTask
{
    class Car
    {
        //Instance variables
        private double efficiency;      //in miles per gallon (mpg)
        private double fuel;            //fuel in tank (in litres)
        private double miles;           //total miles driven

        //Constants
        private const double UNIT_FUEL_COST = 1.385;    //cost of fuel (dollars/litre)

        public Car(double efficiency, double fuel, double miles)    //constructor
        {
            this.efficiency = efficiency;
            this.fuel = fuel;
            this.miles = miles;
        }

        //Accessor methods
        public double getEfficiency()
        {
            return this.efficiency;
        }

        public double getFuel()
        {
            return this.fuel;
        }

        public double getTotalMiles()
        {
            return this.miles;
        }

        //Mutator methods
        public void setTotalMiles(double miles)
        {
            this.miles = miles;
        }

        //Methods
        public void printFuelCost(double cost)      //Prints fuel cost in dollars and cents
        {
            Console.WriteLine("Cost of fuel used " + cost.ToString("C"));
        }

        public void addFuel(double addedFuel)       //adds fuel into the tank
        {
            this.fuel += addedFuel;
            Console.WriteLine("Fuel added. The tank now has " + getFuel() + " litres of fuel");
        }

        public void calcCost(double fuelAmt)        //calculate cost of fuel
        {
            double cost = fuelAmt * UNIT_FUEL_COST;
            printFuelCost(cost);
        }
        
        public double convertToLitres(double gallon)    //converts gallons to litres
        {
            double litres = gallon * 4.546;
            return litres;
        }

        public void drive(double miles)             //calculates cost based on miles travelled
        {
            this.miles += miles;
            Console.WriteLine("Total miles travelled " + getTotalMiles());
            double fuelUsed = this.miles / efficiency;
            double fuelUsedLitres = convertToLitres(fuelUsed);
            double fuelRemaining = this.fuel -= fuelUsedLitres;
            Console.WriteLine("{0} gallons of fuel = {1:F} litres of fuel", fuelUsed, fuelUsedLitres);
            calcCost(convertToLitres(fuelUsed));
            Console.WriteLine("Amount of fuel remaining {0:F} litres", fuelRemaining);

        }

    }

}
