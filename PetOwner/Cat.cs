using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PetOwner
{
    internal class Cat : Animal
    {
        public Cat(string breed, string name, int age, string favFood)
        {
            this.breed = breed;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
        }
        public override string Interact(string str = " ")
        {
            hungry = true;
            EarnMoneyOnActivities = 5;
            return "Joppe playing with cat with a bell" + Environment.NewLine + "Your Wallet Increased with $5";
        }
        public override string Interact(Ball ball)
        {
            string getPlayText = "";
            Random rnd = new Random();
            int getAction = rnd.Next(1, 4);
            if (getAction == 1)
            {
                getPlayText = name + " Really running away.. He did not like the ball";
                ball.LowerQuality(0);
            }
            else if (getAction == 2)
            {
                getPlayText = name + " likes to scratch the ball";
                getAction = rnd.Next(1, 11);
                if (getAction == 1) // 10% chance for ball to be destroyd
                {
                    getPlayText = getPlayText + Environment.NewLine + "Wow that ball just popped! " + Environment.NewLine + name +
                    " really have sharp claws!" + Environment.NewLine +
                    ball.LowerQuality(20);
                }
                else
                {
                    ball.LowerQuality(2);
                }
            }
            else
            {
                getPlayText = name + " attacking the ball. this wasn't such a good idea..." + Environment.NewLine + ball.LowerQuality(3);
            }
            hungry = true;
            getPlayText += Environment.NewLine + "Your Wallet Increased with $10";
            EarnMoneyOnActivities = 10;
            return getPlayText;
        }

        public string patCat()
        {
            string playTextData = "";
            EarnMoneyOnActivities = 2;
            playTextData = name + " likes being pat" + Environment.NewLine + "Your Wallet Increased with $2";
            EarnMoneyOnActivities = 2;
            Random rnd = new Random();
            int getAction = rnd.Next(1, 4);
            if (getAction == 1) // 33% chance will make the cat hungry
            {
                hungry = true;
            }

            return playTextData;
        }
        public override string HungryAnimals()
        {
            string getAction;
            Random rnd = new Random();
            int catchMouse = rnd.Next(1, 3);
            getAction = name + " did not want to have this food and now he runs from me" + Environment.NewLine +
                name + " likes to chase mouses instead.. ";
            if (catchMouse == 1)
            {
                getAction += Environment.NewLine + " Look, he caught a mouse!";
                hungry = false;
            }
            else
            {
                getAction += Environment.NewLine + "Nope, no mouse this time.. ";
            }
            return getAction;
        }

        public string HuntBird()
        {
            string playTextData = "";
            Random rnd = new Random();
            int getAction = rnd.Next(1, 3); // 50/50 chance that cat catches a bird

            playTextData = name + " is looking for birds to catch";
            if (getAction == 1)
            {
                EarnMoneyOnActivities = 20;
                playTextData += Environment.NewLine + "OH look, he catched a bird!" + Environment.NewLine + "Your Wallet Increased with $20";
            }
            else
            {
                EarnMoneyOnActivities = 0;
                playTextData += Environment.NewLine + Environment.NewLine + name + " did not catch any bird this time";
            }
            hungry = true;
            return playTextData;
        }
        public string MouseCatchContest()
        {
            string playTextData = "";

            int kittyCatches = 0;
            int catserCatches = 0;
            Random rnd = new Random();
            int mousecatch = rnd.Next();

            playTextData = "Welcome to the Cat Mouse Catcher Contest" + Environment.NewLine +
                breed + ": " + name + " VS " + breed + ": " + "Kitty" + Environment.NewLine +
                "Whoever catches most mouses win the contest!";

            using (StreamWriter streamWriter = new StreamWriter("catContest.txt")) // replacing the file with zero data of this contest
            {
                streamWriter.WriteLine("");
                streamWriter.Close();
            }

            for (int i = 0; i < 6; i++)
            {
                using (StreamWriter streamWriter = new StreamWriter("catContest.txt", true)) // Print results to file
                {
                    mousecatch = rnd.Next(1, 10); // represent the amount of mouses cat catches.
                    catserCatches = catserCatches + mousecatch;

                    streamWriter.WriteLine(name + " Got: " + mousecatch + " mice");
                    streamWriter.WriteLine("___________________");

                    mousecatch = rnd.Next(1, 10);
                    kittyCatches = kittyCatches + mousecatch;

                    streamWriter.WriteLine("Kitty Got: " + mousecatch + " mice");
                    streamWriter.WriteLine("___________________");
                    streamWriter.Close();
                }
            }
            using (StreamWriter streamWriter = new StreamWriter("catContest.txt", true))  // printing the total catch to file
            {
                streamWriter.WriteLine(name + " TOTAL: " + catserCatches);
                streamWriter.WriteLine("Kitty TOTAL: " + kittyCatches);
                streamWriter.Close();
            }
            playTextData += Environment.NewLine + "Getting results..." + Environment.NewLine + 
                name + " got " + catserCatches + " Mouse(s)" + Environment.NewLine + 
                "Kitty got " + kittyCatches + " Mouse(s)";

            if (catserCatches > kittyCatches) // user win
            {
                EarnMoneyOnActivities = 60;
                playTextData += Environment.NewLine + "Congratulations! " + name + Environment.NewLine +
                    " Won the Contest with " + Environment.NewLine +
                    (catserCatches - kittyCatches) + " more mouse(s)!" + Environment.NewLine +
                    "Your Wallet Increased with $60";
            }
            else if (catserCatches == kittyCatches) // results were even
            {
                EarnMoneyOnActivities = 30;
                playTextData += Environment.NewLine + "Both " + name + " and Kitty got the same amount of mouses" + Environment.NewLine +
                "Your Wallet Increased with $30";
            }
            else // user loose
            {
                EarnMoneyOnActivities = -30;
                playTextData += Environment.NewLine + "Kitty Won the Contest with" + Environment.NewLine +
                    (kittyCatches - catserCatches) + " more mouse(s)!" + Environment.NewLine +
                    "You loose $30";
            }
            hungry = true;
            return playTextData;
        }
    }
}
