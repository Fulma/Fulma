module Elements.Title

open Fable.Helpers.React
open Fulma.Elements

let simpleInteractive () =
    div [ ]
        [ Heading.h1 [ ]
            [ str "Title" ]
          Heading.h2 [ Heading.IsSubtitle ]
            [ str "Subtitle" ] ]


let sizeInteractive () =
    div [ ]
        [ Heading.h1 [ ]
            [ str "Title 1" ]
          Heading.h2 [ ]
            [ str "Title 2" ]
          Heading.h3 [ ]
            [ str "Title 3" ]
          Heading.h4 [ ]
            [ str "Title 3" ]
          Heading.h5 [ ]
            [ str "Title 5" ]
          Heading.h6 [ ]
            [ str "Title 6" ]
          Heading.h1 [ Heading.IsSubtitle ]
            [ str "Subtitle 1" ]
          Heading.h2 [ Heading.IsSubtitle ]
            [ str "Subtitle 2" ]
          Heading.h3 [ Heading.IsSubtitle ]
            [ str "Subtitle 3" ]
          Heading.h4 [ Heading.IsSubtitle ]
            [ str "Subtitle 4" ]
          Heading.h5 [ Heading.IsSubtitle ]
            [ str "Subtitle 5" ]
          Heading.h6 [ Heading.IsSubtitle ]
            [ str "Subtitle 6" ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Title

*[Bulma documentation](http://bulma.io/documentation/elements/title/)*
                        """
                     Render.docSection
                        """
### Types

**Title** can be of two types *Title* and *Subtitle*.

By default, `Header.h1 [ ] [ ]` generate a title. You can specify `Heading.isSubtitle` if needed.
                        """
                        (Widgets.Showcase.view simpleInteractive (Render.getViewSource simpleInteractive))
                     Render.docSection
                        """
### Sizes

Elmish.Bulma already associate each header size with the equivalent class.

For example, `Heading.h1 [ Heading.isTitle ] [ str "Title 1" ]` will output `<h1 class="title is-1">Title 1</h1>`
                        """
                        (Widgets.Showcase.view sizeInteractive (Render.getViewSource sizeInteractive))
                     Render.contentFromMarkdown
                        """We also provide `Heading.isSpaced` helper. See the *[bulma documentation](http://bulma.io/documentation/elements/title/)* to learn more about it.""" ]
