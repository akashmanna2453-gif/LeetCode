class Solution {
    static final long MOD = 1000000007;

    public int numberOfSets(int n, int k) {

        long[][] dp = new long[k + 1][n];

        // 0 segments: 1 way
        for (int i = 0; i < n; i++) {
            dp[0][i] = 1;
        }

        for (int segments = 1; segments <= k; segments++) {

            long sum = 0;

            for (int points = 1; points < n; points++) {

                // Ways to start/continue a segment
                sum = (sum + dp[segments - 1][points - 1]) % MOD;

                // Add current ways
                dp[segments][points] =
                    (dp[segments][points - 1] + sum) % MOD;
            }
        }

        return (int) dp[k][n - 1];
    }
}