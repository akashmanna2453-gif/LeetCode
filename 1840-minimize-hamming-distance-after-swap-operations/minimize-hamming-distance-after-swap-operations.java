import java.util.*;

class Solution {

    int[] parent;

    public int minimumHammingDistance(
            int[] source,
            int[] target,
            int[][] allowedSwaps) {

        int n = source.length;

        // DSU initialization
        parent = new int[n];

        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }

        // Connect all allowed swap indices
        for (int[] swap : allowedSwaps) {
            union(swap[0], swap[1]);
        }

        // Map each component to frequency of source values
        Map<Integer, Map<Integer, Integer>> groups = new HashMap<>();

        for (int i = 0; i < n; i++) {

            int root = find(i);

            groups.putIfAbsent(root, new HashMap<>());

            Map<Integer, Integer> map = groups.get(root);

            map.put(source[i], map.getOrDefault(source[i], 0) + 1);
        }

        int answer = 0;

        // Match source values with target values
        for (int i = 0; i < n; i++) {

            int root = find(i);

            Map<Integer, Integer> map = groups.get(root);

            int value = target[i];

            int count = map.getOrDefault(value, 0);

            if (count > 0) {
                // Matching value found
                map.put(value, count - 1);
            } else {
                // Cannot match this position
                answer++;
            }
        }

        return answer;
    }

    // Find with path compression
    private int find(int x) {

        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }

        return parent[x];
    }

    // Union
    private void union(int a, int b) {

        int rootA = find(a);
        int rootB = find(b);

        if (rootA != rootB) {
            parent[rootA] = rootB;
        }
    }
}