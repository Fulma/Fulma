module Elements.Title.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components.Grids


let simpleInteractive =
    div [ ]
        [ Heading.h1 [ Heading.isTitle ]
            [ str "Title" ]
          Heading.h2 [ Heading.isSubtitle ]
            [ str "Subtitle" ] ]


let sizeInteractive =
    div [ ]
        [ Heading.h1 [ Heading.isTitle ]
            [ str "Title 1" ]
          Heading.h2 [ Heading.isTitle ]
            [ str "Title 2" ]
          Heading.h3 [ Heading.isTitle ]
            [ str "Title 3" ]
          Heading.h4 [ Heading.isTitle ]
            [ str "Title 3" ]
          Heading.h5 [ Heading.isTitle ]
            [ str "Title 5" ]
          Heading.h6 [ Heading.isTitle ]
            [ str "Title 6" ]
          Heading.h1 [ Heading.isSubtitle ]
            [ str "Subtitle 1" ]
          Heading.h2 [ Heading.isSubtitle ]
            [ str "Subtitle 2" ]
          Heading.h3 [ Heading.isSubtitle ]
            [ str "Subtitle 3" ]
          Heading.h4 [ Heading.isSubtitle ]
            [ str "Subtitle 4" ]
          Heading.h5 [ Heading.isSubtitle ]
            [ str "Subtitle 5" ]
          Heading.h6 [ Heading.isSubtitle ]
            [ str "Subtitle 6" ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        """
### Types

**Title** can be of two types *Title* and *Subtitle*.
                        """
                        (Viewer.View.root simpleInteractive model.TypeViewer (TypeViewerMsg >> dispatch))
                     Render.docSection
                        """
### Sizes

Elmish.Bulma already associate each header size with the equivalent class.

For example, `Heading.h1 [ Heading.isTitle ] [ str "Title 1" ]` will output `<h1 class="title is-1">Title 1</h1>`
                        """
                        (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch))
                     Render.contentFromMarkdown
                        """We also provide `Heading.isSpaced` helper. See the *[bulma documentation](http://bulma.io/documentation/elements/title/)* to learn more about it.""" ]
