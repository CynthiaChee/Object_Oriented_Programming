using System;
namespace Week5._1
{
    class Lion : Feline
    {
        public Lion(String name, String diet, String location, double weight, int age, String colour, String species)
            : base(name, diet, location, weight, age, colour, species)
        {
        }

        public override void makeNoise()
        {
            Console.WriteLine("GROWLLLLLLLL");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 35lbs of meat");
        }

    }
}
