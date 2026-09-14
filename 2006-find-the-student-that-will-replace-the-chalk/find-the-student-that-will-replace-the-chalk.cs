public class Solution
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        long total = 0;

        foreach (int c in chalk)
        {
            total += c;
        }

        k = (int)(k % total);

        for (int i = 0; i < chalk.Length; i++)
        {
            if (k < chalk[i])
            {
                return i;
            }

            k -= chalk[i];
        }

        return 0;
    }
}