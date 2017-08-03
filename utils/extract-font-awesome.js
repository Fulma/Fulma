// Go to http://fontawesome.io/cheatsheet/
// Copy & Paste the following code into the console
// You will get a textarea will all the icons clases converted into an DU
// Copy & Paste the DU into the right file

// Get all the icons cells
var rawData = Array.prototype.slice.call(document.querySelectorAll(".col-md-4.col-sm-6.col-lg-3.col-print-4"));

var icons = [];

// Extratc only the class name
rawData.forEach(function(element) {
    icons.push(element.innerText.split(' ')[1]);
}, this);

var cleaned =
`[<StringEnum>]
type FontAwesomeIcons =
    |` +
    icons
        .map(function (element) {
            return ` [<CompiledName("${element}")>] ` + element
                .replace("fa-", "")
                .split("-")
                .map(function (element) {
                    return element.replace(/\b\w/g, function (l) { return l.toUpperCase() })
                }, this)
                .join("") + " ";
        }, this)
        .join(`\n    |`);


var textarea = document.createElement("textarea");
textarea.style.width = "100%";
textarea.rows = 30;
textarea.textContent = cleaned;
document.body.innerHTML = "";
document.body.appendChild(textarea);
