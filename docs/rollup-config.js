import fable from 'rollup-plugin-fable';
import livereload from 'rollup-plugin-livereload';
import serve from 'rollup-plugin-serve';
import cjs from 'rollup-plugin-commonjs';
import nodeResolve from 'rollup-plugin-node-resolve';
import replace from 'rollup-plugin-replace';
import postcss from 'rollup-plugin-postcss';
import sass from 'node-sass';

const preprocessor = (content, id) => new Promise((resolve, reject) => {
    const result = sass.renderSync({ file: id });
    resolve({ code: result.css.toString() });
});

export default {
    entry: './docs.fsproj',
    dest: './public/dist/js/bundle.js',
    plugins: [
        fable({
            extra: {
                useCache: true
            }
        }),
        livereload(),
        serve({
            contentBase: 'public',
            port: 8080
        }),
        cjs({
            include: '../node_modules/**',
            namedExports: {
                'react': ['createElement', 'Component'],
                'react-dom': ['render']
            }
        }),
        nodeResolve({ jsnext: true, main: true, browser: true }),
        replace({ 'process.env.NODE_ENV': JSON.stringify('development') }),
        postcss({
            plugins: [
            ],
            extract: './public/dist/css/bundle.css', // default value
            preprocessor,
            extensions: ['.css', '.sass']  // default value
        })
    ],
    format: 'iife',
    moduleName: 'bulmaDocSite'
};
