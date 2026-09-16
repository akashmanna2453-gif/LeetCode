class Solution {
public:
    vector<vector<string>> result;
    unordered_map<string, vector<string>> parents;
    unordered_map<string, int> dist;

    void dfs(string word, string beginWord, vector<string>& path) {
        if (word == beginWord) {
            reverse(path.begin(), path.end());
            result.push_back(path);
            reverse(path.begin(), path.end());
            return;
        }

        for (string parent : parents[word]) {
            path.push_back(parent);
            dfs(parent, beginWord, path);
            path.pop_back();
        }
    }

    vector<vector<string>> findLadders(
        string beginWord,
        string endWord,
        vector<string>& wordList
    ) {
        unordered_set<string> words(wordList.begin(), wordList.end());

        if (!words.count(endWord))
            return {};

        queue<string> q;
        q.push(beginWord);
        dist[beginWord] = 0;

        bool found = false;

        while (!q.empty() && !found) {
            int size = q.size();

            unordered_set<string> usedThisLevel;

            for (int i = 0; i < size; i++) {
                string word = q.front();
                q.pop();

                string temp = word;

                for (int j = 0; j < word.size(); j++) {
                    char original = word[j];

                    for (char c = 'a'; c <= 'z'; c++) {
                        if (c == original)
                            continue;

                        word[j] = c;

                        if (!words.count(word))
                            continue;

                        // First time reaching this word
                        if (!dist.count(word)) {
                            dist[word] = dist[temp] + 1;
                            q.push(word);
                            usedThisLevel.insert(word);

                            parents[word].push_back(temp);

                            if (word == endWord)
                                found = true;
                        }
                        // Another shortest path to the same word
                        else if (dist[word] == dist[temp] + 1) {
                            parents[word].push_back(temp);
                        }
                    }

                    word[j] = original;
                }
            }

            // Remove words only after completing the level
            // so multiple shortest parents can be found.
            for (string word : usedThisLevel) {
                words.erase(word);
            }
        }

        if (!dist.count(endWord))
            return {};

        vector<string> path;
        path.push_back(endWord);

        dfs(endWord, beginWord, path);

        return result;
    }
};