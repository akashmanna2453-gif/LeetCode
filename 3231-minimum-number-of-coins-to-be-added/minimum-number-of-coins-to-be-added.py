class Solution:
    def minimumAddedCoins(self, coins: List[int], target: int) -> int:
        coins.sort()

        added = 0
        i = 0
        reachable = 1

        while reachable <= target:
            if i < len(coins) and coins[i] <= reachable:
                reachable += coins[i]
                i += 1
            else:
                reachable += reachable
                added += 1

        return added