public class Solution
{
    public bool CanBeIncreasing(int[] nums)
    {
        int removed = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                removed++;

                if (removed > 1)
                    return false;

                // Decide whether to remove nums[i-1] or nums[i]
                if (i >= 2 && nums[i] <= nums[i - 2])
                {
                    nums[i] = nums[i - 1];
                }
            }
        }

        return true;
    }
}