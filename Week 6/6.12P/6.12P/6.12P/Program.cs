using System;

namespace _6._12P
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using the subclasses
            Cat cat1 = new Cat();
            cat1.Greeting();
            Dog dog1 = new Dog();
            dog1.Greeting();
            BigDog bigDog1 = new BigDog();
            bigDog1.Greeting();

            //Using Polymorphism
            Animal animal1 = new Cat();
            animal1.Greeting();
            Animal animal2 = new Dog();
            animal2.Greeting();
            Animal animal3 = new BigDog();
            animal3.Greeting();
            //Error: Cannot create an instance of an abstract type
            //Animal animal4 = new Animal();

            //Downcast
            Dog dog2 = (Dog)animal2;
            BigDog bigDog2 = (BigDog)animal3;
            Dog dog3 = (Dog)animal3;
            //Cat cat2 = (Cat)animal2; (Causes invalidcastexception)
            dog2.Greeting(dog3);
            dog3.Greeting(dog2);
            dog2.Greeting(bigDog2);
            bigDog2.Greeting(dog2);
            bigDog2.Greeting(bigDog1);
        }
    }
}
