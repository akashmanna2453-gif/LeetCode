import java.util.*;

class Solution {
    public int[][] merge(int[][] intervals) {

        // Step 1: Sort intervals by starting time
        Arrays.sort(intervals, (a, b) -> Integer.compare(a[0], b[0]));

        List<int[]> result = new ArrayList<>();

        // Step 2: Start with the first interval
        int start = intervals[0][0];
        int end = intervals[0][1];

        // Step 3: Check every next interval
        for (int i = 1; i < intervals.length; i++) {

            // If intervals overlap
            if (intervals[i][0] <= end) {
                end = Math.max(end, intervals[i][1]);
            } 
            else {
                // No overlap → store current interval
                result.add(new int[]{start, end});

                // Start a new interval
                start = intervals[i][0];
                end = intervals[i][1];
            }
        }

        // Add the last interval
        result.add(new int[]{start, end});

        return result.toArray(new int[result.size()][]);
    }
}