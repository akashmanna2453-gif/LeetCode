class Solution {
    public void merge(int[] nums1, int m, int[] nums2, int n) {

        int i = m - 1;       // nums1 ka last actual element
        int j = n - 1;       // nums2 ka last element
        int k = m + n - 1;   // nums1 ka last position

        // Jab tak nums2 ke elements bache hain
        while (j >= 0) {

            if (i >= 0 && nums1[i] > nums2[j]) {
                nums1[k] = nums1[i];
                i--;
            } else {
                nums1[k] = nums2[j];
                j--;
            }

            k--;
        }
    }
}