using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Class1
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            int n = int.Parse(first[0]);
            int k = int.Parse(first[1]);
            string[] _nums = Console.ReadLine().Split();
            List<int> nums = new List<int>();
            for (int i = 0; i < _nums.Length; i++)
            {
                nums.Add(int.Parse(_nums[i]));
            }
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = int.MaxValue;
            }
            result[0] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < i+k+1 && j<n; j++)
                {
                    int a = Math.Min(result[j], result[i] + Math.Abs(nums[i] - nums[j]));
                    result[j] = a;
                }
            }
            Console.WriteLine(result[n-1]);
        }
    }
}
