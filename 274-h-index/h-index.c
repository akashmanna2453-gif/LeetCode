int hIndex(int* citations, int citationsSize) {
    int h = 0;

    for (int i = 1; i <= citationsSize; i++) {
        int count = 0;

        for (int j = 0; j < citationsSize; j++) {
            if (citations[j] >= i) {
                count++;
            }
        }

        if (count >= i) {
            h = i;
        }
    }

    return h;
}