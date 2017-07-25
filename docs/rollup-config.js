import fable from 'rollup-plugin-fable';
import livereload from 'rollup-plugin-livereload';
import serve from 'rollup-plugin-serve';
import cjs from 'rollup-plugin-commonjs';
import nodeResolve from 'rollup-plugin-node-resolve';
import replace from 'rollup-plugin-replace';
import postcss from 'rollup-plugin-postcss';
import sass from 'node-sass';
import babel from "rollup-plugin-babel";

var babelOptions = {
    presets: [["es2015", { "modules": false }]],
    plugins: ["external-helpers"]
};

const preprocessor = (content, id) => new Promise((resolve, reject) => {
    const result = sass.renderSync({ file: id });
    resolve({ code: result.css.toString() });
});

const isWatching = process.argv.some(x => x === "-w");

let rollupPlugins = [
    fable({
        babel: babelOptions
    }),
    babel(Object.assign({
        exclude: ["../node_modules/**", "**/*.sass", "**/*.css"]
    }, babelOptions)),
    cjs({
        include: '../node_modules/**',
        namedExports: {
            'react': ['createElement', 'Component'],
            'react-dom': ['render']
        }
    }),
    nodeResolve({ jsnext: true, main: true, browser: true }),
    replace({ 'process.env.NODE_ENV':
        JSON.stringify(isWatching ? 'development' : 'production')}),
    postcss({
        plugins: [
        ],
        extract: './public/dist/css/bundle.css', // default value
        preprocessor,
        extensions: ['.css', '.sass']  // default value
    })
];

if (isWatching) {
    console.log("Bundling for development...");
    rollupPlugins.splice(0, 0,
        livereload(),
        serve({
            contentBase: 'public',
            port: 8080
        }));
}
else {
    console.log("Bundling for production...");
}

export default {
    entry: './docs.fsproj',
    dest: './public/dist/js/bundle.js',
    plugins: rollupPlugins,
    format: 'iife',
    moduleName: 'bulmaDocSite'
};
