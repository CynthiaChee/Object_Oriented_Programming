using System;

namespace Week5._1._3
{
    class Overloading
    {
        static void Main(string[] args)
        {
            //Two or more methods having the same name but different signatures
            //Compiler determines which method to call based on arguments provided

            methodToBeOverloaded("Harry");
            methodToBeOverloaded("Potter", 21);

            methodToBeOverloaded("Samson");
            methodToBeOverloaded("Delilah", 19);
        }

        public static void methodToBeOverloaded(String name)
        {
            Console.WriteLine("Name: " + name);
        }

        public static void methodToBeOverloaded(String name, int age)
        {
            Console.WriteLine("Name: " + name + "\nAge: " + age);
        }
    }
}
