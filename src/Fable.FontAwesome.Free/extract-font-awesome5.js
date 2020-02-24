// Go to https://fontawesome.com/cheatsheet/free
// Copy & Paste the following code into the console
// You will get a textarea will all the icons classes converted
// Copy & Paste the result into the right file

var tabSize_1 = `    `;
var tabSize_2 = tabSize_1.repeat(2);
var tabSize_3 = tabSize_1.repeat(3);

function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

async function generateModule(sectionId, faPrefix, moduleName) {
    const tab = document.querySelector(`a[href*='/cheatsheet/free/${sectionId}']`);
    tab.click();
    await sleep(2000); // Delay to be sure the view has been loaded
    var iconList = [];

    document.querySelectorAll("main section article")
        .forEach(icon => {
            iconList.push(icon.getAttribute('id'));
        });

    var res =
        `${tabSize_2}module ${moduleName} =
`
            +
            iconList
            .map(function (icon) {
                var functionName =
                    icon
                    .split("-")
                    .map(function (element) {
                        return element.replace(/\b\w/g, function (l) { return l.toUpperCase() })
                    }, this)
                    .join("");

                functionName = functionName.match(/^\d.*/) ? "``" + functionName + "``" : functionName;

                return `${tabSize_3}let inline ${functionName}<'a> = Fable.FontAwesome.Fa.Icon "${faPrefix} fa-${icon}"`;
            }, this)
            .join(`\n`);
    return res + "\n\n";
}

(async () => {
    var generatedModules =
        `// This files has been generated using a script do not edit it

namespace Fable.FontAwesome

open Fable.Core

[<AutoOpen>]
module Free =

    [<RequireQualifiedAccess>]
    module Fa =

`
    + await generateModule("solid", "fas", "Solid")
    + await generateModule("regular", "far", "Regular")
    + await generateModule("brands", "fab", "Brand");

    var textarea = document.createElement("textarea");
    textarea.style.width = "100%";
    textarea.rows = 30;
    textarea.textContent = generatedModules;
    document.body.innerHTML = "";
    document.body.appendChild(textarea);

})()
