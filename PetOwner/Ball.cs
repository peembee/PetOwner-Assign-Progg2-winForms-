using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwner
{
    internal class Ball
    {
        private string color;
        private int quality;
        public Ball(string color = "Red", int quality = 20)
        {
            this.color = color;
            this.quality = quality;
        }
        public string Color
        {
            get { return color; }
            set
            {
                if (Color == StorePantry.Red.ToString() || Color == StorePantry.Yellow.ToString() || Color == StorePantry.Pink.ToString() || Color == StorePantry.Gold.ToString())
                {
                    color = value;
                }
                else
                {
                    color = StorePantry.Red.ToString();
                }
            }
        }
        public int Quality
        {
            get
            {
                return quality;
            }
            set
            {
                quality = value;
            }
        }
        public string LowerQuality(int lowerQuality)
        {
            quality = quality - lowerQuality;
            if (quality < 1)
            {
                quality = 0;                
                return "________________" + Environment.NewLine + "Ball destroyd!" + Environment.NewLine + "________________";
            }
            return "Quality for the ball decreases with " + lowerQuality.ToString();
        }

        public override string ToString()
        {
            return "Color on ball: " + color + Environment.NewLine + Environment.NewLine + "Quality on ball: " + quality;
        }
    }
}
