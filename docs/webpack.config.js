const path = require("path");
const webpack = require("webpack");
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');

var babelOptions = {
    presets: [
        ["@babel/preset-env", {
            "targets": {
                "browsers": ["last 2 versions"]
            },
            "modules": false
        }]
    ]
};

var commonPlugins = [
    new HtmlWebpackPlugin({
        filename: './index.html',
        template: './docs/index.html',
        hash: true,
        minify: isProduction ? {} : false
    })
];


var isProduction = !process.argv.find(v => v.indexOf('webpack-dev-server') !== -1);
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
    entry: isProduction ? // We don't use the same entry for dev and production, to make HMR over style quicker for dev env
        {
            demo: [
                "@babel/polyfill",
                './docs/docs.fsproj',
                './docs/scss/main.scss'
            ]
        } : {
            app: [
                "@babel/polyfill",
                './docs/docs.fsproj',
            ],
            style: [
                './docs/scss/main.scss'
            ]
        },
    mode: isProduction ? "production" : "development",
    output: {
        path: path.join(__dirname, './public'),
        filename: isProduction ? '[name].[hash].js' : '[name].js'
    },
    optimization: {
        // Split the code coming from npm packages into a different file.
        // 3rd party dependencies change less often, let the browser cache them.
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /node_modules/,
                    name: "vendors",
                    chunks: "all"
                }
            }
        },
    },
    plugins: isProduction ?
        commonPlugins.concat([
            new MiniCssExtractPlugin({
                filename: 'style.[hash].css'
            }),
            new UglifyJSPlugin({
                uglifyOptions: {
                    compress: { inline: false }
                }
            })
        ])
        : commonPlugins.concat([
            new webpack.HotModuleReplacementPlugin(),
            new webpack.NamedModulesPlugin()
        ]),
    devServer: {
        contentBase: './docs/public/',
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
                        define: isProduction ? [] : ["DEBUG"]
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
                test: /\.(sass|scss|css)$/,
                use: [
                    isProduction ? MiniCssExtractPlugin.loader : 'style-loader',
                    'css-loader',
                    'sass-loader',
                ],
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            }
        ]
    }
};
