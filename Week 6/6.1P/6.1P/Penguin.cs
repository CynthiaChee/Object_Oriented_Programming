using System;
namespace _6._1P
{
    class Penguin : Bird
    {
        public override void fly()
        {
            Console.WriteLine("Penguins cannot fly");
        }

        public override string ToString()
        {
            return "A penguin named " + base.name;
        }
    }
}
