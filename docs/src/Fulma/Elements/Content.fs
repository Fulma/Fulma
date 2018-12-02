module Elements.Content

open Fable.Helpers.React
open Fulma

let contentInteractive () =
    Content.content [ ]
        [ h1 [ ] [str "Hello World"]
          p [ ]
            [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                  Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                  , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                  , sollicitudin vel erat vel, interdum mattis neque." ]
          h2 [ ] [ str "Second level" ]
          p [ ]
            [ str "Curabitur accumsan turpis pharetra "
              strong [ ] [ str "augue tincidunt" ]
              str "blandit. Quisque condimentum maximus mi
                  , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                  Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                  Donec at dignissim dui. Ut et neque nisl." ]
          ul [ ]
             [ li [ ] [ str "In fermentum leo eu lectus mollis, quis dictum mi aliquet." ]
               li [ ] [ str "Morbi eu nulla lobortis, lobortis est in, fringilla felis." ]
               li [ ] [ str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus." ]
               li [ ] [ str "Ut non enim metus."] ]
          p [ ] [ str "Sed sagittis enim ac tortor maximus rutrum.
                     Nulla facilisi. Donec mattis vulputate risus in luctus.
                     Maecenas vestibulum interdum commodo." ] ]

let sizeInteractive () =
    Content.content [ Content.Size IsSmall ]
        [ h1 [ ] [ str "Hello World"]
          p [ ]
            [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                  Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                  , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                  , sollicitudin vel erat vel, interdum mattis neque." ]
          h2 [ ] [ str "Second level" ]
          p [ ]
            [ str "Curabitur accumsan turpis pharetra "
              strong [ ] [ str "augue tincidunt" ]
              str "blandit. Quisque condimentum maximus mi
                  , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                  Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                  Donec at dignissim dui. Ut et neque nisl." ]
          ul [ ]
             [ li [ ] [ str "In fermentum leo eu lectus mollis, quis dictum mi aliquet." ]
               li [ ] [ str "Morbi eu nulla lobortis, lobortis est in, fringilla felis." ]
               li [ ] [ str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus." ]
               li [ ] [ str "Ut non enim metus."] ]
          p [ ] [ str "Sed sagittis enim ac tortor maximus rutrum.
                     Nulla facilisi. Donec mattis vulputate risus in luctus.
                     Maecenas vestibulum interdum commodo." ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Content

A single class to handle WYSIWYG generated content, where only **HTML tags** are available. Content also supports size attributes.

*[Bulma documentation](http://bulma.io/documentation/elements/content/)*
                        """
                     Render.docSection
                        "### Demo"
                        (Widgets.Showcase.view contentInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Size

Supported sizez:

* `Content.Size IsSmall`
* `Content.Size IsMedium`
* `Content.Size IsLarge`

When you do not set the size, it's considered *normal*.
                        """
                        (Widgets.Showcase.view sizeInteractive (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
