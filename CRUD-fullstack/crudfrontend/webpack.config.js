import { join } from "path";

export const entry = "./src/index.js";
export const output = {
    path: join(__dirname, "/build"),
    filename: "bundle.js", // Tên file được build ra
};
export const module = {
    rules: [
        {
            test: /\.js$/,
            exclude: /node_modules/,
            use: ["babel-loader"],
        },
        {
            test: /\.css$/,
            use: ["style-loader", "css-loader"],
        },
    ],
};
export const plugins = [];
