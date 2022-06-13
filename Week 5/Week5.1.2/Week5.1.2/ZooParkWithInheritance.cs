using System;

namespace Week5._1
{
    class ZooPark
    {
        static void Main(string[] args)
        {
            //Animal williamWolf = new Animal("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            //Animal tonyTiger = new Animal("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            //Animal edgarEagle = new Animal("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black");
            Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White", "Siberian", "Meat");
            Wolf williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black", "Harpy", 98.5);
            Lion leoLion = new Lion("Leo the Lion", "Meat", "Cat Land", 250, 8, "Brown", "African");
            Penguin pennyPenguin = new Penguin("Penny the Penguin", "Fish", "Bird Mania", 30.5, 10, "Black and White", "Emperor", 75.6);
            Animal baseAnimal = new Animal("Animal Name", "Animal Diet", "Animal Location", 0.0, 0, "Animal Colour");

            baseAnimal.makeNoise();
            tonyTiger.makeNoise();
            williamWolf.makeNoise();
            edgarEagle.makeNoise();
            tonyTiger.eat();
            williamWolf.eat();
            edgarEagle.eat();
            tonyTiger.sleep();
            williamWolf.sleep();
            edgarEagle.sleep();
            edgarEagle.fly();
            leoLion.makeNoise();
            leoLion.eat();
            leoLion.sleep();
            pennyPenguin.makeNoise();
            pennyPenguin.eat();
            pennyPenguin.layEgg();

        }
    }
}
