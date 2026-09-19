#include <stdlib.h>

typedef struct {
    int value;
    int index;
} Pair;

int compare(const void *a, const void *b) {
    Pair *p1 = (Pair *)a;
    Pair *p2 = (Pair *)b;

    if (p1->value != p2->value)
        return p1->value - p2->value;

    return p1->index - p2->index;
}

long long* distance(int* nums, int numsSize, int* returnSize) {

    long long *ans = calloc(numsSize, sizeof(long long));

    Pair *pairs = malloc(numsSize * sizeof(Pair));

    *returnSize = numsSize;

    // Store value and original index
    for (int i = 0; i < numsSize; i++) {
        pairs[i].value = nums[i];
        pairs[i].index = i;
    }

    // Sort by value
    qsort(pairs, numsSize, sizeof(Pair), compare);

    int start = 0;

    while (start < numsSize) {

        int end = start;

        // Find all equal values
        while (end < numsSize &&
               pairs[end].value == pairs[start].value) {
            end++;
        }

        int count = end - start;

        // Total sum of indices of this group
        long long totalSum = 0;

        for (int i = start; i < end; i++) {
            totalSum += pairs[i].index;
        }

        long long prefixSum = 0;

        for (int k = 0; k < count; k++) {

            long long idx = pairs[start + k].index;

            // Distance from elements on the left
            long long leftCount = k;
            long long left =
                idx * leftCount - prefixSum;

            // Distance from elements on the right
            long long rightCount = count - k - 1;

            long long rightSum =
                totalSum - prefixSum - idx;

            long long right =
                rightSum - idx * rightCount;

            ans[idx] = left + right;

            prefixSum += idx;
        }

        start = end;
    }

    free(pairs);

    return ans;
}