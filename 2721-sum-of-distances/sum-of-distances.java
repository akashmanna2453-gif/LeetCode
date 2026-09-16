import java.util.*;

class Solution {

    public long[] distance(int[] nums) {

        int n = nums.length;
        long[] ans = new long[n];

        Map<Integer, long[]> map = new HashMap<>();

        // Left to right
        for (int i = 0; i < n; i++) {

            if (map.containsKey(nums[i])) {

                long[] data = map.get(nums[i]);

                long count = data[0];
                long sum = data[1];

                ans[i] += count * i - sum;
            }

            map.putIfAbsent(nums[i], new long[2]);

            long[] data = map.get(nums[i]);

            data[0]++;
            data[1] += i;
        }

        map.clear();

        // Right to left
        for (int i = n - 1; i >= 0; i--) {

            if (map.containsKey(nums[i])) {

                long[] data = map.get(nums[i]);

                long count = data[0];
                long sum = data[1];

                ans[i] += sum - count * i;
            }

            map.putIfAbsent(nums[i], new long[2]);

            long[] data = map.get(nums[i]);

            data[0]++;
            data[1] += i;
        }

        return ans;
    }
}