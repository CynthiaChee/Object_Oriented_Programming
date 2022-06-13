using System;
namespace Week5._1
{
    class Tiger : Feline
    {
        private String colourStripes;

        public Tiger(String name, String diet, String location, double weight, int age, String colour, String species,
            String colourStripes):base(name, diet, location, weight, age, colour, species)
        {
            this.colourStripes = colourStripes;
        }

        //Methods
        public override void makeNoise()
        {
            Console.WriteLine("ROARRRRRRRRRRR");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 20lbs of meat");
        }
    }
}
