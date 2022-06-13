using System;
using System.Collections.Generic;

namespace _6._1P
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird1 = new Bird();
            Bird bird2 = new Bird();

            bird1.name = "Feathers";
            bird2.name = "Polly";

            //Console.WriteLine(bird1.ToString());
            //bird1.fly();

            //Console.WriteLine(bird2.ToString());
            //bird2.fly();

            Penguin penguin1 = new Penguin();
            Penguin penguin2 = new Penguin();

            penguin1.name = "Happy Feet";
            penguin2.name = "Gloria";

            //Console.WriteLine(penguin1.ToString());
            //penguin1.fly();

            //Console.WriteLine(penguin2.ToString());
            //penguin2.fly();

            Duck duck1 = new Duck();
            Duck duck2 = new Duck();

            duck1.name = "Daffy";
            duck1.size = 15;
            duck1.kind = "Mallard";

            duck2.name = "Donald";
            duck2.size = 20;
            duck2.kind = "Decoy";

            //Console.WriteLine(duck1.ToString());
            //Console.WriteLine(duck2.ToString());

            //Covariance (add entire list of Duck objects(derived) to Bird objects(base))
            List<Duck> ducksToAdd = new List<Duck>()
            {
                duck1,
                duck2,
            };

            IEnumerable<Bird> upcastDucks = ducksToAdd;

            List<Bird> birds = new List<Bird>();
            birds.Add(bird1);
            birds.Add(bird2);
            birds.Add(penguin1);
            birds.Add(penguin2);
            birds.Add(duck1);
            birds.Add(duck2);
            birds.Add(new Bird { name = "Birdy" });
            birds.Add(new Bird { name = "Feather" });

            birds.AddRange(upcastDucks);

            //Calls ToString() of each bird
            foreach (Bird bird in birds)
            {
                Console.WriteLine(bird);
            }




        }
    }
}
