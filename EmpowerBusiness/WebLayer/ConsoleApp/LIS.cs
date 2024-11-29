using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

 /*
 * C# to find the length of the longest increasing subsequence (LIS) 
 * using dynamic programming. The code not only calculates the length of the LIS 
 * but also provides the LIS itself.
 */
    class LIS
    {

        public static Tuple<int, List<int>> LongestIncreasingSubsequence(int[] nums)
        {
            if (nums == null || nums.Length == 0) return Tuple.Create(0, new List<int>());

            int n = nums.Length;
            int[] dp = new int[n]; // dp[i] stores the length of LIS ending at index i
            int[] previous = new int[n]; // Tracks the previous index of LIS
            Array.Fill(dp, 1);
            Array.Fill(previous, -1);

            int maxLength = 1; // Maximum length of LIS found so far
            int lastIndex = 0; // The last index of the LIS

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        previous[i] = j; // Update the previous index
                    }
                }
                if (dp[i] > maxLength)
                {
                    maxLength = dp[i];
                    lastIndex = i;
                }
            }

            // Reconstruct the LIS
            List<int> lis = new List<int>();
            for (int i = lastIndex; i >= 0; i = previous[i])
            {
                lis.Add(nums[i]);
                if (previous[i] == -1) break;
            }
            lis.Reverse();

            return Tuple.Create(maxLength, lis);
        }

        //int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18 };
        //var result = LongestIncreasingSubsequence(nums);
        //
        //Console.WriteLine("Length of LIS: " + result.Item1);
        //Console.WriteLine("Longest Increasing Subsequence: [" + string.Join(", ", result.Item2) + "]");
    }

}
