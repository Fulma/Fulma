const path = require("path");
const webpack = require("webpack");
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyWebpackPlugin = require('copy-webpack-plugin');

var babelOptions = {
    presets: [
        ["@babel/preset-env", {
            "targets": {
                "browsers": ["last 2 versions"]
            },
            "modules": false,
            "useBuiltIns": "usage",
            "corejs": 3,
            // This saves around 4KB in minified bundle (not gzipped)
            // "loose": true,
        }]
    ],
};

var commonPlugins = [
    new HtmlWebpackPlugin({
        filename: './index.html',
        template: './src/index.html'
    })
];

module.exports = (env, options) => {

    // If no mode has been defined, default to `development`
    if (options.mode === undefined)
        options.mode = "development";

    var isProduction = options.mode === "production";
    console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

    return {
        devtool: undefined,
        entry: isProduction ? // We don't use the same entry for dev and production, to make HMR over style quicker for dev env
            {
                demo: [
                    "@babel/polyfill",
                    './src/FulmaMinimalTemplate.fsproj',
                    './src/scss/main.scss'
                ]
            } : {
                app: [
                    "@babel/polyfill",
                    './src/FulmaMinimalTemplate.fsproj'
                ],
                style: [
                    './src/scss/main.scss'
                ]
            },
        output: {
            path: path.join(__dirname, './output'),
            filename: isProduction ? '[name].[hash].js' : '[name].js'
        },
        plugins: isProduction ?
            commonPlugins.concat([
                new MiniCssExtractPlugin({
                    filename: 'style.css'
                }),
                new CopyWebpackPlugin([
                    { from: './static' }
                ])
            ])
            : commonPlugins.concat([
                new webpack.HotModuleReplacementPlugin(),
                new webpack.NamedModulesPlugin()
            ]),
        devServer: {
            contentBase: './static/',
            publicPath: "/",
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
                            babel: babelOptions
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
                        isProduction
                            ? MiniCssExtractPlugin.loader
                            : 'style-loader',
                        'css-loader',
                        'sass-loader',
                    ],
                },
                {
                    test: /\.css$/,
                    use: ['style-loader', 'css-loader']
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)(\?.*$|$)/,
                    use: ["file-loader"]
                }
            ]
        }
    };
}
