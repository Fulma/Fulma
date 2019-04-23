module Modifiers.Typography

open Fable.React
open Fable.React.Props
open Fulma

let alignment () =
    div [ Class "block" ]
        [ Text.p [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Left) ] ]
            [ str "Left" ]
          hr [ ]
          Text.p [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
            [ str "Centered" ]
          hr [ ]
          Text.p [ Props [ Style [ Width "200px" ] ]
                   Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Justified) ] ]
            [ str "This text should be justified, this is why I am writing a long text. I am doing that in order to make it easier to see." ]
          hr [ ]
          Text.p [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Right) ] ]
            [ str "Right" ] ]

let transformation () =
    Content.content [ ]
        [ li [ ]
            [ Text.span [ Modifiers [ Modifier.TextTransform TextTransform.Italic ] ]
                [ str "Italic" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextTransform TextTransform.Capitalized ] ]
                [ str "capitalized" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextTransform TextTransform.UpperCase ] ]
                [ str "UpperCase" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextTransform TextTransform.LowerCase ] ]
                [ str "LowerCase" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextTransform TextTransform.UpperCase
                                      Modifier.TextTransform TextTransform.Italic ] ]
                [ str "Italic & UpperCase" ] ] ]

let weight () =
    Content.content [ ]
        [ li [ ]
            [ Text.span [ Modifiers [ Modifier.TextWeight TextWeight.Light ] ]
                [ str "Light" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextWeight TextWeight.Normal ] ]
                [ str "Normal" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextWeight TextWeight.SemiBold ] ]
                [ str "Semi bold" ] ]
          li [ ]
            [ Text.span [ Modifiers [ Modifier.TextWeight TextWeight.Bold ] ]
                [ str "Bold" ] ] ]

let size () =
    Content.content [ ]
        [ li [ ]
            [ Text.span [ Modifiers [ Modifier.TextSize (Screen.Desktop, TextSize.Is5)
                                      Modifier.TextSize (Screen.Tablet, TextSize.Is3)
                                      Modifier.TextSize (Screen.Mobile, TextSize.Is1) ] ]
                [ str "Resize your window and see how my size is changing." ] ] ]

let view =
    Render.docPage [
        Render.contentFromMarkdown
            """
# Modifiers - Typography

In order to make it easier to use modifier on text, Fulma provide three helpers:

- `Text.p`
- `Text.div`
- `Text.span`

*[Bulma documentation](https://bulma.io/documentation/modifiers/typography-helpers/)*
            """

        Render.docSection
            """### Text alignment"""
            (Widgets.Showcase.view alignment (Render.includeCode __LINE__ __SOURCE_FILE__))

        Render.docSection
            """### Text transformation"""
            (Widgets.Showcase.view transformation (Render.includeCode __LINE__ __SOURCE_FILE__))

        Render.docSection
            """### Text weight"""
            (Widgets.Showcase.view weight (Render.includeCode __LINE__ __SOURCE_FILE__))
        Render.docSection
            """### Text size"""
            (Widgets.Showcase.view size (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
