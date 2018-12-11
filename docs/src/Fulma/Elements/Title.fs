module Elements.Title

open Fable.Helpers.React
open Fulma

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
            [ str "Title 4" ]
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

By default, `Header.h1 [ ] [ ]` generates a title. You can specify `Heading.IsSubtitle` if needed.
                        """
                        (Widgets.Showcase.view simpleInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Sizes

Fulma already associates each header size with the equivalent class.

For example, `Heading.h1 [ Heading.IsTitle ] [ str "Title 1" ]` will output `<h1 class="title is-1">Title 1</h1>`
                        """
                        (Widgets.Showcase.view sizeInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """We also provide `Heading.isSpaced` helper. See the *[bulma documentation](http://bulma.io/documentation/elements/title/)* to learn more about it.""" ]
