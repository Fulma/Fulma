namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Heading =
    module Types =
        type ITitleSize =
            | Is1
            | Is2
            | Is3
            | Is4
            | Is5
            | Is6

        type ITitleType =
            | Title
            | Subtitle

        let ofTitleSize titleSize =
            match titleSize with
            | Is1 -> bulma.Heading.Size.is1
            | Is2 -> bulma.Heading.Size.Is2
            | Is3 -> bulma.Heading.Size.Is3
            | Is4 -> bulma.Heading.Size.Is4
            | Is5 -> bulma.Heading.Size.Is5
            | Is6 -> bulma.Heading.Size.Is6

        let ofTitleType titleType =
            match titleType with
            | Title -> bulma.Heading.Title
            | Subtitle -> bulma.Heading.Subtitle

        type Option =
            | Size of ITitleSize
            | Type of ITitleType
            | IsSpaced

        type Options =
            { TitleSize : string option
              TitleType : string
              IsSpaced : bool }
            static member Empty =
                { TitleSize = None
                  TitleType = ""
                  IsSpaced = false }

    open Types

    //Types
    let isTitle = Type Title
    let isSubtitle = Type Subtitle
    // Sizes
    let is1 = Size Is1
    let is2 = Size Is2
    let is3 = Size Is3
    let is4 = Size Is4
    let is5 = Size Is5
    let is6 = Size Is6
    // Spacing
    let isSpaced = IsSpaced

    let title (element : IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options : Option list)
        (children) =
        let parseOption result opt =
            match opt with
            | Size ts -> { result with TitleSize = ofTitleSize ts |> Some }
            | Type tt -> { result with TitleType = ofTitleType tt }
            | IsSpaced -> { result with IsSpaced = true }

        let opts = options |> List.fold parseOption Options.Empty
        let className =
            classBaseList (Helpers.generateClassName opts.TitleType [ opts.TitleSize ])
                [ bulma.Heading.Spacing.IsNormal, opts.IsSpaced ]
        element
            [ className ]
            children

    // Alias
    let h1 = title h1
    let h2 = title h2
    let h3 = title h3
    let h4 = title h4
    let h5 = title h5
    let h6 = title h6
    let p = title p
