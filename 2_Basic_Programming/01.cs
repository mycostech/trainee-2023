//////////////////////////////////////////////////////////////////
// This following source is about the game of guessing number   //
//Rules:                                                        // 
//1.The system will random four numbers from 0 to 9.            //
//2.There are three chances for a player to guess those numbers.//
//////////////////////////////////////////////////////////////////
internal class NumberGuessingGame
{
    static void Start()
    {
        // The numbers that will include into question by random 
        char[] answerSet = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        randomNumber(answerSet);

        char[] quiz = createQuestion(answerSet);

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");
        int round = 1; // round is how many times that a player can fail.

        IsItCorrect(round, quiz);

    }

    // This is the method for checking player anwser.
    static void IsItCorrect(int r, char[] q)
    {
        while (r <= 3) //Ask player for three times
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
                            if (inp[i] == q[i])
                                correctCount++;
                            else if (q.Contains(inp[i]))
                                wrongPosCount++;
                        }

                        if (correctCount == 4)
                        {
                            Console.WriteLine("You WIN!!");
                            return;
                        }

                        Console.WriteLine($"Wrong! (Correct = {correctCount}, contain but wrong position = {wrongPosCount})");
                        r++;
                    }
                }
            }
        }

        Console.WriteLine("You LOSE +_+");
        Console.Write("Answer: ");
        for (var i = 0; i < 4; i++)
        {
            Console.Write(q[i]);
        }
        Console.Write(Environment.NewLine);
    }

    static char[] randomNumber(char[] answerSet)
    {
        var rnd = new Random();
        for (var i = 0; i < answerSet.Length; i++)
        {
            var x = rnd.Next(0, answerSet.Length);
            var y = rnd.Next(0, answerSet.Length);
            var z = answerSet[x];
            answerSet[x] = answerSet[y];
            answerSet[y] = z;
        }
        return answerSet;
    }

    static char[] createQuestion(char[] answerSet)
    {
        char[] quiz = new char[4];
        for (var i = 0; i < 4; i++)
        {
            quiz[i] = answerSet[i];
        }
        return quiz;
    }

    static void Main(string[] args)
    {
        Start();
    }
}