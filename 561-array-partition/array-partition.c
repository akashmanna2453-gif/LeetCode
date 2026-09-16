#include <stdlib.h>

int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int arrayPairSum(int* nums, int numsSize) {
    int sum = 0;

    qsort(nums, numsSize, sizeof(int), compare);

    for (int i = 0; i < numsSize; i += 2) {
        sum += nums[i];
    }

    return sum;
}