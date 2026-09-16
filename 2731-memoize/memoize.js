function memoize(fn) {
    const cache = new Map();
    let callCount = 0;

    const memoized = function(...args) {
        const key = JSON.stringify(args);

        if (cache.has(key)) {
            return cache.get(key);
        }

        callCount++;

        const result = fn(...args);

        cache.set(key, result);

        return result;
    };

    memoized.getCallCount = function() {
        return callCount;
    };

    return memoized;
}