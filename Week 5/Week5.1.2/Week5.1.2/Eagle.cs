using System;
namespace Week5._1
{
    class Eagle : Bird
    {
        public Eagle(String name, String diet, String location, double weight, int age, String colour, String species,
            double wingSpan) : base(name, diet, location, weight, age, colour, species, wingSpan)
        {
        }

        //Methods
        public override void layEgg()
        {
            Console.WriteLine("The eagle lays eggs");
        }

        public override void fly()
        {
            Console.WriteLine("The eagle soars high");
        }

        public override void makeNoise()
        {
            Console.WriteLine("WHISTLEEEEEEEEEE");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 1lb of fish");
        }
    }
}
