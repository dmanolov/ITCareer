using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Животинско_царство_2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            Dog dog = new Dog();

            Trainer catTrainer = new Trainer(cat);
            Trainer dogTrainer = new Trainer(dog);

            catTrainer.Make();
            dogTrainer.Make();
        }
    }
}
