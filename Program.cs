using System;

namespace Csharp_Montyhall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Monty Hall Probability Simulator Engine!");
            Console.WriteLine("Created by N.R.\n");

            int menuSel = 0;
            int runNum = 0; int doorPick = 0;
            while (menuSel == 0)
            {
                DisplayMenu();
                menuSel = GetInput(10);

                switch (menuSel){
                    case 1:
                        Console.WriteLine("\n");  GameMode1();
                        menuSel = 0; BetweenChoices();
                        break;
                    case 2:
                        Console.WriteLine("\n"); GameMode2(); 
                        menuSel = 0; BetweenChoices();
                        break;
                    case 3:
                        Console.WriteLine("\n"); GameMode1(DoorChoice());
                        menuSel = 0; BetweenChoices();
                        break;
                    case 4:
                        Console.WriteLine("\n"); GameMode2(DoorChoice());
                        menuSel = 0; BetweenChoices();
                        break;
                    case 5:
                        Console.WriteLine("\n");
                        runNum = GameMode2();   GameMode1(3, runNum);
                        menuSel = 0; BetweenChoices();
                        break;
                    case 6:
                        Console.WriteLine("\n");
                        doorPick = DoorChoice();
                        runNum = GameMode2(doorPick); GameMode1(doorPick, runNum); 
                        menuSel = 0; BetweenChoices();
                        break;
                    case 8:
                        Console.WriteLine("\n");  DispExplain();  
                        menuSel = 0; BetweenChoices();
                        break;
                    case 9:
                        Console.WriteLine("\n"); DispExplain2();
                        menuSel = 0; BetweenChoices();
                        break;
                    case 10:
                        Console.WriteLine("\n\n\nThe End. \nPress <ENTER> to exit program.");
                        break;
                    default:
                        Console.WriteLine("\n"); menuSel = 0;
                        break;
                }
            }
            Console.ReadLine();
            // End of program.
        }

        public static void BetweenChoices()
        {
            Console.WriteLine("\nPress <ENTER> to continue.");
            Console.ReadLine();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Please make your selection from the options below:");
            Console.WriteLine("1)  3 doors.  Select the # of trials");
            Console.WriteLine("2)  3 doors, with choice switching.  Select the # of trials");
            Console.WriteLine("3)  Select the # of doors. Select the # of trials");
            Console.WriteLine("4)  Select the # of doors, with choice switching. Select the # of trials");
            Console.WriteLine("5)  3 doors.  Select # of trials, and compare results with/without switching.");
            Console.WriteLine("6)  Select # of doors and trials.  Compare results with/without switching.");
            Console.WriteLine("8)  What is the Monty Hall problem?");
            Console.WriteLine("9)  Why is switching superior?");
            Console.WriteLine("10)  <QUIT>");
        }

        public static void DispExplain()
        {
            Console.WriteLine("The Monty Hall problem is a brain teaser.\n");
            Console.WriteLine("Suppose you're on a game show, and you're given the choice of three doors. \nBehind one door is a prize.  Behind the others, nothing. \n" +
                "\nLets say you pick door No. 1.  \nThe host(who knows what's behind the doors) opens door No. 3, which has nothing.");
            Console.WriteLine("He then says to you, \"Do you want to pick door No. 2 instead?\" \nIs it to your advantage to switch your choice?\n");
            Console.WriteLine("It turns out, it IS to your advantage to switch your door choice.\nIt was mathmatically proven in 1975, for the show Lets Make A Deal.");
            Console.WriteLine("But despite the evidence, people refused to believe it!!  \nThis program simulates various Monty Hall choices, many many times, \nand displays the results.");
            Console.WriteLine("\nWhat you believe is up to you, but here you can see the odds play out.  \nGood Luck!");
        }

        public static void DispExplain2()
        {
            Console.WriteLine("\nWhy is switching the superior option?\n");
            Console.WriteLine("To start with, there is one prize and 3 doors.  A 1 in 3 chance of victory.");
            Console.WriteLine("When the host reveals a door, it is never the prize door, so he effectively eliminates a wrong choice");
            Console.WriteLine("\nIf you guessed the prize initially (a 1 in 3 chance), you are left with 2 bad choices.\nThe host will eliminate one of the 2 bad choices, and offer you the other losing option.");
            Console.WriteLine("\nIf you guessed incorrectly initially(a 2 in 3 chance), you are left with a good choice and a bad choice.\nThe host will eliminate the bad choice, and offer you the winning choice");
            Console.WriteLine("\nSo if your first guess is correct(1/3), switching loses.  If your first guess is wrong(2/3), switching wins");
            Console.WriteLine("Therefore if you always switch, you have a 1 in 3 chance to fail, and a 2 in 3 chance of success.\nThe host has doubled your chances of victory!");
        }

            public static int NotThisDoor(int firstPick, int newPick, int doorNum)
        {   // the player's first guess was correct
            // sent the door the player picked, a number less than #_of_doors, and #_of_doors.
            // picks a new door for the player
            int notDoor = 0; int thisDoor = 0;
            for (int x = 1; x <= doorNum; x++)
            {
                if (x != firstPick)
                {
                    newPick--;
                    if (newPick == 0)
                    {
                        thisDoor = x;
                    }
                    else
                    {
                        notDoor = x;
                    }
                }
            }
            return (thisDoor);  // function returns the player's new selection.
        }

        public static int OnlyThisDoor(int firstPick, int tresPick, int newPick, int doorNum, int notHere)
        {   // the player's first guess was incorrect
            // sent the door the player picked, the door with treasure, the number of doors
            // newPick is a random number from 1 to (number of doors -2).  notHere is where the host says there is no prize
            int notDoor = 0; int thisDoor = 0;
            // Pick door the treasure is not behind.
            for (int x = 1; x <= doorNum; x++)
            {  
                if (x != firstPick){
                    if(x != tresPick){
                        notHere--;
                        if(notHere == 0)
                        {
                            notDoor = x;  // Host says the treasure is not here.
                        }
                    }
                }
            }
            for (int y = 1; y <= doorNum; y++){
                if (y != firstPick){
                    if (y != notDoor){
                        newPick--;
                        if (newPick == 0){
                            thisDoor = y;  // Player switches to this door.
                        }
                    }
                }
            }
            return (thisDoor);  // function returns the player's new selection.
        }

        public static int DoorChoice()
        {   
            string userInput = "";
            bool validNum = false;
            int userNum = 0;
            Console.WriteLine("Please choose the # of doors for each trial (minimum of 3)");

            while (validNum == false)
            {
                userInput = Console.ReadLine();
                try
                {
                    userNum = Convert.ToInt32(userInput);
                    if (userNum <= 2)
                    {
                        Console.WriteLine("Invalid Entry.  \nPositive whole numbers 3 or greater.\n");
                    }
                    else
                    {
                        validNum = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Entry.  \nPositive whole numbers 3 or greater.\n");
                }

            }
            Console.WriteLine("You have chosen {0} doors", userNum);
            return(userNum);
        }

        public static int GameMode2(int doorNumber = 3, int loopRuns = 0)
        {   // doorNumber is the total number of doors.
            Random myRnd = new Random();
            int guessDoor = -1;  // number of the door with the loot
            // loopsRuns = # of loops to run before calculating probability
            int playGuess = 0;  // Door the player has guessed.
            double correctGuess = 0;
            int secondGuess = 0;  // players guess when one of two remaining doors is eliminated.
            int hostDeclaration = 0;  // The host says it is not in this door.

            if (loopRuns <= 0)
            {
                Console.WriteLine("Enter the number of trials to run");
                loopRuns = GetInput();
            }
            for (int d = 1; d <= loopRuns; d++)
            {
                guessDoor = myRnd.Next(1, doorNumber + 1);
                playGuess = myRnd.Next(1, doorNumber + 1);
                
                if (guessDoor == playGuess)
                {   // player guessed correctly on the first try
                    secondGuess = myRnd.Next(1, doorNumber);  // guesses a number from 1 to (number of doors -1).  Can't be first guess.
                    playGuess = NotThisDoor(playGuess, secondGuess, doorNumber);
                }
                else
                {   // the player's first guess was incorrect
                    hostDeclaration = myRnd.Next(1, doorNumber - 1);  // guesses a number from 1 to (number of doors -1).  Can't be first guess, can't be treasure
                    secondGuess = myRnd.Next(1, doorNumber - 1);  // guesses a number from 1 to (number of doors -2).  Can't be first guess, can't be host declaration
                    playGuess = OnlyThisDoor(playGuess, guessDoor, secondGuess, doorNumber, hostDeclaration);
                }

                if (guessDoor == playGuess)
                {
                    correctGuess++;
                }
            }
            Console.WriteLine("\n{0} trials run, with {1} doors.  Player switches their choice", loopRuns, doorNumber);
            Console.WriteLine("Guessed Correctly: {0} times.  Success Rate = {1} %\n", correctGuess, correctGuess / loopRuns);
            return (loopRuns);
        }

        public static int GameMode1(int doorNumber = 3, int loopRuns = 0)
        {   // This game mode:  Player picks # of trials.  Each trial, the door is guessed, and if treasure is found -> success recorded.
            Random myRnd = new Random();
            int guessDoor = -1;  // number the door with the loot
            // loopRuns = # of loops to run before calculating probability
            int playGuess = 0;  // Door the player has guessed.
            double correctGuess = 0;

            if(loopRuns <= 0) { 
                Console.WriteLine("Enter the number of trials to run");
                loopRuns = GetInput();
            }
            for (int d = 1; d < loopRuns; d++)
            {
                guessDoor = myRnd.Next(1, doorNumber + 1);
                playGuess = myRnd.Next(1, doorNumber + 1);

                if (guessDoor == playGuess)
                {
                    correctGuess++;
                }
            }
            Console.WriteLine("\n{0} trials run, with {1} doors.  No switching of first choice", loopRuns, doorNumber);
            Console.WriteLine("Guessed Correctly: {0} times.  Success Rate = {1} %\n", correctGuess, correctGuess / loopRuns);
            return (loopRuns);
        }

        public static int GetInput(int maxRange = 0)
        {   // Asks the user for a number.  Rejects any non-numbers, zero, or negative values.
            // Returns a number from 1 to maxRange.
            string userInput = "";
            bool validNum = false;
            int userNum = 0;

            while (validNum == false)
            {
                userInput = Console.ReadLine();
                try
                {
                    userNum = Convert.ToInt32(userInput);
                    if (userNum <= 0)
                    {
                        Console.WriteLine("Invalid Entry.  \nPositive numbers only.\n");
                    }
                    else if (maxRange > 0 && userNum > maxRange)
                    {
                        Console.WriteLine("Invalid Entry.  \nNumbers from 1 to {0} only.\n", maxRange);
                    }
                    else
                    {
                        validNum = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Entry.  \nPositive numbers only.\n");
                }

            }
            return (userNum);
        }
    }
}
