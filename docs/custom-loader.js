var utils = require('loader-utils');

function getFunctionCode(lines, functionName) {
    var codeLines = [];
    var firstMeaningFulChar = 0;

    var isInsideBlockCode = false;
    for (let index = 0; index < lines.length; index++) {
        const line = lines[index];

        if (line.includes(functionName)) {
            isInsideBlockCode = true;
            // Skip function definition line
            continue;
        }

        if (isInsideBlockCode) {
            if (line === "")
                break;

            if (codeLines.length == 0)
                firstMeaningFulChar = line.search(/\S/);


            codeLines.push(line.substring(firstMeaningFulChar));
        }

    }

    return codeLines;
}

function getStatefulComponentCode(lines, typeName) {
    var codeLines = [];
    typeName = `type ${typeName}(`;
    var firstMeaningFulChar = 0;

    var isInsideComponent = false;
    var isInsideRender = false;
    for (let index = 0; index < lines.length; index++) {
        const line = lines[index];

        if (line.includes(typeName)) {
            isInsideComponent = true;
            continue;
        }

        if (isInsideComponent) {
            if (line.includes("override this.render () =")) {
                isInsideRender = true;
                // Skip render method line
                continue;
            }

            if (isInsideRender) {
                if (line === "")
                   break;

                if (codeLines.length == 0)
                    firstMeaningFulChar = line.search(/\S/);

                    codeLines.push(line.substring(firstMeaningFulChar));
            }
        }
    }

    return codeLines;
}

var loader = function(source) {
    var callback = this.async();

    var options = utils.getOptions(this);

    // Stop here, if this isn't a call to include the code
    if (options == null || options.line == null) {
        callback(null);
        return;
    }

    var lines = source.replace(/(\r\n|\n|\r)/gm,"\n").split("\n");
    var refLine = lines[options.line - 1];
    var matches = refLine.match(/(\(Widgets\.Showcase\.view \(fun _ -> ofType<([^\s,]+))|(Widgets\.Showcase\.view ([^\s]+))/);
    var codeLines = [];

    if (matches[2] !== undefined) {
        codeLines = getStatefulComponentCode(lines, matches[2]);
    }

    if (matches[4] !== undefined) {
        codeLines = getFunctionCode(lines, matches[4]);
    }

    var code =
        codeLines
            .join("\\n")
            .replace(/"/g, '\\"');

    callback(null, `module.exports = "${ code }"`);
}

module.exports = loader;
