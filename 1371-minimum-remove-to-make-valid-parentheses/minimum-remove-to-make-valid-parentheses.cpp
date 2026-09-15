class Solution {
public:
    string minRemoveToMakeValid(string s) {
        stack<int> st;
        vector<bool> remove(s.length(), false);

        // Find invalid parentheses
        for (int i = 0; i < s.length(); i++) {

            if (s[i] == '(') {
                st.push(i);
            }
            else if (s[i] == ')') {

                if (st.empty()) {
                    // No matching '('
                    remove[i] = true;
                }
                else {
                    st.pop();
                }
            }
        }

        // Any remaining '(' is invalid
        while (!st.empty()) {
            remove[st.top()] = true;
            st.pop();
        }

        // Build answer
        string ans;

        for (int i = 0; i < s.length(); i++) {
            if (!remove[i]) {
                ans += s[i];
            }
        }

        return ans;
    }
};