public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();
        bool[] used = new bool[nums.Length];
        var current = new List<int>();

        Backtrack(nums, used, current, result);

        return result;
    }

    private void Backtrack(
        int[] nums,
        bool[] used,
        List<int> current,
        List<IList<int>> result)
    {
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i])
                continue;

            // Skip duplicate permutations
            if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                continue;

            used[i] = true;
            current.Add(nums[i]);

            Backtrack(nums, used, current, result);

            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}