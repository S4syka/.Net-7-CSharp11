namespace PrimeFactorsLib
{
    public static class PrimeFactors
    {
        public static string GetPrimeFactors(int number)
        {
            if (number < 1) throw new ArgumentException(message: "Number is negative or equal to zero", paramName: nameof(number));
            if (number == 1) return "1";

            string value = string.Empty;
            int minPrime = 2;

            while (number != 1)
            {
                if (number % minPrime == 0 && number != minPrime)
                {
                    value = $" {minPrime}{value}";
                    number = number / minPrime;
                }
                else if (number % minPrime == 0 && number == minPrime)
                {
                    value = $"{minPrime}{value}";
                    number = number / minPrime;
                }
                else
                {
                    minPrime++;
                }
            }

            return value;
        }
    }
}