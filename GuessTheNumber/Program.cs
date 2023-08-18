namespace HigherLower
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Random number max integer
			int rndMax = 100;

			// set to 'true' if you want to know what the random number is when the program starts.
			bool debugRndNum = false;

			// random number generation
			Random rnd = new Random();
			int rndVal = rnd.Next(rndMax);

			// setting it to -1 so the rndVal and the userVal cannot be the same number when the program starts
			int userVal = -1;

			// tracking how many times you guessed
			int attemptCounter = 0;

			if (debugRndNum)
				Console.WriteLine("Random value is: " + rndVal);

			while (rndVal != userVal)
			{
				Console.WriteLine("Guess the number");
				userVal = int.Parse(Console.ReadLine());

				if (userVal > rndVal)
					Console.WriteLine("Too high, guess lower.");

				else if (userVal < rndVal)
					Console.WriteLine("Too low, guess higher.");

				else
					Console.WriteLine("Correct! Good guess.\n");

				// incrementing the attempt counter for every guess
				attemptCounter++;
			}

			// changing the wording based on # of attempts
			string attemptPlurality = attemptCounter > 1 ? "attempts" : "attempt";

			// appending strings to create the final msg
			Console.WriteLine("You guessed it in " + attemptCounter + " " + attemptPlurality);

		}
	}
}