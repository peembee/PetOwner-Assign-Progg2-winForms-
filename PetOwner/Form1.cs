using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PetOwner
{
    public partial class Form1 : Form
    {
        int changeActionOnShowHungerBtn = 1; // Reveal information about pets hunger
        int changeActionOnPetOwnerBtn = 1; // some information about petowner will reveal when pushing PetOwnerBtn.
        int changeActionOnWalletBtn = 1; // if btn is 0 = show "Wallet", else show "wallet + $money
        string newLine = Environment.NewLine; // For easier string manipulation. creates a new line in btnHungry
        private int wallet = 200;  // 

        private List<Animal> animals = new List<Animal>();

        Dog dog1 = new Dog("Dog", "Dogster", 7, "Steak");
        Puppy puppy1 = new Puppy("Puppy", "Bagster", 9, "Milk");
        Cat cat1 = new Cat("Cat", "Catster", 4, "Fish");
        Ball ball = new Ball();
        Store store = new Store();
        LotteryGame lottery1 = new LotteryGame();
        public Form1()
        {

            InitializeComponent();
            animals.Add(dog1);
            animals.Add(cat1);
            animals.Add(puppy1);
            loadRecentSavedData();
        }

        private void loadRecentSavedData()
        {
            using (StreamReader streamReader = new StreamReader("saveGame.txt"))
            {
                wallet = Convert.ToInt32(streamReader.ReadLine());    // set wallet from last saved data
                ball.Quality = Convert.ToInt32(streamReader.ReadLine());   // set quality for ball from last saved data
                ball.Color = streamReader.ReadLine(); // set color for ball from last saved data
                foreach (var animal in animals)
                {
                    string setHunger = streamReader.ReadLine(); // set hunger from last saved data

                    if (setHunger == "Not Hungry")
                    {
                        animal.setHunger = false;
                    }
                    else
                    {
                        animal.setHunger = true;
                    }

                }
                streamReader.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hideAllExtraButtons()
        {
            btnPlayWithDog.Visible = false;
            btn2PlayWithDog.Visible = false;
            btnChooseFoodSteak.Visible = false;
            btnChooseFoodFish.Visible = false;
            btnChooseFoodMilk.Visible = false;
            btn1SpecialAbilities.Visible = false;
            btn2SpecialAbilities.Visible = false;
            btn3DogSpecialAbilities.Visible = false;
            btn4DogSpecialAbilities.Visible = false;
            txtGuessNumberOnLottery.Visible = false;
            btnStoreRedBall.Visible = false;
            btnStoreYellowBall.Visible = false;
            btnStorePinkBall.Visible = false;
            btnStoreGoldBall.Visible = false;
            visitStoreNextPageOnAssortment.Visible = false;
            btnvisitStoreBuyBall.Visible = false;
            btnSaveGame.Visible = false;
            btnPrintPetInformationToFile.Visible = false;
            btnRestoreGame.Visible = false;
            lblpetOwnerInformation.Visible = false;
        }

        private void showRandomInformation() // list of information in lblpetOwnerInformation
        {
            lblpetOwnerInformation.Visible = true;
            List<string> viewInformationList = new List<string> {};
            viewInformationList.Add("You need to give your pets some food if you want to play with them");
            viewInformationList.Add("Sometimes you just loose your money");
            viewInformationList.Add("Try visit a contests!"); 
            viewInformationList.Add("Ever hunted a bear?? try to take your dog out for a bear hunt");
            viewInformationList.Add("be carefull, animals could have very sharp teeth and claws");
            viewInformationList.Add("try to Take your puppy out for a showcontest");
            viewInformationList.Add("Each pets have their own skill in special ability");
            viewInformationList.Add("rumors say that there is always a thief watching you next to the lottery");            

            Random random = new Random();
            int choosenRandomInformation = random.Next(0, viewInformationList.Count);
            lblpetOwnerInformation.Text = viewInformationList[choosenRandomInformation];


        }
        private void btnPetOwner_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (changeActionOnPetOwnerBtn == 1)
            {
                lblpetOwnerInformation.Visible = true;
                lblpetOwnerInformation.Text = "Hi! My name is Joppe. ï'm 42 Years old. I will take care of these animals";
                changeActionOnPetOwnerBtn = 0;
            }
            else
            {
                lblpetOwnerInformation.Text = null;
                lblpetOwnerInformation.Visible = false;
                changeActionOnPetOwnerBtn = 1;
            }
        }

        private void btnListAnimals_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            mainDisplay.Text = null;
            sideDisplay.Text = null;
            foreach (var pets in animals)
            {
                mainDisplay.Text += pets.ToString();
            }
        }

        private void btnPlayWithAnimal_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (sideDisplay.Text == dog1.NameOfTheAnimal)
            {
                if (dog1.Hungry() == "Not Hungry")
                {
                    btnPlayWithDog.Text = "Run";
                    btn2PlayWithDog.Text = "Dance";
                    btnPlayWithDog.Visible = true; // 2 buttons for dog/cat to play will be visible
                    btn2PlayWithDog.Visible = true;
                }
                else
                {
                    mainDisplay.Text = dog1.JustWantToEat();
                }
            }

            else if (sideDisplay.Text == cat1.NameOfTheAnimal)
            {
                if (cat1.Hungry() == "Not Hungry")
                {
                    btnPlayWithDog.Text = "Play";
                    btn2PlayWithDog.Text = "Pat";
                    btnPlayWithDog.Visible = true; // 2 buttons for dog/cat to play will be visible
                    btn2PlayWithDog.Visible = true;
                }
                else
                {
                    hideAllExtraButtons();// hide all food Buttons
                    mainDisplay.Text = cat1.JustWantToEat();
                }
            }
            else if (sideDisplay.Text == puppy1.NameOfTheAnimal)
            {
                if (puppy1.Hungry() == "Not Hungry")
                {
                    mainDisplay.Text = puppy1.Interact();
                    wallet += puppy1.EarnMoneyOnActivities;
                }
                else
                {
                    mainDisplay.Text = puppy1.JustWantToEat();
                }
            }
            else
            {
                mainDisplay.Text = "You need to choose a pet first!";
            }
        }

        private void btnPlayWithDog_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (sideDisplay.Text == dog1.NameOfTheAnimal)
            {
                mainDisplay.Text = dog1.Interact("RunAround");
                wallet += dog1.EarnMoneyOnActivities;
            }
            else
            {
                mainDisplay.Text = cat1.Interact("");
                wallet += cat1.EarnMoneyOnActivities;
            }
        }
        private void btn2PlayWithDog_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (sideDisplay.Text == dog1.NameOfTheAnimal)
            {
                mainDisplay.Text = dog1.Interact("Dance");
                wallet += dog1.EarnMoneyOnActivities;
            }
            else if (sideDisplay.Text == cat1.NameOfTheAnimal)
            {
                mainDisplay.Text = cat1.patCat();
                wallet += cat1.EarnMoneyOnActivities;
            }
        }

        private void btnPlayWithBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons

            if (sideDisplay.Text == dog1.NameOfTheAnimal || sideDisplay.Text == cat1.NameOfTheAnimal || sideDisplay.Text == puppy1.NameOfTheAnimal)
            {
                if (sideDisplay.Text == dog1.NameOfTheAnimal && dog1.Hungry() == "Not Hungry")
                {
                    mainDisplay.Text = dog1.Interact(ball);
                    wallet += dog1.EarnMoneyOnActivities;
                }
                else if (sideDisplay.Text == cat1.NameOfTheAnimal && cat1.Hungry() == "Not Hungry".ToString())
                {
                    mainDisplay.Text = cat1.Interact(ball);
                    wallet += cat1.EarnMoneyOnActivities;
                }
                else if (sideDisplay.Text == puppy1.NameOfTheAnimal && puppy1.Hungry() == "Not Hungry")
                {
                    mainDisplay.Text = puppy1.Interact(ball);
                    wallet += puppy1.EarnMoneyOnActivities;
                }
                else
                {
                    foreach (var pet in animals)
                    {
                        if (sideDisplay.Text == pet.NameOfTheAnimal)
                        {
                            mainDisplay.Text = pet.JustWantToEat();
                        }
                    }
                }
            }
            else
            {
                mainDisplay.Text = "You need to pick a pet first";
            }
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            mainDisplay.Text = store.loopThrowAssortmentFood();
            if (sideDisplay.Text == dog1.NameOfTheAnimal || sideDisplay.Text == cat1.NameOfTheAnimal || sideDisplay.Text == puppy1.NameOfTheAnimal)
            {
                btnChooseFoodSteak.Visible = true;
                btnChooseFoodFish.Visible = true;
                btnChooseFoodMilk.Visible = true;                
            }
            else
            {
                mainDisplay.Text = "You need to choose a pet you would like to feed..";
            }
        }
        private void btnChooseFoodSteak_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet >= (int)StorePantry.Steak)
            {
                if (sideDisplay.Text == dog1.NameOfTheAnimal)
                {
                    if (dog1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = dog1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (dog1.FavFood == StorePantry.Steak.ToString())
                    {
                        mainDisplay.Text = dog1.Eat(StorePantry.Steak.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Steak.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = dog1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Steak.ToString());
                    }
                }


                else if (sideDisplay.Text == cat1.NameOfTheAnimal)
                {
                    if (cat1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = cat1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (cat1.FavFood == StorePantry.Steak.ToString())
                    {
                        mainDisplay.Text = cat1.Eat(StorePantry.Steak.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Steak.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = cat1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Steak.ToString());
                    }
                }



                else
                {
                    if (puppy1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = puppy1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (puppy1.FavFood == StorePantry.Steak.ToString())
                    {
                        mainDisplay.Text = puppy1.Eat(StorePantry.Steak.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Steak.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = puppy1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Steak.ToString());
                    }
                }
            }
            else
            {
                mainDisplay.Text = "You don't have money for this one";
            }
        }

        private void btnChooseFoodFish_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet >= (int)StorePantry.Fish)
            {

                if (sideDisplay.Text == dog1.NameOfTheAnimal)
                {
                    if (dog1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = dog1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (dog1.FavFood == StorePantry.Fish.ToString())
                    {
                        mainDisplay.Text = dog1.Eat(StorePantry.Fish.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Fish.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = dog1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Fish.ToString());
                    }

                }
                else if (sideDisplay.Text == cat1.NameOfTheAnimal)
                {
                    if (cat1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = cat1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (cat1.FavFood == StorePantry.Fish.ToString())
                    {
                        mainDisplay.Text = cat1.Eat(StorePantry.Fish.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Fish.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = cat1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Fish.ToString());
                    }

                }
                else
                {
                    if (puppy1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = puppy1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (puppy1.FavFood == StorePantry.Fish.ToString())
                    {
                        mainDisplay.Text = puppy1.Eat(StorePantry.Fish.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Fish.ToString()); ;
                    }
                    else
                    {
                        mainDisplay.Text = puppy1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Fish.ToString());
                    }

                }
            }
            else
            {
                mainDisplay.Text = "You don't have money for this one";
            }
        }

        private void btnChooseFoodMilk_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet >= (int)StorePantry.Milk)
            {
                if (sideDisplay.Text == dog1.NameOfTheAnimal)
                {
                    if (dog1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = dog1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (dog1.FavFood == StorePantry.Milk.ToString())
                    {
                        mainDisplay.Text = dog1.Eat(StorePantry.Milk.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Milk.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = dog1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Milk.ToString());
                    }

                }
                else if (sideDisplay.Text == cat1.NameOfTheAnimal)
                {
                    if (cat1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = cat1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (cat1.FavFood == StorePantry.Milk.ToString())
                    {
                        mainDisplay.Text = cat1.Eat(StorePantry.Milk.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Milk.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = cat1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Milk.ToString());
                    }

                }
                else
                {
                    if (puppy1.Hungry() == "Not Hungry")
                    {
                        mainDisplay.Text = puppy1.NameOfTheAnimal + " don't want to eat right now";
                    }
                    else if (puppy1.FavFood == StorePantry.Milk.ToString())
                    {
                        mainDisplay.Text = puppy1.Eat(StorePantry.Milk.ToString());
                        wallet = store.BuyFood(wallet, StorePantry.Milk.ToString());
                    }
                    else
                    {
                        mainDisplay.Text = puppy1.HungryAnimals();
                        wallet = store.BuyFood(wallet, StorePantry.Milk.ToString());
                    }

                }
            }
            else
            {
                mainDisplay.Text = "You don't have money for this one";
            }
        }


        private void btnSpecialAbilities_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            lblpetOwnerInformation.Visible = true;
            lblpetOwnerInformation.Text = "You can always check the contest result more detailed in the files";

            if (sideDisplay.Text == dog1.NameOfTheAnimal)
            {
                if (dog1.Hungry() == "Not Hungry")
                {
                    btn1SpecialAbilities.Text = "Hunt";
                    btn2SpecialAbilities.Text = "Run Contest";
                    btn1SpecialAbilities.Visible = true;
                    btn2SpecialAbilities.Visible = true;
                }
                else
                {
                    foreach (var pet in animals)
                    {
                        if (sideDisplay.Text == pet.NameOfTheAnimal)
                        {
                            mainDisplay.Text = pet.JustWantToEat();
                        }
                    }
                }
            }
            else if (sideDisplay.Text == cat1.NameOfTheAnimal)
            {
                if (cat1.Hungry() == "Not Hungry")
                {
                    btn1SpecialAbilities.Text = "Hunt Birds";
                    btn2SpecialAbilities.Text = "Mouse Catch";
                    btn1SpecialAbilities.Visible = true;
                    btn2SpecialAbilities.Visible = true;
                }
                else
                {
                    foreach (var pet in animals)
                    {
                        if (sideDisplay.Text == pet.NameOfTheAnimal)
                        {
                            mainDisplay.Text = pet.JustWantToEat();
                        }
                    }
                }
            }
            else if (sideDisplay.Text == puppy1.NameOfTheAnimal)
            {
                if (puppy1.Hungry() == "Not Hungry")
                {
                    btn1SpecialAbilities.Text = "Hunt";
                    btn2SpecialAbilities.Text = "Pet Show";
                    btn1SpecialAbilities.Visible = true;
                    btn2SpecialAbilities.Visible = true;
                }
                else
                {
                    foreach (var pet in animals)
                    {
                        if (sideDisplay.Text == pet.NameOfTheAnimal)
                        {
                            mainDisplay.Text = pet.JustWantToEat();
                        }
                    }
                }
            }
            else
            {
                mainDisplay.Text = "Please choose pet first";
            }
        }

        private void btnClearSideDisplay_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            sideDisplay.Text = null;
        }

        private void btnDog_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            showRandomInformation();
            mainDisplay.Text = "What do you want to do?";
            sideDisplay.Text = dog1.NameOfTheAnimal;
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            showRandomInformation();
            mainDisplay.Text = "What do you want to do?";
            sideDisplay.Text = cat1.NameOfTheAnimal;
        }

        private void btnPuppy_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            showRandomInformation();
            mainDisplay.Text = "What do you want to do?";
            sideDisplay.Text = puppy1.NameOfTheAnimal;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons

            btnvisitStoreBuyBall.Visible = true;
            if (wallet == 0)
            {
                mainDisplay.Text = "Your out of money " + newLine + "Welcome back later" + newLine + newLine + "We can give you $70";
                wallet = wallet + 70;
            }
            else
                mainDisplay.Text = store.loopThrowAssortmentFood();
            visitStoreNextPageOnAssortment.Visible = true;

        }
        private void visitStoreNextPageOnAssortment_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            btnvisitStoreBuyBall.Visible = true;
            mainDisplay.Text = store.LoopThrowAssortmentBall();
        }

        private void btnCheckBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons

            if (ball.Quality == 0)
            {
                mainDisplay.Text = "You have no ball" + newLine + newLine + "Visit Store to buy a ball!";
            }
            else
            {
                mainDisplay.Text = ball.ToString();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            btnSaveGame.Visible = true;
            btnPrintPetInformationToFile.Visible = true;
            btnRestoreGame.Visible = true;
            mainDisplay.Text = "Warning" + newLine + "Restore game will" + newLine + "erase all your " + newLine + "saved data";

        }


        private void btnPrintPetInformationToFile_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();
            using (StreamWriter streamWriter = new StreamWriter("animalInformation.txt"))
            {
                foreach (var animals in animals)
                {
                    streamWriter.WriteLine(animals);
                }
                streamWriter.Close();
            }
            mainDisplay.Text = "A file named animalInformation.txt is now created/Updated";
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();
            mainDisplay.Text = "Data has been saved..";
            using (StreamWriter streamWriter = new StreamWriter("saveGame.txt")) // writing data to file saveGame.txt
            {
                streamWriter.WriteLine(wallet); // save data from wallet
                streamWriter.WriteLine(ball.Quality); // save data from quality of ball
                streamWriter.WriteLine(ball.Color); // save data from color of ball
                foreach (var animal in animals)  // save data about hunger
                {
                    streamWriter.WriteLine(animal.Hungry());
                }
                streamWriter.Close();
            }
        }

        private void btnRestoreGame_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();
            wallet = 200; // Restoring wallet to default
            using (StreamWriter streamWriter = new StreamWriter("saveGame.txt")) // update the saveGame.txt file and restore the data
            {
                streamWriter.WriteLine(wallet); // set up the default values
                streamWriter.WriteLine(20); // Quality for ball - default "20"
                streamWriter.WriteLine("Red"); // Color for ball - deafult "Red"
                foreach (var animal in animals)
                {
                    animal.setHunger = false; // set hunger to false on all animals
                    streamWriter.WriteLine(animal.Hungry());
                }
                streamWriter.Close();
            }
            mainDisplay.Text = "New game started!";
            sideDisplay.Text = null;
            loadRecentSavedData();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void sideDisplay_MouseLeave(object sender, EventArgs e)
        {
            if (sideDisplay.Text == dog1.NameOfTheAnimal || sideDisplay.Text == cat1.NameOfTheAnimal || sideDisplay.Text == puppy1.NameOfTheAnimal)
            {
                //this codeblock is just for, to block the else code start auto.
            }
            else
            {
                Random rnd = new Random();
                int random = rnd.Next(1, 4);
                if (random == 1)
                {
                    sideDisplay.Text = "Dog wants to race";
                }
                else if (random == 2)
                {
                    sideDisplay.Text = "puppy wants to dress up";
                }
                else
                {
                    sideDisplay.Text = "cat want to catch mouse";
                }
            }
        }

        private void btnShowHungerDog_Click(object sender, EventArgs e)  // Show status of hunger in homescreen
        {
            if (changeActionOnShowHungerBtn == 1)
            {
                btnShowHungerDog.Text = dog1.BreedOfTheAnimal + ", " + dog1.Hungry() + newLine + newLine + cat1.BreedOfTheAnimal + ", " + cat1.Hungry() + newLine + newLine + puppy1.BreedOfTheAnimal + ", " + puppy1.Hungry();
                changeActionOnShowHungerBtn = 0;
            }
            else
            {
                btnShowHungerDog.Text = "Show Hunger Status";
                changeActionOnShowHungerBtn = 1;
            }
        }
        private void btnCleanDisplay_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            mainDisplay.Text = null;
        }

        private void btnWallet_Click_1(object sender, EventArgs e)
        {
            btnPlayWithDog.Visible = false; //Hide dogs extra playbuttons
            btn2PlayWithDog.Visible = false;

            if (changeActionOnWalletBtn == 0)
            {
                btnWallet.Text = " Wallet";
                changeActionOnWalletBtn = 1;
            }
            else
            {
                btnWallet.Text = " $" + wallet;
                changeActionOnWalletBtn = 0;
            }
        }

        private void btnvisitStoreBuyBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            btnStoreRedBall.Visible = true;
            btnStoreYellowBall.Visible = true;
            btnStorePinkBall.Visible = true;
            btnStoreGoldBall.Visible = true;
            mainDisplay.Text = "____________" + newLine + "Choose" + newLine + "color" + newLine + "On" + newLine + "Ball" + newLine + "____________";
        }

        private void btnStoreRedBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet >= (int)StorePantry.Red)
            {
                wallet = store.BuyBall(wallet, StorePantry.Red.ToString());
                ball.Color = StorePantry.Red.ToString();
                ball.Quality = 20;
                mainDisplay.Text = "You bought a " + ball.Color + " Ball";
            }
            else
            {
                mainDisplay.Text = "You don't have enough money";
            }
        }

        private void btnStoreYellowBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet >= (int)StorePantry.Yellow)
            {
                wallet = store.BuyBall(wallet, StorePantry.Yellow.ToString());
                ball.Color = StorePantry.Yellow.ToString();
                ball.Quality = 20;
                mainDisplay.Text = "You bought a " + ball.Color + " Ball";
            }
            else
            {
                mainDisplay.Text = "You don't have enough money";
            }
        }

        private void btnStorePinkBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet >= (int)StorePantry.Pink)
            {
                wallet = store.BuyBall(wallet, StorePantry.Pink.ToString());
                ball.Color = StorePantry.Pink.ToString();
                ball.Quality = 20;
                mainDisplay.Text = "You bought a " + ball.Color + " Ball";
            }
            else
            {
                mainDisplay.Text = "You don't have enough money";
            }
        }

        private void btnStoreGoldBall_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            btnStoreGoldBall.Visible = false;
            if (wallet >= (int)StorePantry.Gold)
            {
                wallet = store.BuyBall(wallet, StorePantry.Gold.ToString());
                ball.Color = StorePantry.Gold.ToString();
                ball.Quality = 20;
                mainDisplay.Text = "You bought a " + ball.Color + " Ball";
            }
            else
            {
                mainDisplay.Text = "You don't have enough money";
            }
        }

        private void btn1SpecialAbilities_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            lblpetOwnerInformation.Text = "";
            btn1SpecialAbilities.Visible = true;
            btn2SpecialAbilities.Visible = true;

            if (sideDisplay.Text == dog1.NameOfTheAnimal)
            {
                btn3DogSpecialAbilities.Visible = true;
                btn4DogSpecialAbilities.Visible = true;
            }
            else if (sideDisplay.Text == cat1.NameOfTheAnimal)
            {                
                mainDisplay.Text = cat1.HuntBird();
                wallet += cat1.EarnMoneyOnActivities;
                btn1SpecialAbilities.Visible = false;
                btn2SpecialAbilities.Visible = false;
            }
            else
            {
                mainDisplay.Text = puppy1.GoHunt();
                wallet += puppy1.EarnMoneyOnActivities;
                btn1SpecialAbilities.Visible = false;
                btn2SpecialAbilities.Visible = false;
            }
        }

        private void btn2SpecialAbilities_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            lblpetOwnerInformation.Text = "";
            if (sideDisplay.Text == dog1.NameOfTheAnimal)
            {
                if (wallet >= 30)
                {
                    mainDisplay.Text = dog1.RunningContest();
                    wallet += dog1.EarnMoneyOnActivities;
                }
                else
                {
                    mainDisplay.Text = "You need $30 to participate";
                }
            }
            else if (sideDisplay.Text == cat1.NameOfTheAnimal)
            {
                if (wallet >= 30)
                {
                    mainDisplay.Text = cat1.MouseCatchContest();
                    wallet += cat1.EarnMoneyOnActivities;
                }
                else
                {
                    mainDisplay.Text = "You need atleast $30 to participate";
                }
            }
            else
            {
                if (wallet >= 50)
                {
                    mainDisplay.Text = puppy1.PuppyShow();
                    wallet += puppy1.EarnMoneyOnActivities;
                }
                else
                {
                    mainDisplay.Text = "You need $50 to participate";
                }
            }
        }

        private void btn3DogSpecialAbilities_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = dog1.GoHunt("Roedeer");
            wallet += dog1.EarnMoneyOnActivities;
            hideAllExtraButtons();
        }

        private void btn4DogSpecialAbilities_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = dog1.GoHunt("Bear");
            wallet += dog1.EarnMoneyOnActivities;
            hideAllExtraButtons();
        }

        private void btnLotteryGame_Click(object sender, EventArgs e)
        {
            hideAllExtraButtons();// hide all food Buttons
            if (wallet < 10)
            {
                mainDisplay.Text = "You need to atleast $10 to participate" + newLine + " welcome back another time";
            }
            else
            {
                txtGuessNumberOnLottery.Visible = true;
                mainDisplay.Text = "Win up to $200 " + Environment.NewLine + "To particiapte: $10 per game" + newLine + "_______________________" + newLine +
                    "Guess the number" + newLine + "You have one clue " + newLine +
                    " it is between the numbers 1 - 8" + newLine +
                    "watch out for the thief" + newLine;
            }
        }

        private void txtGuessNumberOnLottery_KeyDown(object sender, KeyEventArgs e) // user enter the guessed value in textbox
        {

            int guessNumber = 0;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    guessNumber = Convert.ToInt32(txtGuessNumberOnLottery.Text);
                }
                catch
                {
                    mainDisplay.Text = "Only numbers 1 to 8" + newLine + "Try again";
                    txtGuessNumberOnLottery.Visible = false;

                }
                if (guessNumber > 0 && guessNumber < 9)
                {
                    wallet = wallet - 10; // cost 10 to participate in lottery
                    txtGuessNumberOnLottery.Visible = false;
                    mainDisplay.Text = lottery1.RunLotteryGame(guessNumber);
                    wallet += lottery1.WinLottery;
                }
                else
                {
                    mainDisplay.Text = "Only numbers 1 to 8" + newLine + "Try again";
                    txtGuessNumberOnLottery.Visible = false;
                }
            }
        }

        private void txtGuessNumberOnLottery_MouseHover(object sender, EventArgs e)
        {
            txtGuessNumberOnLottery.Text = null;
        }

        private void txtGuessNumberOnLottery_MouseLeave(object sender, EventArgs e)
        {
            txtGuessNumberOnLottery.Text = "Guess number here";
        }
    }
}
