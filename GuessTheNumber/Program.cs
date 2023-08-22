namespace HigherLower
{
	internal class Program
	{
		// "Randomly generate a number between 1 and 100 (inclusive)"
		private static int rndMin = 1;
		private static int rndMax = 100;

		// setting it to -1 so the rndVal and the userVal cannot be the same number when the program starts
		private static int userVal = -1;
		private static int userEndVal = -1;

		// tracking how many times you guessed
		private static int attemptCounter = 0;

		private static bool loopMain = true;
		private static bool loopEndingSelector = true;

		// set to 'true' if you want to know what the random number is when the program starts.
		public static bool debugRndNum = false;

		static void Main(string[] args)
		{
			// random number generation
			Random rnd = new Random();

			while (loopMain)
			{
				// reset user vars when the program starts/restarts
				userVal = -1;
				attemptCounter = 0;

				// allowing the user to set the random max
				Console.WriteLine("Select random number range (10, 100, 1000, etc...)");
				ParseIntEC(out rndMax);

				int rndVal = rnd.Next(rndMin, rndMax);

				// debug check
				if (debugRndNum)
					PrintValue(rndVal);

				while (rndVal != userVal)
				{
					Console.WriteLine("Guess the number");
					ParseIntEC(out userVal);

					Console.WriteLine(GetGuessHint(userVal, rndVal));

					// incrementing the attempt counter for every guess
					attemptCounter++;
				}

				PrintFinalResult(attemptCounter);

				SelectEndingPath();
			}
			
		}

		#region Parsing
		private static bool ParseIntEC(out int val)
		{
			return int.TryParse(Console.ReadLine(), out val);
		}
		#endregion

		#region Printing
		public static void PrintValue(int val)
		{
			Console.WriteLine("Value is: " + val);
		}

		private static void PrintFinalResult(int count)
		{
			Console.WriteLine("You guessed it in " + count + " " + GetAttemptVerbage(count));
		}

		public static void PrintInvalidSelection()
		{
			Console.WriteLine("Invalid selection, please select a listed option.");
		}

		private static void PrintBlank()
		{
			Console.WriteLine("");
		}
		#endregion

		private static string GetGuessHint(int guess, int goal)
		{
			if (guess > goal)
				return "Too high, guess lower.";

			else if (guess < goal)
				return "Too low, guess higher.";

			else
				return "Correct! Good guess.\n";
		}

		private static string GetAttemptVerbage(int count)
		{
			return count > 1 ? "attempts" : "attempt";
		}

		private static void SelectEndingPath()
		{
			// reset loop state before entering loop
			loopEndingSelector = true;
			Console.WriteLine("Choose what happens next:");
			PrintBlank();

			Console.WriteLine("1. Guess a new number");
			Console.WriteLine("2. Quit program");

			while (loopEndingSelector)
			{
				ParseIntEC(out userEndVal);
				switch (userEndVal)
				{
					case 1:
						loopEndingSelector = false;
						break;

					case 2:
						loopEndingSelector = false;
						loopMain = false;
						break;

					default:
						PrintInvalidSelection();
						break;
				}
			}
			PrintBlank();
			return;
		}
		

		
	}
}