internal class NumberGuessingGame
{
    static void Start()
    {
        // array contain numbers.
        char[] answerSet = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        // create a random object
        var random = new Random();
        //loop for swap value between randomIndexOne and randomIndextwo
        for (var i = 0; i < answerSet.Length; i++)
        {
            // for random value
            var randomIndexOne = random.Next(0, answerSet.Length); 
            var randomIndexTwo = random.Next(0, answerSet.Length);
            // for swap value
            answerSet[randomIndexOne] = answerSet[randomIndexTwo];
            answerSet[randomIndexTwo] = answerSet[randomIndexOne];
        }
        // create a quiz array object
        char[] quiz = new char[4];
        // loop for collect value for random object in to the quiz object
        for (var i = 0; i < 4; i++)
        {
            quiz[i] = answerSet[i];
        }

        Console.WriteLine("Welcome to guessing number game. We have unique number in 4 digits.");

        int roundAnswer = 1;
        while (roundAnswer <= 3) 
        {
            Console.Write("You guess: ");
            var input = Console.ReadLine(); // input received

            if (hasValid(input)) //if input has valid
            {
                var correct_count = 0;
                var wrong_pos_count = 0;
                //loop for check between input value and random value
                for (var i = 0; i < 4; i++)
                {
                    if (input[i] == quiz[i])
                        correct_count++;
                    else if (quiz.Contains(input[i]))
                        wrong_pos_count++;
                }
                if (correct_count == 4) //if 4 number from input is correct
                {
                    Console.WriteLine("You WIN!!");
                    return;
                }
                //show details of count of correct and wrong position
                Console.WriteLine($"Wrong! (Correct = {correct_count}, contain but wrong position = {wrong_pos_count})");
                k++;
            }

        }

        Console.WriteLine("You LOSE +_+");
        Console.Write("Answer: ");
        //show random value 4 digits
        for (var i = 0; i < 4; i++)
        {
            Console.Write(quizzes[i]);
        }
        Console.Write(Environment.NewLine);
    }

    //method for checking input received
    public bool hasValid(var input)
    {
        // If input is null or empty
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid number");
            return false;
        }
        // If input size is not equal to 4
        if (input.Length != 4)
        {
            Console.WriteLine("Must be 4 digits");
            return false;
        }
        // If cherInput is not a number 0-9
        if (input.Any(charInput => !char.IsDigit(charInput)))
        {
            Console.WriteLine("Must be 4 digits");
            return false;
        }
        // If input does not enter any condition
        return true;
    }
    // main 
    static void Main(string[] args)
        {
            Start();
        }
}