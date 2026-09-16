var cancellable = function(generator) {
    let cancel = () => {};

    const cancelPromise = new Promise((resolve, reject) => {
        cancel = () => reject("Cancelled");
    });

    // Prevent unhandled rejection
    cancelPromise.catch(() => {});

    const promise = (async () => {
        let next = generator.next();

        while (!next.done) {
            try {
                const value = await Promise.race([
                    next.value,
                    cancelPromise
                ]);

                next = generator.next(value);

            } catch (error) {
                next = generator.throw(error);
            }
        }

        return next.value;
    })();

    return [cancel, promise];
};