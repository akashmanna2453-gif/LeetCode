class Solution {
    public int furthestDistanceFromOrigin(String moves) {

        int left = 0;
        int right = 0;
        int blank = 0;

        for (char ch : moves.toCharArray()) {

            if (ch == 'L') {
                left++;
            }
            else if (ch == 'R') {
                right++;
            }
            else {
                blank++;
            }
        }

        // Move blanks in the direction that increases distance
        return Math.abs(right - left) + blank;
    }
}