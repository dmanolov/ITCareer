using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Животинско_царство_2
{
    public class Trainer
    {
        IAnimal animal;

        public IAnimal Animal
        {
            get => animal;
        }

        public Trainer(IAnimal animal)
        {
            this.animal = animal;
        }
        public void Make()
        {
            animal.Perform();
        }
        
    }
}
