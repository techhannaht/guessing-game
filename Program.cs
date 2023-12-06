using System;

static void GuessingGame()
{
    // Display message to the user asking them to choose a difficulty level.
        Console.WriteLine("Guess the Secret Number...");
        Console.WriteLine("Choose a difficulty level: Easy, Medium, Hard, or Cheater");

        // Take user's difficulty level choice as input and set the number of guesses accordingly.
        int maxGuesses;
        string difficultyLevel = Console.ReadLine().ToLower();

        switch (difficultyLevel)
        {
            case "easy":
                maxGuesses = 8;
                break;
            case "medium":
                maxGuesses = 6;
                break;
            case "hard":
                maxGuesses = 4;
                break;
            case "cheater":
                maxGuesses = int.MaxValue; // Set to a very large number for "Cheater" mode.
                break;
            default:
                Console.WriteLine("Invalid difficulty level. Defaulting to Medium.");
                maxGuesses = 6;
                break;
        }

        // Generate random number between 1 and 100.
        Random random = new Random();
        int secretNumber = random.Next(1, 101);

        // Give user the specified number of chances to guess the number.
        for (int attempt = 1; attempt <= maxGuesses || maxGuesses == int.MaxValue; attempt++)
        {
            // Display prompt for the user's guess, including the attempt number and remaining guesses.
            Console.Write($"Your guess ({attempt}/{maxGuesses}): ");

            // Take user's guess as input and save it as a variable.
            string userGuessString = Console.ReadLine();

            // Convert user's guess to an integer.
            if (int.TryParse(userGuessString, out int userGuess))
            {
                // Compare user's guess with the secret number.
                if (userGuess == secretNumber)
                {
                    // Display success message if the guess is correct.
                    Console.WriteLine("Congratulations! You guessed the correct number!");
                    return; // Exit the program if the guess is correct.
                }
                else
                {
                    // Display message indicating if the guess was too high or too low.
                    if (userGuess > secretNumber)
                    {
                        Console.WriteLine("Too high. Try again!");
                    }
                    else
                    {
                        Console.WriteLine("Too low. Try again!");
                    }
                }
            }
            else
            {
                // The user input is not a valid integer.
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            // Add an empty line for better readability between attempts.
            Console.WriteLine();
        }

        // Display message if the user runs out of attempts.
        Console.WriteLine($"Sorry, you've run out of attempts. The correct number was {secretNumber}.");
    }

GuessingGame();