class Solution:
    def nextPermutation(self, nums):
        n = len(nums)

        # Step 1: Find the first decreasing element from the right
        i = n - 2

        while i >= 0 and nums[i] >= nums[i + 1]:
            i -= 1

        # Step 2: If such an element exists, find the next greater element
        if i >= 0:
            j = n - 1

            while nums[j] <= nums[i]:
                j -= 1

            nums[i], nums[j] = nums[j], nums[i]

        # Step 3: Reverse the elements after i
        left = i + 1
        right = n - 1

        while left < right:
            nums[left], nums[right] = nums[right], nums[left]
            left += 1
            right -= 1