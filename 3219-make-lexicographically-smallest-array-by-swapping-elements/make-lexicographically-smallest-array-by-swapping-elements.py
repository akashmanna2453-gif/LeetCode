class Solution:
    def lexicographicallySmallestArray(self, nums: List[int], limit: int) -> List[int]:
        n = len(nums)

        # Store (value, original index)
        pairs = sorted((nums[i], i) for i in range(n))

        result = nums[:]

        start = 0

        while start < n:
            end = start

            # Find all values connected by the limit
            while end + 1 < n and pairs[end + 1][0] - pairs[end][0] <= limit:
                end += 1

            # Original indices of this group
            indices = [pairs[k][1] for k in range(start, end + 1)]
            indices.sort()

            # Values are already sorted
            for k in range(len(indices)):
                result[indices[k]] = pairs[start + k][0]

            start = end + 1

        return result