using System;
namespace _6._1P
{
    class Bird
    {
        public String name { get; set; }

        public Bird()
        {

        }

        public virtual void fly()
        {
            Console.WriteLine("Flap, Flap, Flap");
        }

        public override string ToString()
        {
            return "A bird called " + name; 
        }
    }
}
