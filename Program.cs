using System;
using System.Collections.Generic;

namespace Dheer_sProjectAdventureGame
{

    class Item
    {
        private string name;
        private string description;

        public Item(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void printValues()
        {

            Console.WriteLine("Item name is " + name);
            Console.WriteLine("Item description is " + description);
        }

        public string getName()
        {
            return name;
        }

        public string getDescription()
        {
            return description;
        }

    }

    class Tool : Item
    {
        private string ability;

        public Tool(string name, string description, string ability) : base(name, description)
        {
            this.ability = ability;
        }


        public void printValues()
        {

            Console.WriteLine("Item name is " + getName());
            Console.WriteLine("Item description is " + getDescription());
            Console.WriteLine("Item Ability is " + getAbility());
        }

        public string getAbility()
        {
            return ability;
        }
    }

    class Game
    {

        public static void Dialog(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("Welcome to the Adventure Game");
            Console.WriteLine("Enjoy your time");
            Console.ResetColor();
            return;

        }

        public static void Dialog()
        {
            string first;
            string last;


            Console.WriteLine("Enter First Name");
            first = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            last = Console.ReadLine();

            Console.WriteLine("Great! Good Choice " + first + " " + last);
            return;
        }

        public static int LevelUp(int level, Boolean isNewb)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (isNewb == true && level < 50)
            {
                level += 2;
                Console.WriteLine("You found a gem! \nYou leveled up twice! Your current level is " + level);
            }
            if (isNewb == false || level < 80)
            {
                level += 2;
                Console.WriteLine("You found a holy bone! \nYou leveled up twice! Your current level is " + level);
            }
            if (isNewb == false && isNewb != true)
            {
                level++;
                Console.WriteLine("You contract your inner power! \nYou leveled up! Your current level is " + level);
            }

            Console.ResetColor();
            return level;
        }

        public static Boolean LevelGenerator()
        {
            Boolean isNewb = false;

            Random randomNumber = new Random();
            int level = randomNumber.Next(100);

            Console.WriteLine("Your level is : " + level);

            if (level <= 25)
            {
                Console.WriteLine("You are a Newb!");
                isNewb = true;
            }
            else if (level <= 50)
            {
                Console.WriteLine("You are a Beginner!");
                isNewb = true;
            }
            else if (level <= 75)
            {
                Console.WriteLine("You are a Professional!");
                isNewb = false;
            }
            else
            {
                Console.WriteLine("You are a Master!");
                isNewb = false;
            }

            level = LevelUp(level, isNewb);

            return isNewb;
        }

        public static void ObtainPet(int choice, int petcount, string[] petnames)
        {
            int replysize = 3;

            string[] ReplyArray =
            {
                "Choose a Pet name", //0

                "You are going Path Fire...",
                "Congrats! You got a pet, He is a Lion",
                " ", //1-3 = choice 1

                "You are going Path Water...",
                "Congrats! You got a pet, He is a Gorilla",
                " ", //4-6 = choice 2

                "You are going Path Earth...",
                "Congrats! You got a pet, He is a Bear",
                " ", //6-9 = choice 3

                "You are going Path Wind...",
                "Congrats! You got a pet, He is a Eagle",
                " ", //10-12 =  choice 4

                ".",
                ".",
                "." //13-15 = choice 5

            };


            Console.WriteLine(ReplyArray[0]);
            ReplyArray[choice * replysize] = Console.ReadLine();
            petnames[petcount] = ReplyArray[choice * replysize];
            ReplyArray[(choice * replysize)] += " is ready to follow you on your adventure!";



            for (int i = ((choice * replysize) - 2); i < ((choice * replysize)); i++)
            {
                Console.WriteLine(ReplyArray[i]);
            }

            return;

        }

        public static void TrainPet(string[] petnames)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string input;

            for (int i = 0; i < petnames.Length; i++)
            {
                Console.WriteLine("Do you want to train your pet " + petnames[i] + "?");
                input = Console.ReadLine();
                input = input.ToLower();

                if (input == "yes")
                {
                    Console.WriteLine("Your pet " + petnames[i] + " is training and just leveled up!");
                }
                else
                {
                    Console.WriteLine("Your pet " + petnames[i] + " is sleeping and his heatlh is rested!");
                }
            }

            Console.ResetColor();
        }

        public static void PlayerChoice()
        {
            const int petpartysize = 4;
            string[] elements = { "fire", "water", "earth", "wind" };
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Yellow };

            string input = "";
            string[] petnames = new string[petpartysize];

            Console.WriteLine("You need to choose " + petpartysize + " paths, you get a pet with each one");
            for (int counter = 0; counter < petpartysize; counter++)
            {

                Console.WriteLine("Choose a Path: Fire / Water / Earth / Wind?");

                input = Console.ReadLine();
                input = input.ToLower();

                while (!(input.Equals("fire") || input.Equals("water") || input.Equals("earth") || input.Equals("wind")))
                {
                    Console.WriteLine("Wrong Choice, Please try");
                    input = Console.ReadLine();
                    input = input.ToLower();
                }

                for (int i = 0; i < elements.Length; i++)
                {
                    if (input.Equals(elements[i]))
                    {
                        Console.ForegroundColor = colors[i];
                        ObtainPet((i + 1), counter, petnames);
                        Console.ResetColor();
                    }
                }

            }

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Your Pets are : ");
            for (int i = 0; i < petnames.Length; i++)
            {
                Console.WriteLine("Pet " + (i + 1) + " is " + petnames[i]);
            }

            Console.ResetColor();

            TrainPet(petnames);


        }

        public static void FillItems()
        {
            int size = 5;

            Random randomNumber = new Random();

            List<Tool> Inventory = new List<Tool>();

            string tempName;
            string tempDescription;
            string tempAbility;
            int tempNumber;
            Tool tempItem;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Add items to the game, 3 items will be randomized to your inventory");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter Item Name " + (i + 1));
                tempName = Console.ReadLine();

                Console.WriteLine("Enter Item Description " + (i + 1));
                tempDescription = Console.ReadLine();

                Console.WriteLine("Enter Item Ability " + (i + 1));
                tempAbility = Console.ReadLine();

                tempItem = new Tool(tempName, tempDescription, tempAbility);
                Inventory.Add(tempItem);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("You have the following items that were randomized by us");

            /*foreach (Item item in Inventory)
            {
                Console.WriteLine("Item Name ");
                Console.WriteLine(item.name);
                Console.WriteLine("Item Description ");
                Console.WriteLine(item.description);
            }*/

            for (int i = 0; i < 3; i++)
            {
                tempNumber = randomNumber.Next(size);
                Console.WriteLine("Random Number" + (tempNumber + 1));
                Inventory[tempNumber].printValues();
            }

            Console.ResetColor();



        }

        public static void startGame()
        {
            Dialog(ConsoleColor.Magenta);
            Console.WriteLine("");
            Dialog();
            Console.WriteLine("");
            LevelGenerator();
            Console.WriteLine("");
            PlayerChoice();
            Console.WriteLine("");
            FillItems();
            Console.WriteLine("");
            Program.goal = true;
        }
    }

    class Program
    {
        public static bool goal = false;
        public static bool run = true;
        static int choice = 0;


        public static void Menu()
        {
            string tempchoice;
            Console.WriteLine("Would you like to start the game?");
            Console.WriteLine("Press 1 to Start the game");
            Console.WriteLine("Press 2 to Exit the game");
            tempchoice = Console.ReadLine();
            choice = Convert.ToInt32(tempchoice);

            switch (choice)
            {
                case 1:
                    Play();
                    break;

                case 2:
                    Exit();
                    break;

                default:
                    Console.WriteLine("Wrong Answer");
                    Menu();
                    break;


            }
        }

        public static void Play()
        {
            Game.startGame();
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Have a Good Day :)");
            Console.ResetColor();
            run = false;
            return;
        }



        static void Main(string[] args)
        {

            while (run == true)
            {
                if (goal == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("");
                    Console.WriteLine("Congrats on finishing the game!");
                    Console.WriteLine("You can always start another game!");
                    Console.ResetColor();
                    Menu();
                }
                else
                {
                    Menu();
                }
            }


        }
    }
}
