class Solution:
    def permute(self, nums):
        result = []

        def backtrack(current, remaining):
            if len(remaining) == 0:
                result.append(current[:])
                return

            for i in range(len(remaining)):
                current.append(remaining[i])

                next_remaining = remaining[:i] + remaining[i+1:]

                backtrack(current, next_remaining)

                current.pop()

        backtrack([], nums)

        return result