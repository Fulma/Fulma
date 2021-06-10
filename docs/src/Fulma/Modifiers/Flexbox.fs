module Modifiers.Flexbox

open Fable.React
open Fable.React.Props
open Fulma

let demo() =
    div [ ]
        [ Text.div
            [
                Modifiers
                    [
                        Modifier.FlexDirection FlexDirection.Row
                        Modifier.FlexWrap FlexWrap.NoWrap
                        Modifier.FlexJustifyContent FlexJustifyContent.Center
                        Modifier.FlexAlignItems FlexAlignItems.Stretch
                        Modifier.FlexAlignContent FlexAlignContent.Stretch
                    ]
            ]
            [
                div [ Style [ Padding "0 46px"; Height "3em"; Color "white"; FontSize "40px"; BackgroundColor "#46DBFF" ] ] [ str "1" ]
                div [ Style [ Padding "0 46px"; Height "3em"; Color "white"; FontSize "40px"; BackgroundColor "#2CD6FF" ] ] [ str "2" ]
                div [ Style [ Padding "0 46px"; Height "3em"; Color "white"; FontSize "40px"; BackgroundColor "#13D1FF" ] ] [ str "3" ]
                div [ Style [ Padding "0 46px"; Height "3em"; Color "white"; FontSize "40px"; BackgroundColor "#00C8F8" ] ] [ str "4" ]
            ]
        ]

let view =
    Render.docPage [
        Render.contentFromMarkdown
            """
# Modifiers - Flexbox

Helpers for all Flexbox properties

*[Bulma documentation](https://bulma.io/documentation/helpers/flexbox-helpers/)*

When using one of the flexbox helpers, Fulma will add the `is-flex` class if not already present
            """

        Render.docSection
            """
### Demo
"""
            (Widgets.Showcase.view demo (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
