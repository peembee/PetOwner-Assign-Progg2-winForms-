using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PetOwner
{
    internal class Dog : Animal
    {
        public Dog(string breed, string name, int age, string favFood)
        {
            this.breed = breed;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
        }

        public override string Interact(string choosenGame)
        {
            string playTextData = "";
            if (hungry == false && choosenGame == "Dance")
            {
                hungry = true;
                EarnMoneyOnActivities = 10;
                playTextData = name + " and Joppe are dancing to the moon" + Environment.NewLine + "Your Wallet Increased with $10";

            }
            else if (hungry == false && choosenGame == "RunAround")
            {
                hungry = true;
                EarnMoneyOnActivities = 10;
                playTextData = name + " do like to run. Joppe is tired now" + Environment.NewLine + "Your Wallet Increased with $10";
            }
            return playTextData;
        }


        public override string Interact(Ball ball)
        {
            string showPlayText = "";
            Random rnd = new Random();
            int getAction = rnd.Next(1, 4);
            if (getAction == 1)
            {
                showPlayText = "Joppe playing catch ball with " + name;
                getAction = rnd.Next(1, 5);
                if (getAction == 1) // 25% chance for a higher value in LowerQuality()
                {
                    showPlayText = showPlayText + Environment.NewLine + "You forgot to cut " + name + " claws" + Environment.NewLine + "He really messed up the ball..";
                    ball.LowerQuality(8);
                }
                else
                {
                    showPlayText = showPlayText + Environment.NewLine + ball.LowerQuality(4);
                }

            }
            else if (getAction == 2)
            {
                showPlayText = "Joppe and " + name + " kicking the ball to eachother" + Environment.NewLine + ball.LowerQuality(4);
            }
            else
            {
                showPlayText = name + " kicking and eating on the ball" + Environment.NewLine + ball.LowerQuality(5);
            }
            EarnMoneyOnActivities = 15;
            showPlayText += Environment.NewLine + "Your Wallet Increased with $15";
            hungry = true;
            return showPlayText;
        }
        public virtual string GoHunt(string huntOption = "Bear")
        {
            string playTextData = "";
            if (huntOption == "Roedeer")
            {
                Random rnd = new Random();
                int getAction = rnd.Next(1, 4); // 33% chance dog catches a Roedeer.
                playTextData = name + " are looking for a Roedeer in the forest" + Environment.NewLine + "______________";

                if (getAction == 1)
                {
                    playTextData += Environment.NewLine + name + " got a Roedeer!" + Environment.NewLine + "Your Wallet Increased with $25";
                    EarnMoneyOnActivities = 25;
                }
                else
                {
                    playTextData += Environment.NewLine + name + " did not find any animals this times.";
                    EarnMoneyOnActivities = 0;
                }
            }
            else
            {
                playTextData = name + " are loking carefully for bears" + Environment.NewLine + "______________";
                Random rnd = new Random();
                int getAction = rnd.Next(1, 5); // 25% chance dog catches a Bear.
                if (getAction == 1)
                {
                    playTextData += Environment.NewLine + "Wow! " + name + " catched a bear!" + Environment.NewLine + "Your Wallet Increased with $40";
                    EarnMoneyOnActivities = 40;
                }
                else
                {
                    playTextData += Environment.NewLine + name + " did not find any animals this times.";
                    EarnMoneyOnActivities = 0;
                }
            }
            hungry = true;
            return playTextData;
        }
        public string RunningContest()
        {
            

            string playTextData = "";

            int race = 1;
            int dogsterTime = 0;
            int shibaTime = 0;
            Random rnd = new Random();
            playTextData = "Welcome the Running Contest!" + Environment.NewLine +
                breed + ": " + name + " VS " + breed + ": " + "Shiba" + Environment.NewLine +
                "Fastest time in 4 races win!";

            using (StreamWriter streamWriter = new StreamWriter("dogContest.txt")) // replacing the file with zero data of this contest
            {
                streamWriter.WriteLine("");
                streamWriter.Close();
            }

            for (int i = 0; i < 4; i++)
            {
                int raceTime = rnd.Next(20, 45); // represents in racetime in seconds/race
                using (StreamWriter streamWriter = new StreamWriter("dogContest.txt", true)) // Printing results to file.
                {
                    streamWriter.WriteLine(name + ". Race " + race + ": " +raceTime + " Seconds" );
                    streamWriter.WriteLine("___________________");
                    dogsterTime = dogsterTime + raceTime;
                    raceTime = rnd.Next(20, 45);
                    streamWriter.WriteLine("Shiba. Race " + race + ": " + raceTime + " Seconds");
                    streamWriter.WriteLine("___________________");
                    shibaTime = shibaTime + raceTime;
                    streamWriter.Close();
                }
                        race++;
            }

            using (StreamWriter streamWriter = new StreamWriter("dogContest.txt", true))  // printing the total race time to file
            {
                streamWriter.WriteLine(name + " TOTAL: " + dogsterTime);
                streamWriter.WriteLine("Shiba TOTAL: " + shibaTime);
                streamWriter.Close();
            }

            playTextData += Environment.NewLine + "4 races has been raced" + Environment.NewLine +
                name + ": Racetime: " + dogsterTime + " Seconds" +Environment.NewLine + 
                "Shiba: Racetime: " + shibaTime + " Seconds";

            if (dogsterTime < shibaTime) // user win
            {
                playTextData += Environment.NewLine + "Congratulation! " + name + " won the contest" + Environment.NewLine + "Your Wallet Increased with $60";
                EarnMoneyOnActivities = 60;

            }
            else if (dogsterTime == shibaTime) // results were even
            {
                playTextData += Environment.NewLine + "Time was even!" + Environment.NewLine + "Your Wallet Increased with $15";
                EarnMoneyOnActivities = 15;
            }
            else // user loose
            {
                playTextData += Environment.NewLine + "Shiba won the contest!" + Environment.NewLine + "You loose $30";
                EarnMoneyOnActivities = -30;
            }
            hungry = true;
            return playTextData;
        }
    }
}
