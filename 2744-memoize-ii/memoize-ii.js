var memoize = function(fn) {
    const cache = new Map();
    const RESULT = Symbol("result");

    return function(...args) {
        let current = cache;

        // Check each argument
        for (const arg of args) {
            if (!current.has(arg)) {
                current.set(arg, new Map());
            }

            current = current.get(arg);
        }

        // If result already exists, return it
        if (current.has(RESULT)) {
            return current.get(RESULT);
        }

        // First time these exact inputs are seen
        const result = fn(...args);

        // Store result
        current.set(RESULT, result);

        return result;
    };
};