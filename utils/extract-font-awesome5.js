// Go to https://fontawesome.com/cheatsheet/pro
// Copy & Paste the following code into the console
// You will get a textarea will all the icons clases converted into an DU
// Copy & Paste the DU into the right file

//select solid, regular and brands sections
var iconsSection = Array.prototype.slice.call(document.querySelectorAll("#solid"));
var brandsSection = Array.prototype.slice.call(document.querySelectorAll("#brands"));

var icons = [];
var brands = [];

brandsSection.forEach(element => {
    var articles = element.querySelectorAll('article');
    articles.forEach(icon => {
        brands.push(icon.getAttribute('id'));
    });
});

iconsSection.forEach(element => {
    var articles = element.querySelectorAll('article');
    articles.forEach(icon => {
        icons.push(icon.getAttribute('id'));
    });
});

// Extract only the class name
var brandsDu =
`[<StringEnum>]
type FontAwesomeBrands =
    |` +
    brands
    .map(function (element) {
        var compileName = 'fa-' + element
        return ` [<CompiledName("${compileName}")>] ` + element
            .split("-")
            .map(function (element) {
                return element.replace(/\b\w/g, function (l) { return l.toUpperCase() })
            }, this)
            .join("") + " ";
    }, this)
    .join(`\n    |`);

var iconsDu =
    `[<StringEnum>]
    type FontAwesomeIcons =
        |` +
        icons
        .map(function (element) {
            var compileName = 'fa-' + element
            return ` [<CompiledName("${compileName}")>] ` + element
                .split("-")
                .map(function (element) {
                    return element.replace(/\b\w/g, function (l) { return l.toUpperCase() })
                }, this)
                .join("") + " ";
        }, this)
        .join(`\n    |`);

var cleaned =
    iconsDu +
    `\n ` +
    brandsDu;

var textarea = document.createElement("textarea");
textarea.style.width = "100%";
textarea.rows = 30;
textarea.textContent = cleaned;
document.body.innerHTML = "";
document.body.appendChild(textarea);