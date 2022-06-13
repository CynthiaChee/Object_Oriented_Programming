using System;
namespace _6._12P
{
    public class Dog : Animal
    {
        public override void Greeting()
        {
            Console.WriteLine("Dog: Woof!");
        }

        public void Greeting(Dog another)
        {
            Console.WriteLine("Dog: Wooooooooooof!");
        }
    }
}
