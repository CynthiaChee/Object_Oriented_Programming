using System;
namespace Week5._1
{
    class Bird : Animal
    {
        private String species;
        private double wingSpan;

        public Bird(String name, String diet, String location, double weight, int age, String colour, String species, double wingSpan)
            : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
            this.wingSpan = wingSpan;
        }

        //Methods
        public virtual void layEgg()
        {
            Console.WriteLine("A bird lays eggs");
        }

        public virtual void fly()
        {
            Console.WriteLine("A bird flies");
        }

        public override void makeNoise()
        {
            Console.WriteLine("A bird screeches");
        }

        public override void eat()
        {
            Console.WriteLine("A bird eats");
        }
    }
}
