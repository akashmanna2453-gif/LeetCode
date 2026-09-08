class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        seen = {}

        for i, num in enumerate(nums):
            required = target - num

            if required in seen:
                return [seen[required], i]

            seen[num] = i