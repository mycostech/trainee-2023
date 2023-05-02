//Readme, i did not change to much thing in the file , just change the name of variables to be in a standard.
internal class NumberGuessingGame
{
    // a function to start the game and game logic
    public void StartGame()
    {
        char[] answerSets = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        var rnd = new Random();
        for (var i = 0; i < answerSets.Length; i++)
        {
            var randomLength1 = rnd.Next(0, answerSets.Length);
            var randomLength2 = rnd.Next(0, answerSets.Length);
            var temp = answerSets[randomLength1];
            answerSets[randomLength1] = answerSets[randomLength2];
            answerSets[randomLength2] = temp;
        }

        char[] quiz = new char[4];
        for (var i = 0; i < 4; i++)
        {
            quiz[i] = answerSets[i];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        int attemptTimes = 1;
        while (attemptTimes <= 3)
        {
            Console.Write("You guess: ");
            var inp = Console.ReadLine();

            if (string.IsNullOrEmpty(inp)) 
            {
                Console.WriteLine("Invalid number");
            }
            else
            {
                if (inp.Length != 4)
                {
                    Console.WriteLine("Must be 4 digits");
                }
                else
                {
                    if (inp.Any(c => !char.IsDigit(c)))
                    {
                        Console.WriteLine("Must be 4 digits");
                    }
                    else
                    {
                        var correctGuessCount = 0;
                        var wrongPositionCount = 0;
                        for (var i = 0; i < 4; i++)
                        {
                            if (inp[i] == quiz[i])
                                correctGuessCount++;
                            else if (quiz.Contains(inp[i]))
                                wrongPositionCount++;
                        }

                        if (correctGuessCount == 4)
                        {
                            Console.WriteLine("You WIN!!");
                            return;
                        }

                        Console.WriteLine($"Wrong! (Correct = {correctGuessCount}, contain but wrong position = {wrongPositionCount})");
                        attemptTimes++;
                    }
                }
            }
        }

        Console.WriteLine("You LOSE +_+");
        Console.Write("Answer: ");
        for (var i = 0; i < 4; i++)
        {
            Console.Write(quiz[i]);
        }
        Console.Write(Environment.NewLine);
    }
}