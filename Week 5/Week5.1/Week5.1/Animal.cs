using System;
namespace Week5._1
{
    class Animal
    {
        private String name;
        private String diet;
        private String location;
        private double weight;
        private int age;
        private String colour;

        //Constructor
        public Animal(String name, String diet, String location, double weight, int age, String colour)
        {
            this.name = name;
            this.diet = diet;
            this.location = location;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }

        //Methods
        public void eat()
        {
            Console.WriteLine("An animal eats");
        }

        public void sleep()
        {
            Console.WriteLine("An animal sleeps");
        }

        public void makeNoise()
        {
            Console.WriteLine("An animal makes noise");
        }

        public void makeLionNoise()
        {
            Console.WriteLine("A lion roars");
        }

        public void makeEagleNoise()
        {
            Console.WriteLine("An eagle whistles");
        }

        public void makeWolfNoise()
        {
            Console.WriteLine("A wolf howls");
        }

        public void eatMeat()
        {
            Console.WriteLine("An animal eats meat");
        }

        public void eatBerries()
        {
            Console.WriteLine("An animal eats berries");
        }
    }
}
