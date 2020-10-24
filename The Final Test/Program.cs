using System;
using System.Drawing;
using System.Linq;

namespace The_Final_Test
{
    class Program
    {
        internal static Monkey user = new Monkey(false, false, false, false, false, false,false);
        private static ConsoleColor _monkeyColor;
        private static string _userName;
        public static void Main()
        {
            //the monkey test
            Console.Write("***WELCOME TO THE MONKEY TEST ***\nBy Owen Steele\n\nWhat's your name? ");
            _userName = Console.ReadLine();

            do Quiz();
            while (Retry());
        }
        private static void Quiz()
        {
            _monkeyColor = ConsoleColor.White;
            Console.Clear();

            int questionNumber = 0; 
            string questionOutput = "";
            Console.WriteLine($"Monkey in progress: {_userName}.\n\nPress Y or N keys to answer questions.");

            MonkeyFactory.CreateMonkeys();

            while (questionOutput != null)
            {
                questionOutput = NextQuestion(questionNumber);

                if (questionOutput == null) break;

                Output(questionOutput);
                DecideMonkey(questionNumber, Input());

                questionNumber++;
            }

            Output($"\nYour monkey is: {MonkeyFactory.MatchMonkey(user)}\n", color: _monkeyColor);

            SeeStats();
        }
        private static bool Retry(bool firstTime = false)
        {
            Console.Write("\nDo you want to take the test again (Y/N)? ");
            return Input();
        }

        private static bool Input(bool name = false)
        {
            bool emptyInput = true;
            ConsoleKey? result = null;
            while (emptyInput)
            {
                if (result != null) Console.Write("\nYou must press Y or N: ");
                result = Console.ReadKey().Key;
                emptyInput = (result == ConsoleKey.Y || result == ConsoleKey.N) ? false : true ;
            }
            return (result == ConsoleKey.Y)? true:false;
        }

        private static void Output(string output, bool newLine = false, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            if (output != null) Console.Write($"\n{output}{(newLine ? "\n":"")}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string NextQuestion(int questionNumber)
        {
            if (questionNumber >= MonkeyFactory.questions.Length) return null;

            return $"{questionNumber+1}. {MonkeyFactory.questions[questionNumber]}? ";
        }
        private static void DecideMonkey(int questionNumber, bool answer)
        {
            switch (questionNumber)
            {
                case 0:
                    if (answer)
                    {
                        user.OrangeFur = true;
                        _monkeyColor = ConsoleColor.Red;
                    }
                    break;
                case 1:
                    if (answer) user.LongArms = true;
                    break;
                case 2:
                    if (answer) user.BigMonkey = true;
                    break;
                case 3:
                    if (answer) user.BigNose = true;
                    break;
                case 4:
                    if (answer) user.BasicBitch = true;
                    break;
                case 5:
                    if (answer) user.TreeMonkey = true;
                    break;
                case 6:
                    if (answer) user.MonkeyApePrimate = true;
                    break;
                case int n when (n > 6 && n <= 12):
                    if (answer) user.GenitalSize++;
                    break;
            }
        }
        private static void SeeStats()
        {
            Console.Write("DO you want to see your results?");
            if(Input())
            {
                string[] results = MonkeyFactory.UserResults(user);

                Console.WriteLine("\n");

                foreach(string result in results)
                    Console.WriteLine(result);
            }
        }
    }
}
