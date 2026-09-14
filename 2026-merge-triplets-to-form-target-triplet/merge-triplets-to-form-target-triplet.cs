public class Solution
{
    public bool MergeTriplets(int[][] triplets, int[] target)
    {
        bool x = false;
        bool y = false;
        bool z = false;

        foreach (int[] t in triplets)
        {
            // This triplet can never be part of the target
            if (t[0] > target[0] ||
                t[1] > target[1] ||
                t[2] > target[2])
            {
                continue;
            }

            // Check which target values this triplet can provide
            if (t[0] == target[0])
                x = true;

            if (t[1] == target[1])
                y = true;

            if (t[2] == target[2])
                z = true;
        }

        return x && y && z;
    }
}