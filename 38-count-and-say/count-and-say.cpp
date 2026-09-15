class Solution {
public:
    string countAndSay(int n) {
        string current = "1";

        for (int i = 2; i <= n; i++) {
            string next = "";

            int j = 0;

            while (j < current.length()) {
                int count = 0;
                char digit = current[j];

                while (j < current.length() && current[j] == digit) {
                    count++;
                    j++;
                }

                next += to_string(count);
                next += digit;
            }

            current = next;
        }

        return current;
    }
};