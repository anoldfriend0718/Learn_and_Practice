using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADTrainning
{
    public abstract class PrepareBase
    {
        public void Prepare()
        {
            BoilWater();
            PutMaterial();
            PourInCup();
            if (IsAddAddition())
            {
                AddAddition();
            }
            
        }

        public virtual bool IsAddAddition()
        {
            return true;                                              
        }

        private void BoilWater()
        {
            Console.WriteLine("Step1: BoilWater");
        }

        protected abstract void PutMaterial();

        private void PourInCup()
        {
            Console.WriteLine("Step 3: pour in cup");                            
        }

        protected abstract void AddAddition();
    }





    public class PrepareCoffee : PrepareBase
    {
        protected override void AddAddition()
        {
            Console.WriteLine("Step 4: Add leamon");
        }

        protected override void PutMaterial()
        {
            Console.WriteLine("Step 2: put coffee");
        }

        public override bool IsAddAddition()
        {
            Console.WriteLine("Do you want to add some additions, please input y or n");
            var input=Console.ReadLine();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                throw new ArgumentOutOfRangeException("InValid input");
            }
        }


    }

    public class PrepareTea : PrepareBase
    {
        protected override void AddAddition()
        {
            Console.WriteLine("Step 4: put milk");
        }

        protected override void PutMaterial()
        {
            Console.WriteLine("Step 2: put tea");
        }
    }


}
