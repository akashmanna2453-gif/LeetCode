int furthestDistanceFromOrigin(char* moves) {
    int left = 0;
    int right = 0;
    int blank = 0;

    for (int i = 0; moves[i] != '\0'; i++) {

        if (moves[i] == 'L')
            left++;

        else if (moves[i] == 'R')
            right++;

        else
            blank++;
    }

    return abs(right - left) + blank;
}