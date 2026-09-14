public class Solution
{
    public int MinWastedSpace(int[] packages, int[][] boxes)
    {
        const long MOD = 1000000007;

        Array.Sort(packages);

        long totalPackageSize = 0;

        foreach (int p in packages)
            totalPackageSize += p;

        long answer = long.MaxValue;

        foreach (int[] supplier in boxes)
        {
            Array.Sort(supplier);

            // Largest box must fit the largest package
            if (supplier[supplier.Length - 1] < packages[packages.Length - 1])
                continue;

            long waste = 0;
            int prev = 0;

            foreach (int boxSize in supplier)
            {
                // Find first package that is > boxSize
                int next = UpperBound(packages, boxSize);

                // Packages from prev to next-1 fit in this box
                if (next > prev)
                {
                    waste += (long)(next - prev) * boxSize;
                    prev = next;
                }

                if (prev == packages.Length)
                    break;
            }

            waste -= totalPackageSize;

            answer = Math.Min(answer, waste);
        }

        return answer == long.MaxValue ? -1 : (int)(answer % MOD);
    }

    private int UpperBound(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] <= target)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}