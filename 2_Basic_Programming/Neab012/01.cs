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
            var z = answers[rndNumber1];
            answers[rndNumber1] = answers[rndNumber2];
            answers[rndNumber2] = z;
        }

        char[] quizzes = new char[4];
        for (var index = 0; index < 4; index++)
        {
            quizzes[index] = answers[index];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        int k = 1;
        while (k <= 3)
        {
            Console.Write("You guess: ");
            var userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput)) 
            {
                Console.WriteLine("Invalid number");
            }
            else
            {
                if (userInput.Length != 4)
                {
                    Console.WriteLine("Must be 4 digits");
                }
                else
                {
                    if (userInput.Any(c => !char.IsDigit(c)))
                    {
                        Console.WriteLine("Must be 4 digits");
                    }
                    else
                    {
                        var correct_count = 0;
                        var wrong_pos_count = 0;
                        for (var i = 0; i < 4; i++)
                        {
                            if (userInput[i] == quizzes[i])
                                correct_count++;
                            else if (quizzes.Contains(userInput[i]))
                                wrong_pos_count++;
                        }

                        if (correct_count == 4)
                        {
                            Console.WriteLine("You WIN!!");
                            return;
                        }

                        Console.WriteLine($"Wrong! (Correct = {correct_count}, contain but wrong position = {wrong_pos_count})");
                        k++;
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