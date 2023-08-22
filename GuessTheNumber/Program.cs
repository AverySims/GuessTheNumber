
namespace HigherLower
{
	internal class Program
	{
		// "Randomly generate a number between 1 and 100 (inclusive)"
		private static int randomMin = 1;
		private static int randomMax = 100;

		// setting it to -1 so the rndVal and the userVal cannot be the same number when the program starts
		private static int userGuessValue = -1;
		// tracking how many times you guessed
		private static int attemptCounter = 0;
		// set to 'true' if you want to know what the random number is when the program starts.
		public static bool debugRndNum = false;

		private static bool loopMain = true;

		static void Main(string[] args)
		{
			// random number generation
			Random randomInstance = new Random();

			while (loopMain)
			{
				// reset user vars when the program starts/restarts
				userGuessValue = -1;
				attemptCounter = 0;

				// allowing the user to set the random max
				Console.WriteLine("Select random number range (10, 100, 1000, etc...)");
				SimpleConsoleFunctions.ParseIntEC(out randomMax);

				int randomValue = randomInstance.Next(randomMin, randomMax);

				// debug check
				if (debugRndNum)
					SimpleConsoleFunctions.PrintValue(randomValue);

				GuessRandomValue(randomValue);

				SimpleConsoleFunctions.SelectEndingAction(out loopMain);
			}
			
		}

		private static void GuessRandomValue(int target)
		{
			Console.WriteLine("Guess the number");
			while (target != userGuessValue)
			{
				SimpleConsoleFunctions.ParseIntEC(out userGuessValue);
				Console.WriteLine(GetGuessHint(userGuessValue, target));
				// incrementing the attempt counter for every guess
				attemptCounter++;
			}
			// once guessed, print final result
			PrintFinalResult(attemptCounter);
		}

		private static string GetGuessHint(int guess, int goal)
		{
			if (guess > goal)
			{
				return "Too high, guess lower.";
			}
			else if (guess < goal)
			{
				return "Too low, guess higher.";
			}
			else
			{
				return "Correct! Good guess.\n";
			}
		}

		private static string GetAttemptVerbage(int count)
		{
			return count > 1 ? "attempts" : "attempt";
		}

		#region Printing
		private static void PrintFinalResult(int count)
		{
			Console.WriteLine("You guessed it in " + count + " " + GetAttemptVerbage(count));
		}
		#endregion

	}

}