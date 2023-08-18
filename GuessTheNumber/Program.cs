namespace HigherLower
{
	internal class Program
	{
		// "Randomly generate a number between 1 and 100 (inclusive)"
		private static int rndMin = 1;
		private static int rndMax = 100;

		// setting it to -1 so the rndVal and the userVal cannot be the same number when the program starts
		private static int userVal = -1;

		// tracking how many times you guessed
		private static int attemptCounter = 0;

		// set to 'true' if you want to know what the random number is when the program starts.
		public static bool debugRndNum = false;

		static void Main(string[] args)
		{
			// random number generation
			Random rnd = new Random();
			int rndVal = rnd.Next(rndMin, rndMax);

			// debug check
			if (debugRndNum)
				PrintValue(rndVal);

			while (rndVal != userVal)
			{
				Console.WriteLine("Guess the number");
				userVal = int.Parse(Console.ReadLine());

				Console.WriteLine(GetGuessHint(userVal, rndVal));

				// incrementing the attempt counter for every guess
				attemptCounter++;
			}

			PrintFinalResult(attemptCounter);
		}

		private static string GetGuessHint(int guess, int goal)
		{
			if (guess > goal)
				return "Too high, guess lower.";

			else if (guess < goal)
				return "Too low, guess higher.";

			else
				return "Correct! Good guess.\n";
		}

		private static void PrintFinalResult(int count)
		{
			Console.WriteLine("You guessed it in " + count + " " + GetAttemptVerbage(count));
		}

		private static string GetAttemptVerbage(int count)
		{
			return count > 1 ? "attempts" : "attempt";
		}

		// debug function
		public static void PrintValue(int val)
		{
			Console.WriteLine("Value is: " + val);
		}
	}
}