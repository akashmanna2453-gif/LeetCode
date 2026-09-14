public class Solution
{
    public long MaxAlternatingSum(int[] nums)
    {
        long even = 0;
        long odd = 0;

        foreach (int num in nums)
        {
            long newEven = Math.Max(even, odd + num);
            long newOdd = Math.Max(odd, even - num);

            even = newEven;
            odd = newOdd;
        }

        return even;
    }
}