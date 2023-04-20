internal class NumberGuessingGame
{
    public void Start()
    {
        char[] answers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        var rnd = new Random();
        for (var index = 0; index < answers.Length; i++)
        {
            var rndNumber1 = rnd.Next(0, answers.Length);
            var rndNumber2 = rnd.Next(0, answers.Length);
            var z = answers[rndNumber1];  //don't understand. 
            answers[rndNumber1] = answers[rndNumber2];
            answers[rndNumber2] = z;
        }

        char[] quizzes = new char[4];
        for (var index = 0; index < 4; index++)
        {
            quizzes[index] = answers[index];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        int numberAnswerQuestion = 1; 
        while (numberAnswerQuestion <= 3)
        {
            Console.Write("You guess: ");
            var userInput = Console.ReadLine(); // Keep user input from command line.

            if (string.IsNullOrEmpty(userInput)) // Verify user input is null or empty.
            {
                Console.WriteLine("Invalid number");
            }
            else
            {
                if (userInput.Length != 4) // Verify user input have quantity of input.
                {
                    Console.WriteLine("Must be 4 digits");
                }
                else
                {
                    if (userInput.Any(c => !char.IsDigit(c))) // Verify user input is digit
                    {
                        Console.WriteLine("Must be 4 digits");
                    }
                    else
                    {
                        var correctCount = 0;
                        var wrongPosCount = 0;
                        for (var index = 0; index < 4; index++)
                        {
                            if (userInput[index] == quizzes[index])
                                correctCount++;
                            else if (quizzes.Contains(userInput[index]))
                                wrongPosCount++;
                        }

                        if (correctCount == 4)
                        {
                            Console.WriteLine("You WIN!!");
                            return;
                        }

                        Console.WriteLine($"Wrong! (Correct = {correctCount}, contain but wrong position = {wrongPosCount})");
                        numberAnswerQuestion++;
                    }
                }
            }
        }

        Console.WriteLine("You LOSE +_+");
        Console.Write("Answer: ");
        for (var index = 0; index < 4; i++)
        {
            Console.Write(quizzes[index]);
        }
        Console.Write(Environment.NewLine);
    }
}