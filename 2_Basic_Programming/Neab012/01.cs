///////////////////////////////////////////////////////////
/////
/// FileName: 01.cs
/// TypeFile: Visual C# Source file.
/// Last Modified On: 21/4//2023 9:31 h:mm (24 hrs) 
/// Description: Class game number guessing.
/////
//////////////////////////////////////////////////////////////

internal class NumberGuessingGame
{
    /// <summary>
    /// Description: Get started with a 4-digit code guessing game.
    /// </summary>
    public void Start()
    {
        char[] answers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // array that's contain numbers.

        var rnd = new Random();
        shuffleArray(answers, answers.Lenght, rnd);

        char[] quizzes = new char[4];
        for (var index = 0; index < 4; index++) // Define quizze and keep in arrays.
        {
            quizzes[index] = answers[index];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        int numberAnswerQuestion = 1; // 
        while (numberAnswerQuestion <= 3)
        {
            Console.Write("You guess: ");
            var userInput = Console.ReadLine(); // Keep user input from command line.

            if (!hasInvalid(userInput))
            {
                var correctCount = 0; // Keep scores(correct count) is correct.
                var wrongPosCount = 0; // Keep  wrong position count in quizzes.
                for (var index = 0; index < 4; index++)
                {
                    if (userInput[index] == quizzes[index]) // Verify answer is corrected.
                        correctCount++;
                    else if (quizzes.Contains(userInput[index])) // 
                        wrongPosCount++;
                }

                if (correctCount == 4) //Verify scores to winning.
                {
                    Console.WriteLine("You WIN!!");
                    return;
                }

                Console.WriteLine($"Wrong! (Correct = {correctCount}, contain but wrong position = {wrongPosCount})");
                numberAnswerQuestion++;
            }
        }

        Console.WriteLine("You LOSE +_+");
        Console.Write("Answer: ");
        for (var index = 0; index < 4; i++) // Show correact answers.
        {
            Console.Write(quizzes[index]);
        }
        Console.Write(Environment.NewLine);
    }

    /// <summary>
    /// Description: Check all expectations are all problems of input from users.
    /// </summary>
    /// <param name="userInput"> string </param>
    /// <returns> boolean if ture is have some invalid, false is not have some invalid </returns>
    public bool hasInvalid(var userInput)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Invalid number");
            return true;
        }

        if (userInput.Length != 4)
        {
            Console.WriteLine("Must be 4 digits");
            return true;
        }

        if (userInput.Any(character => !char.IsDigit(character)))
        {
            Console.WriteLine("Must be 4 digits");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Description: Shuffle data in arrays.
    /// </summary>
    /// <param name="arrays"> Arrays of character </param>
    /// <param name="lenghtArrays"> Lenght of arrays </param>
    /// <param name="randomizes"> Random object </param>
    public void shuffleArray(char[] arrays, int lenghtArrays, var randomizes)
    {
        for (var index = 0; index < lenghtArrays;index++)
        {
            var rndIndex1 = randomizes.nextInt(0, lenghtArrays); // Random number from 0 -> lenght of arrays. ( 2n + 1 )
            var rndIndex2 = randomizes.nextInt(0, lenghtArrays); // Random number from 0 -> lenght of arrays. ( 2n + 1 )
            var storeDataIndex1 = arrays[rndIndex1]; // Store data of arrays position random index1.
            arrays[rndIndex1] = arrays[rndIndex2]; // Switch data of arrays between position rndindex1 
            arrays[rndIndex2] = storeDataIndex1;   // and rndindex2
        }
    }
}