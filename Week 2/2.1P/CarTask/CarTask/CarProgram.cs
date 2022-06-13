using System;

namespace CarTask
{
    class CarProgram
    {
        static void Main(string[] args)
        {
            Car samCar = new Car(40, 0, 0);
            samCar.setTotalMiles(0);

            Console.WriteLine();
            Console.WriteLine("Fuel efficiency " + samCar.getEfficiency() + " miles per gallon");
       
            samCar.addFuel(50);
            samCar.drive(75);
        }
    }
}