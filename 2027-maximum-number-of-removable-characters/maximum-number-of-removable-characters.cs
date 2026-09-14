public class Solution
{
    public int MaximumRemovals(string s, string p, int[] removable)
    {
        int left = 0;
        int right = removable.Length;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (IsSubsequence(s, p, removable, mid))
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return right;
    }

    private bool IsSubsequence(string s, string p, int[] removable, int k)
    {
        bool[] removed = new bool[s.Length];

        for (int i = 0; i < k; i++)
        {
            removed[removable[i]] = true;
        }

        int j = 0;

        for (int i = 0; i < s.Length && j < p.Length; i++)
        {
            if (!removed[i] && s[i] == p[j])
            {
                j++;
            }
        }

        return j == p.Length;
    }
}