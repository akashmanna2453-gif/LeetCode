public class Solution
{
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        for (int num = left; num <= right; num++)
        {
            bool covered = false;

            foreach (int[] range in ranges)
            {
                if (range[0] <= num && num <= range[1])
                {
                    covered = true;
                    break;
                }
            }

            if (!covered)
                return false;
        }

        return true;
    }
}