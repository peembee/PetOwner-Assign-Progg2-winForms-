using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PetOwner
{
    internal class Puppy : Dog
    {
        public Puppy(string breed, string name, int age, string favFood) : base(breed, name, age, favFood)
        {
            this.breed = breed;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
        }
        public override string Interact(string str = "")
        {
            string playTextData = "";
            if (hungry == false)
            {
                hungry = true;
                EarnMoneyOnActivities = 5;
                playTextData = "Joppe are now playing with " + name + Environment.NewLine + "Your Wallet Increased with $5";
            }
            return playTextData;
        }
        public override string Interact(Ball ball)
        {
            string getPlayData = "";
            Random rnd = new Random();
            int getAction = rnd.Next(1, 4);
            if (getAction == 1)
            {
                getAction = rnd.Next(1, 11);
                if (getAction == 1) // 10% chance for a higher value in LowerQuality()
                {
                    getPlayData = "Young dogs have very sharp teeths, this ball is pretty messed up.." + Environment.NewLine + ball.LowerQuality(13);
                }
                else
                {
                    getPlayData = name + " just sniffing and scratches on the ball.." + Environment.NewLine + ball.LowerQuality(2);
                }
            }
            else if (getAction == 2)
            {
                getPlayData = name + " jumps on the ball.. constantly" + Environment.NewLine + ball.LowerQuality(3);
            }
            else
            {
                getPlayData = name + " wants to play catch!" + Environment.NewLine + ball.LowerQuality(3);
            }
            hungry = true;
            EarnMoneyOnActivities = 15;
            getPlayData += Environment.NewLine + "Your Wallet Increased with $15";
            return getPlayData;
        }
        public override string GoHunt(string autoStart = "")
        {
            string playTextData;
            EarnMoneyOnActivities = 1;
            playTextData = name + " running around and catches bugs!" + Environment.NewLine + "Your Wallet Increased with $1";
            hungry = true;
            return playTextData;
        }
        public string PuppyShow()
        {
            Random rnd = new Random();
            string playDataText = "";
            int rounds = 1;
            int vote;
            int bagsterVotes = 0;
            int dogeVotes = 0;

            playDataText = "Welcome to the Puppy show Contest" + Environment.NewLine +
                breed + ": " + name + " VS " + breed + ": " + "Doge" + Environment.NewLine +
                "10 judges - one vote" + Environment.NewLine +
                "Most votes win the contest";

            using (StreamWriter streamWriter = new StreamWriter("puppyContest.txt")) // replacing the file with zero data of this contest
            {
                streamWriter.WriteLine("");
                streamWriter.Close();
            }

            for (int i = 0; i < 10; i++)
            {
                vote = rnd.Next(1, 3);
                using (StreamWriter streamWriter = new StreamWriter("puppyContest.txt", true)) // Print contestvotes to file
                {
                    if (vote == 1)
                    {
                        bagsterVotes = bagsterVotes + 1;
                        streamWriter.WriteLine("Vote " + rounds + " goes to " + name);
                        streamWriter.WriteLine("___________________");
                    }
                    else
                    {
                        dogeVotes = dogeVotes + 1;
                        streamWriter.WriteLine("Vote " + rounds + " goes to " + "Doge");
                        streamWriter.WriteLine("___________________");
                    }
                    streamWriter.Close();
                }
                rounds++;
            }
            using (StreamWriter streamWriter = new StreamWriter("puppyContest.txt", true))  // printing the total race time to file
            {
                streamWriter.WriteLine(name + " TOTAL: " + bagsterVotes);
                streamWriter.WriteLine("Doge TOTAL: " + dogeVotes);
                streamWriter.Close();
            }

            playDataText += Environment.NewLine + "Calculating result..." + Environment.NewLine +
                (name + ": Votes: " + bagsterVotes) + Environment.NewLine +
                "Shiba: Votes: " + dogeVotes;

            if (bagsterVotes > dogeVotes) // user wins
            {
                EarnMoneyOnActivities = 100;
                playDataText += Environment.NewLine + "Congratulations!" + name + " Won the contest! with " + Environment.NewLine +
                    (bagsterVotes - dogeVotes) + " Vote(s) more" + Environment.NewLine +
                    "Your Wallet Increased with $100";
            }
            else if (bagsterVotes == dogeVotes) // results were even
            {
                EarnMoneyOnActivities = 50;
                playDataText += Environment.NewLine + "Votes were even" + Environment.NewLine +
                    "Your Wallet Increased with $50";
            }
            else // user loose
            {
                EarnMoneyOnActivities = -50;
                playDataText += Environment.NewLine + "Doge won the contest with " + Environment.NewLine +
                    (dogeVotes - bagsterVotes) + Environment.NewLine +
                    " Vote(s) more" + Environment.NewLine +
                    ("You loose $50");
            }
            hungry = true;
            return playDataText;
        }
    }
}

