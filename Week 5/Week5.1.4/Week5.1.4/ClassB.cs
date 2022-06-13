using System;
namespace Week5._1._4
{
    class ClassB : ClassA
    {
        public override double Division(int j)
        {
            return (double)i / j;
        }

        public void PrintResults(int j)
        {
            Console.WriteLine("i: {0}", i);
            Console.WriteLine("Sum(j): {0}", Sum(j));
            Console.WriteLine("Product(j): {0}", Product(j));
            Console.WriteLine("Division(j): {0}", Division(j));
        }
    }
}
