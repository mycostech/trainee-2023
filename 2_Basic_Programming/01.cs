internal class NumberGuessingGame
{
    /// <summary>
    /// Input 4 numbers to guess the random numbers.
    /// </summary>
    static void Start()
    {
        char[] answerSets = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        int indexStart = 0;
        var rnd = new Random();

        //loop for Swap member values in the answerSets array.
        for (var index = 0; index < answerSets.Length; index++)
        {
            var rnd1 = rnd.Next(indexStart, answerSets.Length);
            var rnd2 = rnd.Next(indexStart, answerSets.Length);
            var changePosition = answerSets[rnd1];
            answerSets[rnd1] = answerSets[rnd2];
            answerSets[rnd2] = changePosition;
        }

        //random asnwer number
        char[] quiz = new char[4];
        for (var index = 0; index < 4; index++)
        {
            quiz[index] = answerSets[index];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        // number of round you can guess the number
        int round = 1;
        while (round <= 3)
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
                    Check4Digits();
                }
                else
                {
                    if (inp.Any(c => !char.IsDigit(c)))
                    {
                        Check4Digits();
                    }
                    else
                    {
                        var correct_count = 0;
                        var wrong_pos_count = 0;
                        // loop for check position between quiz and your guess
                        for (var index = 0; index < 4; index++)
                        {
                            if (inp[index] == quiz[index])
                                correct_count++;
                            else if (quiz.Contains(inp[index]))
                                wrong_pos_count++;
                        }
                        //when 4 number of your guessing is correct
                        if (correct_count == 4)
                        {
                            Console.WriteLine("You WIN!!");
                            return;
                        }

                        Console.WriteLine($"Wrong! (Correct = {correct_count}, contain but wrong position = {wrong_pos_count})");
                        round++;
                    }
                }
            }
        }

        Console.WriteLine("You LOSE +_+");
        Console.Write("Answer: ");
        //loop for show ture answer of 4 digits
        for (var index = 0; index < 4; index++)
        {
            Console.Write(quiz[index]);
        }
        Console.Write(Environment.NewLine);
    }

    /// <summary>
    /// display "Must be 4 digits" 
    /// </summary>
    public static void Check4Digits()
    {
        Console.WriteLine("Must be 4 digits");
    }
    static void Main(string[] args)
    {
        Start();
    }
}