namespace TMS
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();

            int[] digits = new int[4] { -1, -1, -1, -1};
            for (int i = 0; i < digits.Length; i++)
            {
                int newValue = random.Next(10);

                while (ExistInArray(digits, newValue))
                {
                    newValue = random.Next(10);
                }

                digits[i] = newValue;
            }

            while (true)
            {
                Console.WriteLine("Enter 4 digit number or exit the game:");
                string userInput = Console.ReadLine();

                if (userInput == "Exit")
                {
                    break;
                }

                if (!IsUserInputValid(userInput))
                {
                    Console.WriteLine("Wrong number!");
                    continue;
                }

                int[] userNumberArray = ParseInput(userInput);
              
                if (IsUserWon(userNumberArray, digits))
                {
                    Console.WriteLine("You won!");
                    break;
                }               

                int bullsAmount = CalculationBulls(userNumberArray, digits);
                Console.WriteLine($"Bulls amount: {bullsAmount}");

                int cowsAmount = CalculationCows(userNumberArray, digits);
                Console.WriteLine($"Cows amount: {cowsAmount}");

            }

        }

        public static bool ExistInArray(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                { 
                    return true;
                }
            }

            return false;
        }

        public static bool IsUserInputValid(string input)
        {
            if (input.Length != 4)
            { 
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return true;                
        }

        public static int[] ParseInput(string input)
        { 
            int[] response = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                response[i] = int.Parse(input[i].ToString());
            }

            return response;
        }

        public static int CalculationBulls(int[] userInput, int[] computerInput)
        {
            int bullsAmount = 0;
            for (int i = 0; i < 3; i++)
            {
                if (userInput[i] == computerInput[i])
                {
                    bullsAmount = bullsAmount + 1;
                }
            }

            return bullsAmount;
        }

        public static int CalculationCows(int[] userInput, int[] computerInput)
        { 
            int cowsAmount = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (userInput[j] == computerInput[i])
                    {
                        cowsAmount = cowsAmount + 1;
                    }
                }
            }

            return cowsAmount;
        }

        public static bool IsUserWon(int[] userInput, int[] computerInput)
        {
            bool result = true;

            for (int i = 0; i < 3; i++)
            {
                if (userInput[i] != computerInput[i])
                {
                    result = false;
                    break;                    
                }               
            }

            return result;
        }
    }
}
