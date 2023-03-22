function html([first, ...string], ...values) {
    let str = values
        .reduce(
            (acc, curr) => {
                return acc.concat(curr, string.shift());
            },
            [first],
        )
        .filter((x) => (x && x !== true) || x === 0)
        .join("");
    return str;
}
