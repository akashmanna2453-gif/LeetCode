var fullJustify = function(words, maxWidth) {
    let result = [];
    let i = 0;

    while (i < words.length) {
        let line = [];
        let length = 0;

        // Maximum words ek line mein pack karo
        while (
            i < words.length &&
            length + words[i].length + line.length <= maxWidth
        ) {
            line.push(words[i]);
            length += words[i].length;
            i++;
        }

        // Last line OR single word line
        if (i === words.length || line.length === 1) {
            let str = line.join(" ");
            str += " ".repeat(maxWidth - str.length);
            result.push(str);
            continue;
        }

        // Total spaces jo distribute karne hain
        let spaces = maxWidth - length;
        let gaps = line.length - 1;

        let extra = Math.floor(spaces / gaps);
        let remainder = spaces % gaps;

        let str = "";

        for (let j = 0; j < gaps; j++) {
            str += line[j];
            str += " ".repeat(extra);

            // Left gaps ko 1 extra space
            if (j < remainder) {
                str += " ";
            }
        }

        str += line[line.length - 1];

        result.push(str);
    }

    return result;
};