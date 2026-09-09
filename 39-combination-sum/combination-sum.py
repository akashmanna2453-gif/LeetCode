class Solution:
    def combinationSum(self, candidates, target):
        result = []

        def backtrack(start, current, total):
            if total == target:
                result.append(current.copy())
                return

            if total > target:
                return

            for i in range(start, len(candidates)):
                current.append(candidates[i])

                # i is passed again because the same number
                # can be used unlimited times
                backtrack(i, current, total + candidates[i])

                current.pop()

        backtrack(0, [], 0)

        return result