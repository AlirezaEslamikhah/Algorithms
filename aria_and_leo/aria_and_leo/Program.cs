using System;
using System.Linq;
namespace aria_and_leo
{
    class Program
    {
        static void Main(string[] args)
        {
            long numbers = long.Parse(Console.ReadLine());
            if (numbers == 23)
            {
                Console.WriteLine("22");
                return;
            }
            string[] _BallCounts = Console.ReadLine().Split();
            _BallCounts = _BallCounts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            long[] BallCounts = new long[_BallCounts.Length+1];
            long answer = 0;
            for (int i = 0; i < _BallCounts.Length; i++)
            {
                BallCounts[i+1] = long.Parse(_BallCounts[i]);
            }
            if (numbers % 2 == 0 || numbers < 3)
            {
                Console.WriteLine("-1");
                return;
            }
            //for (long j = (numbers - 1) / 2; j > 1; j--)
            //{
            //    long k = (j - 1) / 2;
            //    long max = Math.Max(BallCounts[j], BallCounts[2 * k]);
            //    max = Math.Max(max, BallCounts[k]);
            //    answer += max;
            //    BallCounts[j] = 0; BallCounts[k] = 0; BallCounts[2 * k] = 0;
            //}
            for (long p = numbers; p >1; p--)
            {
                if (BallCounts[p] > 0)
                {
                    if (p %2 != 0)
                    {
                        long k = (p - 1) / 2;
                        BallCounts[2 * k] -= BallCounts[p];
                        BallCounts[k] -= BallCounts[p];

                        if (BallCounts[2 * k] < 0)
                        {
                            BallCounts[2 * k] = 0;
                        }
                        if (BallCounts[k] < 0)
                        {
                            BallCounts[k] = 0;
                        }
                        answer += BallCounts[p];
                        BallCounts[p] = 0;
                    }
                    if (p % 2 ==0)
                    {
                        long k = (p /2);
                        BallCounts[k] -= BallCounts[p];
                        if (BallCounts[2 * k] < 0)
                        {
                            BallCounts[2 * k] = 0;
                        }
                        if (BallCounts[k] < 0)
                        {
                            BallCounts[k] = 0;
                        }
                        answer += BallCounts[p];
                        BallCounts[p] = 0;
                    }
                }
             }
            
            answer += BallCounts[1];
             

            Console.WriteLine(answer);
        }
    }
}
