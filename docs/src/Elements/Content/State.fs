module Elements.Content.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Content
      "
    code =
      """
```fsharp

// Example
content [] [] [
            h1 [] [str "Hello World"]
                p [] [
                    str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                    , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                    , sollicitudin vel erat vel, interdum mattis neque."
                ]
                h2 [] [str "Second level"]
                p [] [
                    str "Curabitur accumsan turpis pharetra "
                    strong [] [str "augue tincidunt"]
                    str "blandit. Quisque condimentum maximus mi
                    , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                     Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                      Donec at dignissim dui. Ut et neque nisl."
                ]
                ul [] [
                    li [] [str "In fermentum leo eu lectus mollis, quis dictum mi aliquet."]
                    li [] [str "Morbi eu nulla lobortis, lobortis est in, fringilla felis."]
                    li [] [str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus."]
                    li [] [str "Ut non enim metus."]
                ]
                p [] [str "Sed sagittis enim ac tortor maximus rutrum.
                Nulla facilisi. Donec mattis vulputate risus in luctus.
                 Maecenas vestibulum interdum commodo."]
            ]
```
      """
    sizeText =
        "
# Sizes
        "
    sizeCode =
    """
```fsharp
//Examples

//For small size
content [Size Small] [] [
                h1 [] [str "Hello World"]
                p [] [
                    str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                    , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                    , sollicitudin vel erat vel, interdum mattis neque."
                ]
                h2 [] [str "Second level"]
                p [] [
                    str "Curabitur accumsan turpis pharetra "
                    strong [] [str "augue tincidunt"]
                    str "blandit. Quisque condimentum maximus mi
                    , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                     Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                      Donec at dignissim dui. Ut et neque nisl."
                ]
                ul [] [
                    li [] [str "In fermentum leo eu lectus mollis, quis dictum mi aliquet."]
                    li [] [str "Morbi eu nulla lobortis, lobortis est in, fringilla felis."]
                    li [] [str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus."]
                    li [] [str "Ut non enim metus."]
                ]
                p [] [str "Sed sagittis enim ac tortor maximus rutrum.
                Nulla facilisi. Donec mattis vulputate risus in luctus.
                 Maecenas vestibulum interdum commodo."]
            ]
//For medium size
content [Size Medium] [] [
                h1 [] [str "Hello World"]
                p [] [
                    str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                    , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                    , sollicitudin vel erat vel, interdum mattis neque."
                ]
                h2 [] [str "Second level"]
                p [] [
                    str "Curabitur accumsan turpis pharetra "
                    strong [] [str "augue tincidunt"]
                    str "blandit. Quisque condimentum maximus mi
                    , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                     Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                      Donec at dignissim dui. Ut et neque nisl."
                ]
                ul [] [
                    li [] [str "In fermentum leo eu lectus mollis, quis dictum mi aliquet."]
                    li [] [str "Morbi eu nulla lobortis, lobortis est in, fringilla felis."]
                    li [] [str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus."]
                    li [] [str "Ut non enim metus."]
                ]
                p [] [str "Sed sagittis enim ac tortor maximus rutrum.
                Nulla facilisi. Donec mattis vulputate risus in luctus.
                 Maecenas vestibulum interdum commodo."]
            ]

//For large size
content [Size Large] [] [
                h1 [] [str "Hello World"]
                p [] [
                    str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                    , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                    , sollicitudin vel erat vel, interdum mattis neque."
                ]
                h2 [] [str "Second level"]
                p [] [
                    str "Curabitur accumsan turpis pharetra "
                    strong [] [str "augue tincidunt"]
                    str "blandit. Quisque condimentum maximus mi
                    , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                     Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                      Donec at dignissim dui. Ut et neque nisl."
                ]
                ul [] [
                    li [] [str "In fermentum leo eu lectus mollis, quis dictum mi aliquet."]
                    li [] [str "Morbi eu nulla lobortis, lobortis est in, fringilla felis."]
                    li [] [str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus."]
                    li [] [str "Ut non enim metus."]
                ]
                p [] [str "Sed sagittis enim ac tortor maximus rutrum.
                Nulla facilisi. Donec mattis vulputate risus in luctus.
                 Maecenas vestibulum interdum commodo."]
            ]
```
    """
  }
