using System;
namespace _6._12P
{
    public class BigDog : Dog
    {
        public override void Greeting()
        {
            Console.WriteLine("BigDog: Woow!");
        }

        new public void Greeting(Dog another)
        {
            Console.WriteLine("Dog: Woooooooowwwww!");
        }
    }
}
