using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwner
{
    internal class Store
    {
        public int BuyFood(int wallet, string typeOfFood)
        {
            if (typeOfFood == StorePantry.Steak.ToString())
            {
                return wallet - (int)StorePantry.Steak;
            }
            else if (typeOfFood == StorePantry.Fish.ToString())
            {
                return wallet - (int)StorePantry.Fish;
            }
            else 
            {
                return wallet - (int)StorePantry.Milk;
            } 
        }
        public int BuyBall(int wallet, string choosenColorOnBall)
        {
            if (choosenColorOnBall == StorePantry.Red.ToString())
            {
               return wallet - (int)StorePantry.Red;
            }
            else if (choosenColorOnBall == StorePantry.Yellow.ToString())
            {                
                return wallet - (int)StorePantry.Yellow;
            }
            else if (choosenColorOnBall == StorePantry.Pink.ToString())
            {
                return wallet - (int)StorePantry.Pink;
            }
            else
            {
                return wallet - (int)StorePantry.Gold;
            }
        }
        public string loopThrowAssortmentFood()
        {
            return "Welcome to the store!" + Environment.NewLine +
                "In stock" + Environment.NewLine + Environment.NewLine +
                "__________________" + Environment.NewLine + 
                StorePantry.Steak + " $" + (int)StorePantry.Steak + Environment.NewLine +                
                StorePantry.Fish + " $" + (int)StorePantry.Fish + Environment.NewLine +
                StorePantry.Milk + " $" + (int)StorePantry.Milk + Environment.NewLine +
                "__________________" + Environment.NewLine;
        }
        public string LoopThrowAssortmentBall()
        {            
            return "__________________" + Environment.NewLine + Environment.NewLine +
                    StorePantry.Red + " Ball $" + (int)StorePantry.Red + Environment.NewLine +
                    StorePantry.Yellow + " Ball $" + (int)StorePantry.Yellow + Environment.NewLine +
                    StorePantry.Pink + " Ball $" + (int)StorePantry.Pink + Environment.NewLine +
                    StorePantry.Gold + " Ball $" + (int)StorePantry.Gold + Environment.NewLine +
                    "__________________";
        }
    }
}
