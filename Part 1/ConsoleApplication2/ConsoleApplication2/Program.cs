using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cf africa = new AfricaF();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            Cf america = new AmericaF();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadKey();
        }
    }

    abstract class Cf
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    class AfricaF : Cf
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    class AmericaF : Cf
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    abstract class Herbivore
    {
        public abstract void Eat();
    }

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    class Wildebeest : Herbivore
    {
        public override void Eat()
        {
            Console.WriteLine(this.GetType().Name + " eat grasses, leaves, and shoots!");
        }
    }

    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class Bison: Herbivore
    {
        public override void Eat()
        {
            Console.WriteLine("{0} eat grass and sedges!", this.GetType().Name);
        }
    }

    class Wolf: Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine("{0} eats {1}.", this.GetType().Name, h.GetType().Name);
        }
    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(Cf f)
        {
            _carnivore = f.CreateCarnivore();
            _herbivore = f.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _herbivore.Eat();
            _carnivore.Eat(_herbivore);
        }
    }
}
