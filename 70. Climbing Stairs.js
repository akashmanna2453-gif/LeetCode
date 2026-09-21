var climbStairs = function(n) {
    if (n <= 2) return n;

    let a = 1;
    let b = 2;

    for (let i = 3; i <= n; i++) {
        let c = a + b;
        a = b;
        b = c;
    }

    return b;
};