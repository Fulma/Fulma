module Modifiers.Responsive

open Fable.Helpers.React
open Fulma

let demo() =
    div [ ]
        [ Message.message [ ]
            [ Message.body [ Modifiers [ Modifier.IsHidden (Screen.Tablet, true) ] ]
                [ str "Visibile only on mobile" ] ]
          Message.message [ ]
            [ Message.body [ Modifiers [ Modifier.IsHidden (Screen.Desktop, true) ] ]
                [ str "Visibile only on touch screens" ] ]
          Message.message [ ]
            [ Message.body [ Modifiers [ Modifier.IsHiddenOnly (Screen.Desktop, true) ] ]
                [ str "Hidden only on desktop" ] ]
          Message.message [ ]
            [ Message.body [ Modifiers [ Modifier.IsHidden (Screen.Mobile, true) ] ]
                [ str "Hidden only on mobile" ] ] ]

let view =
    Render.docPage [
        Render.contentFromMarkdown
            """
# Modifiers - Responsive

Show/hide content depending on the width of the viewport.

*[Bulma documentation](https://bulma.io/documentation/modifiers/responsive-helpers/)*
            """

        Render.docSection
            """
### Demo
"""
            (Widgets.Showcase.view demo (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
