public class Solution
{
    public int[] MinDifference(int[] nums, int[][] queries)
    {
        int n = nums.Length;

        // prefix[i][v] = number of times value v appears
        // in nums[0...i-1]
        int[,] prefix = new int[n + 1, 101];

        for (int i = 0; i < n; i++)
        {
            for (int v = 1; v <= 100; v++)
            {
                prefix[i + 1, v] = prefix[i, v];
            }

            prefix[i + 1, nums[i]]++;
        }

        int[] answer = new int[queries.Length];

        for (int q = 0; q < queries.Length; q++)
        {
            int left = queries[q][0];
            int right = queries[q][1];

            int previous = -1;
            int minDiff = int.MaxValue;

            for (int value = 1; value <= 100; value++)
            {
                int count = prefix[right + 1, value] - prefix[left, value];

                if (count > 0)
                {
                    if (previous != -1)
                    {
                        minDiff = Math.Min(minDiff, value - previous);
                    }

                    previous = value;
                }
            }

            answer[q] = minDiff == int.MaxValue ? -1 : minDiff;
        }

        return answer;
    }
}