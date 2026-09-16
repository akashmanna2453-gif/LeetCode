import java.util.*;

class Solution {

    public List<String> twoEditWords(String[] queries, String[] dictionary) {

        List<String> result = new ArrayList<>();

        for (String query : queries) {

            for (String word : dictionary) {

                int differences = 0;

                for (int i = 0; i < query.length(); i++) {

                    if (query.charAt(i) != word.charAt(i)) {
                        differences++;
                    }

                    // More than 2 edits → no need to continue
                    if (differences > 2) {
                        break;
                    }
                }

                // Found a dictionary word within 2 edits
                if (differences <= 2) {
                    result.add(query);
                    break;
                }
            }
        }

        return result;
    }
}