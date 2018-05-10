module Modifiers.Basics

open Fable.Helpers.React
open Fulma

let demo () =
    div [ ]
        [ Message.message [ ]
              [ Message.body [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered)
                                           Modifier.BackgroundColor IsGreyLighter
                                           Modifier.TextColor IsLink
                                           Modifier.TextWeight TextWeight.Bold ] ]
                    [ str "Text centered" ] ]
          Message.message [ ]
              [ Message.body [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Right)
                                           Modifier.BackgroundColor IsGreyLighter
                                           Modifier.TextColor IsLink
                                           Modifier.TextWeight TextWeight.Bold ] ]
                    [ str "Text aligned on the right" ] ] ]

let view =
    Render.docPage [
        Render.docSection
            """
# Modifiers - Basics

*[Bulma documentation](https://bulma.io/documentation/modifiers/)*

You can add `Modifiers` to any Fulma element or component.
            """
            (Widgets.Showcase.view demo (Render.getViewSource demo)) ]
