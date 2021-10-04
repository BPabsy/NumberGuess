using System;
using System.Threading;

namespace NumberGuess
{
    class Program
    {
        private static string playerName;
        private static int correctNumber;
        private static int userGuess;
        private static int maxRange;
        private static string currentDifficulty;
        private static int attemptCount = 0;
        private static bool playAgain = true;

        private static void PlayerName()
        {
            Console.WriteLine("Please enter your name.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            playerName = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("Welcome {0}.", playerName);
        }

        private static void SetDifficulty()
        {
            int easy = 5;
            int medium = 10;
            int hard = 50;
            int impossible = 10000;
            string userInput;

            Console.WriteLine("Enter 'E' for Easy, 'M' for Medium, 'H' for Hard, or 'I' for Impossible");
            Console.ForegroundColor = ConsoleColor.Cyan;
            userInput = Console.ReadLine().ToUpper();
            Console.ResetColor();
            Console.WriteLine("");

            switch (userInput)
            {
                case "E":
                    currentDifficulty = "Easy";
                    Console.ForegroundColor = ConsoleColor.Green;
                    NumberRange(easy);
                    maxRange = easy;
                    break;
                case "M":
                    currentDifficulty = "Medium";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    NumberRange(medium);
                    maxRange = medium;
                    break;
                case "H":
                    currentDifficulty = "Hard";
                    Console.ForegroundColor = ConsoleColor.Red;
                    NumberRange(hard);
                    maxRange = hard;
                    break;
                case "I":
                    currentDifficulty = "Impossible";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    NumberRange(impossible);
                    maxRange = impossible;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid entry: {0}", userInput);
                    Console.ResetColor();
                    Console.WriteLine("");
                    SetDifficulty();
                    break;
            }
        }
        private static void NumberRange(int maxRange)
        {
            Console.Write(currentDifficulty);
            Console.ResetColor();
            Console.WriteLine(" difficulty selected.");
            Random randomNumber = new Random();
            correctNumber = randomNumber.Next(0, maxRange);
        }

        private static void GuessingGame()
        {
            Console.WriteLine("Please guess a number from 0 - {0}", maxRange);
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                userGuess = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            Console.ResetColor();
            attemptCount++;
            Console.WriteLine("");

            while (userGuess != correctNumber)
            {
                if (userGuess > maxRange)
                {
                    Console.WriteLine("Your guess of {0} is outside of the number range 0 - {1}.", userGuess, maxRange);
                    UserGuess();
                }
                if (userGuess > correctNumber)
                {
                    Console.WriteLine("Your guess of {0} is greater than the correct number. Guess lower than {0}.", userGuess);
                    UserGuess();
                }
                if (userGuess < correctNumber)
                {
                    Console.WriteLine("Your guess of {0} is less than the correct number. Guess higher than {0}.", userGuess);
                    UserGuess();
                }

            }
            CorrectGuess();
        }

        private static void UserGuess()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                userGuess = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception) { }
            Console.ResetColor();
            Console.WriteLine("");
            attemptCount++;
        }

        private static void CorrectGuess()
        {
            if(attemptCount == 1)
            {
                Console.WriteLine("Congratulations {0}!", playerName);
                Console.WriteLine("Your guess of {0} is correct! You guessed the correct number on your first try!", userGuess);
            }
            else
            {
                Console.WriteLine("Congratulations {0}!", playerName);
                Console.WriteLine("After {0} attempts, your guess of {1} is correct!", attemptCount, userGuess);
            }

        }

        private static void PlayAgain()
        {
            string replay;
            Console.WriteLine("Play again [y , n]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            replay = Console.ReadLine().ToUpper();
            Console.ResetColor();
            Console.WriteLine("");
            if(replay == "Y")
            {
                attemptCount = 0;
                playAgain = true;
            }
            if(replay == "N")
            {
                Console.WriteLine("Closing... Thanks for playing!");
                Thread.Sleep(1000);
                playAgain = false;
            }
        }

        static void Main(string[] args)
        {
            while (playAgain)
            {
                Console.WriteLine("Starting... 'Guess the Number'");
                Thread.Sleep(1000);
                Console.WriteLine("");
                PlayerName();
                Console.WriteLine("");
                SetDifficulty();
                Console.WriteLine("");
                GuessingGame();
                Console.WriteLine("");
                PlayAgain();
            }
        }
    }
}
