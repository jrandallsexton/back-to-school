namespace BackToSchool.CSharp.Algorithms.Primes
{
    public static class FindPrimeNumber
    {
        public static long Find(int n)
        {
            int count = 0;
            long a = 2;

            while (count < n)
            {
                long b = 2;
                int prime = 1; // to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }

                    b++;
                }

                if (prime > 0)
                    count++;

                a++;
            }

            return (--a);
        }

        public static int FindNthPrime(int n)
        {
            var count = 0;
            var idx = 1;

            while (count < n)
            {
                if (idx / idx == 1)
                {
                    count++;
                }

                idx++;

                if (count == n)
                    break;
            }

            return idx;
        }
    }
}
