using System;
namespace Week5._1
{
    class Wolf : Animal
    {
        public Wolf(String name, String diet, String location, double weight, int age, String colour)
            : base(name, diet, location, weight, age, colour)
        {
        }

        //Methods
        public override void makeNoise()
        {
            Console.WriteLine("HOWWWWWWWWLLLLL");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 10lbs of meat");
        }
    }
}
