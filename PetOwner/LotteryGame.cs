using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwner
{
    internal class LotteryGame
    {
        int winLottery = 0;

        public int WinLottery
        {
            get
            {
                return winLottery;
            }
           private set
            {
                winLottery = value;
            }
        }
        public string RunLotteryGame(int guessNumber) // guessed number confirmed
        {
            int thief;
            Random rnd = new Random();
            int rightNumber = rnd.Next(1, 9);
            string playTextdata = "";

            playTextdata += Environment.NewLine + "You guessed " + guessNumber + Environment.NewLine + "Right number was: " + rightNumber + Environment.NewLine + "________________";
            if (guessNumber == rightNumber)
            {
                WinLottery = 200;
                playTextdata += Environment.NewLine + "Congratulations! You WON $200";
                thief = rnd.Next(1, 11); // 10% chance that the thief will steal your money
                if (thief == 1)
                {
                    WinLottery = 100;
                    playTextdata = "Oh no, the thief stoled $100" + Environment.NewLine + "Anyway..." + Environment.NewLine + "Welcome back again";
                }
            }
            else
            {
                playTextdata += Environment.NewLine + "Sorry for your loss. Better luck next time";
                WinLottery = 0;
            }
            return playTextdata;
        }
    }
}
