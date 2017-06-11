import fable from 'rollup-plugin-fable';
import livereload from 'rollup-plugin-livereload';
import serve from 'rollup-plugin-serve';
import cjs from 'rollup-plugin-commonjs';
import nodeResolve from 'rollup-plugin-node-resolve';


export default {
    entry: './docs.fsproj',
    dest: './public/bundle.js',
    plugins: [
        fable(),
        livereload(),
        serve({
            contentBase: 'public',
            port: 8080
        }),
        cjs({
            include: '../node_modules/**',
            namedExports: {
                'react': [ 'createElement', 'Component' ],
                'react-dom': [ 'render' ]
            }
        }),
        nodeResolve({ jsnext: true, main: true, browser: true })
    ],
    format: 'cjs'
};
