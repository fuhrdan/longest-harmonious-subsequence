//*****************************************************************************
//** 594. Longest Harmonious Subsequence                            leetcode **
//*****************************************************************************

int findIndex(int* keys, int size, int key) {
    for (int i = 0; i < size; i++) {
        if (keys[i] == key) return i;
    }
    return -1;
}

int findLHS(int* nums, int numsSize) {
    int* keys = malloc(numsSize * sizeof(int));   // store unique numbers
    int* counts = malloc(numsSize * sizeof(int)); // store counts for each unique number
    int uniqueCount = 0;

    // Build frequency map manually
    for (int i = 0; i < numsSize; i++) {
        int idx = findIndex(keys, uniqueCount, nums[i]);
        if (idx == -1) {
            keys[uniqueCount] = nums[i];
            counts[uniqueCount] = 1;
            uniqueCount++;
        } else {
            counts[idx]++;
        }
    }

    int maxLength = 0;

    // For each unique number, check if number + 1 exists, then sum counts
    for (int i = 0; i < uniqueCount; i++) {
        int idxPlusOne = findIndex(keys, uniqueCount, keys[i] + 1);
        if (idxPlusOne != -1) {
            int sum = counts[i] + counts[idxPlusOne];
            if (sum > maxLength) {
                maxLength = sum;
            }
        }
    }

    free(keys);
    free(counts);

    return maxLength;
}