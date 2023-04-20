internal class NumberGuessingGame
{
    public void Start()
    {
        char[] answerSet = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        var rnd = new Random();
        for (var i = 0; i < answerSet.Length; i++)
        {
            var x = rnd.Next(0, answerSet.Length);
            var y = rnd.Next(0, answerSet.Length);
            var z = answerSet[x];
            answerSet[x] = answerSet[y];
            answerSet[y] = z;
        }

        char[] quiz = new char[4];
        for (var i = 0; i < 4; i++)
        {
            quiz[i] = answerSet[i];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        int k = 1;
        while (k <= 3)
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
                        var correctCount = 0;
                        var wrongPosCount = 0;
                        for (var i = 0; i < 4; i++)
                        {
                            if (inp[i] == quiz[i])
                                correctCount++;
                            else if (quiz.Contains(inp[i]))
                                wrongPosCount++;
                        }

                        if (correctCount == 4)
                        {
                            Console.WriteLine("You WIN!!");
                            return;
                        }

                        Console.WriteLine($"Wrong! (Correct = {correctCount}, contain but wrong position = {wrongPosCount})");
                        k++;
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