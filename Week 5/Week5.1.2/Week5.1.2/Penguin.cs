using System;
namespace Week5._1
{
    class Penguin : Bird
    {
        public Penguin(String name, String diet, String location, double weight, int age, String colour, String species,
            double wingSpan) : base(name, diet, location, weight, age, colour, species, wingSpan)
        {
        }

        //Methods
        public override void layEgg()
        {
            Console.WriteLine("The penguin lays a single egg");
        }

        public override void makeNoise()
        {
            Console.WriteLine("SQUAWK SQUAWK");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 2lb of fish");
        }
    }
}
