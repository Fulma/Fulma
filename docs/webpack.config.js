const path = require("path");
const webpack = require("webpack");
const fableUtils = require("fable-utils");
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

function resolve(filePath) {
    return path.join(__dirname, filePath)
}

var babelOptions = fableUtils.resolveBabelOptions({
    presets: [["env", { "modules": false }]]
});

var commonPlugins = [
    new HtmlWebpackPlugin({
        filename: resolve('./public/index.html'),
        template: resolve('./index.html'),
        hash: true,
        minify: isProduction ? {} : false
    })
];


var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
    entry: isProduction ? // We don't use the same entry for dev and production, to make HMR over style quicker for dev env
        {
            demo: [
                "babel-polyfill",
                resolve('./docs.fsproj'),
                resolve('./scss/main.scss')
            ]
        } : {
            app: [
                "babel-polyfill",
                resolve('./docs.fsproj'),
            ],
            style: [
                resolve('./scss/main.scss')
            ]
        },
    output: {
        path: resolve('./public'),
        filename: isProduction ? '[name].[hash].js' : '[name].js'
    },
    plugins: isProduction ?
        commonPlugins.concat([
            new ExtractTextPlugin('style.css'),
            new webpack.optimize.CommonsChunkPlugin({
                name: "manifest",
                minChunks: Infinity
            })
        ])
        : commonPlugins.concat([
            new webpack.HotModuleReplacementPlugin(),
            new webpack.NamedModulesPlugin()
        ]),
    resolve: {
        modules: [resolve("../node_modules/")]
    },
    devServer: {
        contentBase: resolve('./public/'),
        port: 8080,
        hot: true,
        inline: true
    },
    module: {
        rules: [
            {
                test: /\.fs(x|proj)?$/,
                use: {
                    loader: "fable-loader",
                    options: {
                        babel: babelOptions,
                        define: isProduction ? [] : ["DEBUG"],
                        plugins: path.join(__dirname, "./Plugins/bin/Release/netstandard2.0/Fable.Plugins.ImportExample.dll")
                    }
                }
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: babelOptions
                },
            },
            {
                test: /\.s(a|c)ss$/,
                use: ["style-loader", "css-loader", "sass-loader"]
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            }
        ]
    }
};
