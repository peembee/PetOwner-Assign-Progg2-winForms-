using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwner
{
    internal abstract class Animal
    {
        protected string breed;
        protected string name;
        protected int age;
        protected string favFood;
        protected bool hungry = false;
        protected int earnMoneyOnActivities;
        public bool setHunger // propertie for restoring data/ enter new game.
        {
            private get { return hungry; }
            set { hungry = value; }
        }
        public string Hungry()
        {
            string statusOfHunger;
            if (hungry == true)
            {
                statusOfHunger = "Hungry";
            }
            else
            {
                statusOfHunger = "Not Hungry";
            }

            return statusOfHunger;
        }
        public string NameOfTheAnimal
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }
        public string FavFood
        {
            get
            {
                return favFood;
            }
            private set
            {
                favFood = value;
            }
        }
        public int AgeOfTheAnimal
        {
            get
            {
                return age;
            }
            private set
            {
                age = value;
            }
        }
        public string BreedOfTheAnimal
        {
            get
            {
                return breed;
            }
            private set
            {
                breed = value;
            }
        }

        public string JustWantToEat()
        {
            string giveText = "____________________________________" +
                Environment.NewLine + name + " needs to eat for play around" +
                Environment.NewLine + "____________________________________";
            return giveText;
        }
        public virtual string Interact(string play = "")
        {
            if (hungry == false)
            {
                play = "Joppe are now playing with " + name + Environment.NewLine + "Your Wallet Increased with $5";
                hungry = true;
            }
            else
            {
                play = name + " needs to eat for play around";
            }
            return play;
        }

        public virtual string Interact(Ball ball)
        {
            ball.LowerQuality(1);
            hungry = true;
            return "Your Wallet Increased with $10" + Environment.NewLine +
                name + " playing with the ball.." + Environment.NewLine +
                "Quality for the ball decreases with 1";
        }
        public string Eat(string food)
        {
            if (hungry == true && favFood == food)
            {
                hungry = false;
                return name + " was pretty hungry, but not anymore";
            }
            else
            {
                return "Pet is not hungry yet, try to play with the pet";
            }
        }
        public virtual string HungryAnimals()
        {
            return "_________________________________" + Environment.NewLine +
                "Looks like the pet didn't like the food, " + name + " are whining... and now he runs away!" + Environment.NewLine +
                "_________________________________";
        }
        public int EarnMoneyOnActivities
        {
            get 
            {
                return earnMoneyOnActivities;
            }
             set
            {
                earnMoneyOnActivities = value;
            }
        } // Setting the money you earn when pet do activities

        public override string ToString()
        {
            return "Breed: " + BreedOfTheAnimal + Environment.NewLine + "Name: " + NameOfTheAnimal + Environment.NewLine + "Age: " + AgeOfTheAnimal + " Years" + Environment.NewLine + " Fav Food: " + FavFood + Environment.NewLine + "__________" + Environment.NewLine;

        }
    }
}
