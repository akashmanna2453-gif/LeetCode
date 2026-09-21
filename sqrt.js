var mySqrt = function(x) {
    if (x < 2) return x;

    let left = 1;
    let right = Math.floor(x / 2);
    let answer = 1;

    while (left <= right) {
        let mid = Math.floor((left + right) / 2);

        if (mid <= Math.floor(x / mid)) {
            answer = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return answer;
};