// Go to https://fontawesome.com/cheatsheet
// Copy & Paste the following code into the console
// You will get a textarea will all the icons clases converted into an DU
// Copy & Paste the DU into the right file

//select solid, regular and brands sections
var rawData = Array.prototype.slice.call(document.querySelectorAll(".cheatsheet-set"));

var sets = [];

rawData.forEach(element => {
    var articles = element.querySelectorAll('article');

    var icons = [];
    articles.forEach(icon => {
        icons.push(icon.getAttribute('id'));
    });

    sets.push([element.getAttribute('id'), icons]);
});

// Extract only the class name
var cleaned =
sets
    .map(function (set) {
        var name = set[0];
        var icons = set[1];
        return `[<StringEnum>]
            type ` + name.charAt(0).toUpperCase() + name.slice(1) + ` =
                |` +
                icons
                    .map(function (icon) {
                        var compileName = 'fa' + name.charAt(0) + ' fa-' + icon
                        return ` [<CompiledName("${compileName}")>] ` + icon
                            .split("-")
                            .map(function (element) {
                                return element.replace(/\b\w/g, function (l) { return l.toUpperCase() })
                            }, this)
                            .join("") + " ";
                    }, this)
                    .join(`\n    |`);
    }, this)
    .join(`\n\n    `);

var textarea = document.createElement("textarea");
textarea.style.width = "100%";
textarea.rows = 30;
textarea.textContent = cleaned;
document.body.innerHTML = "";
document.body.appendChild(textarea);