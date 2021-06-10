using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescue_Game
{

    public class Game
    {
        public World World { get; set; }
        bool invalidInput = true;
        string userInput;

        public void Play()
        {
            Console.WriteLine("Welcome to Text Adventure, " +
                              "prepare yourself for a challenging task... " +
                              "\n Please type in your Players name: ");
             World.Player.PlayerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome " + World.Player.PlayerName + "!\nYour challenge takes place in a big house that is set on fire." +
                " Is there someone inside who needs to be rescued? \nYou are carrying an empty bag. ");
            World.Player.Look("LOOK");
            do
            {
                do
                {
                    GiveCommand(); 
                    Console.Clear();
                 
                    CheckValidWord(userInput); 

                } while (invalidInput); 

                CheckCommand(userInput);                         

            } while (World.Player.Alive == true);

        }
        public void CheckCommand(string userInput)
        {
            string text = userInput;
            string[] inputs = text.Split(' '); //separator, StringSplitOptions.RemoveEmptyEntries);
            bool command = true;

            while (command)
            {
                if (inputs[0].ToString() == "MOVE")
                {
                    World.Player.SearchDoor(userInput);
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "TAKE")
                {
                    World.Player.Take(inputs[1]); 
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "DROP")
                {
                    World.Player.DropItem(inputs[1]);
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "USE")
                {
                    World.Player.Use(userInput);
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "INSPECT")
                {
                    World.Player.InspectItem(inputs[1]);
                    command = false;
                    break;
                }
                if (inputs[0].ToString() == "GIVE")
                {
                    World.Player.Give(userInput);
                    command = false;
                    break;
                }
                if (inputs[0].ToString() == "LOOK")
                {
                    World.Player.Look("LOOK");
                    GiveCommand();
                    command = false;
                    break;
                }
            }
        }
        private void CheckOneWord(string input)
        {
            string text = input.ToUpper();
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length < 2)
            {
                OneCommand(input);
            }
        }

        private void OneCommand(string input)
        {
            List<string> oneWord = new List<string>() { "help", "quit", "look" };

            string value = input;
            switch (value)
            {
                case "HELP":
                    Console.WriteLine("As a command you can use: " +
                        "\nMOVE FORWARD/BACKWARD, TAKE ITEM, USE ITEM, " +
                        "INSPECT ITEM, DROP ITEM, LOOK ");
                    GiveCommand();
                    break;

                case "QUIT":
                    Console.WriteLine("See you later!");
                    World.Player.Alive = false;
                    break;

                case "LOOK":
                    Console.WriteLine();
                    World.Player.Look(input);
                    GiveCommand();
                    break;
            }

            if (input != "HELP" && input != "QUIT" && input != "LOOK")
            {
                Console.WriteLine(@"Invalid command, try again. Enter ""help"" if you need guidance");
                GiveCommand();
            }

        }

        private void GiveCommand()
        {
            Console.WriteLine("\nType in your next move");
            userInput = Console.ReadLine().ToUpper();
            string text = userInput.ToUpper();
            string[] inputs = text.Split(' ');

            if (inputs.Length == 1)
            {
                OneCommand(userInput);

            }

            if (inputs.Length == 4)
            {
                FourCommands(userInput);

            }
        }

        private void FourCommands(string input)
        {
            string text = input.ToUpper();
            //char[] separator = new char[] { (' ') };
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> validinputs = new List<string>(); // Lista med giltiga ord. 
            validinputs.Add("USE");
            validinputs.Add("KEY");
            validinputs.Add("APPLE");
            validinputs.Add("DOOR");
            validinputs.Add("ON");
            validinputs.Add("CAT");
            List<string> wordsToInterpret = new List<string>(); // lista för att spara de "rätta" orden

            foreach (string e in validinputs)
            {
                if (e == inputs[0])
                {
                    wordsToInterpret.Add(e);
                }
                if (e == inputs[1])
                {
                    wordsToInterpret.Add(e);
                }
                if (e == inputs[3])  
                {
                    wordsToInterpret.Add(e);
                }

            }
            if (wordsToInterpret.Count <= 3)
            {
                invalidInput = false;
            }
        }

        private void CheckValidWord(string input)
        {
            string text = input.ToUpper();
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> validInputs = new List<string>();

            List<string> validinput = new List<string>(); // Lista med giltiga ord. 
            validinput.Add("MOVE");
            validinput.Add("FORWARD");
            validinput.Add("BACKWARD");
            validinput.Add("TAKE");
            validinput.Add("USE");
            validinput.Add("DROP");
            validinput.Add("KEY");
            validinput.Add("APPLE");
            validinput.Add("INSPECT");
            validinput.Add("LOOK");
            validinput.Add("DOOR");
            validinput.Add("HAMMER");
            validinput.Add("CAT");
            validinput.Add("GIVE"); //use item on item Give Cat an apple

            foreach (string e in validinput)
            {

                if (e == inputs[0])
                {
                    validInputs.Add(e);

                    foreach (string f in validinput)
                    {
                        if (f == inputs[1])
                        {
                            validInputs.Add(f);
                        }
                    }
                }
            }
            if (!validinput.Contains(inputs[0]))
            {
                Console.WriteLine("As a command you can use: " +
                    "\nMOVE FORWARD/BACKWARD, TAKE ITEM, USE ITEM, " +
                    "INSPECT ITEM, DROP ITEM, LOOK ");
                GiveCommand();
            }

            if (validInputs.Count <= 2)
            {
                invalidInput = false;
            }

        }

        internal void SetUp()
        {
            //Create World
            WorldCreator creator = new WorldCreator();
            World = creator.BuildWorld();

        }
    }
}
