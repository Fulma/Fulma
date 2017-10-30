namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Heading =
    module Types =
        type ITitleSize =
            | Is1
            | Is2
            | Is3
            | Is4
            | Is5
            | Is6

        let ofTitleSize titleSize =
            match titleSize with
            | Is1 -> Bulma.Heading.Size.Is1
            | Is2 -> Bulma.Heading.Size.Is2
            | Is3 -> Bulma.Heading.Size.Is3
            | Is4 -> Bulma.Heading.Size.Is4
            | Is5 -> Bulma.Heading.Size.Is5
            | Is6 -> Bulma.Heading.Size.Is6

        type Option =
            | Size of ITitleSize
            | IsSubtitle
            | IsSpaced
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { TitleSize : string option
              TitleType : string
              IsSpaced : bool
              CustomClass : string option
              Props : IHTMLProp list }
            static member Empty =
                { TitleSize = None
                  TitleType = Bulma.Heading.Title
                  IsSpaced = false
                  CustomClass = None
                  Props = [] }

    open Types

    //Types
    let inline isSubtitle<'T> = IsSubtitle
    // Sizes
    let inline is1<'T> = Size Is1
    let inline is2<'T> = Size Is2
    let inline is3<'T> = Size Is3
    let inline is4<'T> = Size Is4
    let inline is5<'T> = Size Is5
    let inline is6<'T> = Size Is6
    // Spacing
    let inline isSpaced<'T> = IsSpaced
    // Extra
    let inline props x = Props x
    let inline customClass x = CustomClass x

    let internal title (element : IHTMLProp list -> ReactElement list -> ReactElement) (options : Option list)
        (children) =
        let parseOption result opt =
            match opt with
            | Size ts -> { result with TitleSize = ofTitleSize ts |> Some }
            | IsSubtitle -> { result with TitleType = Bulma.Heading.Subtitle }
            | IsSpaced -> { result with IsSpaced = true }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOption Options.Empty
        let className =
            classBaseList (Helpers.generateClassName opts.TitleType [ opts.TitleSize; opts.CustomClass ])
                [ Bulma.Heading.Spacing.IsNormal, opts.IsSpaced ]
        element
            [ yield className :> IHTMLProp
              yield! opts.Props ]
            children

    // Alias
    let h1 (options : Option list) = title h1 (is1 :: options)
    let h2 (options : Option list) = title h2 (is2 :: options)
    let h3 (options : Option list) = title h3 (is3 :: options)
    let h4 (options : Option list) = title h4 (is4 :: options)
    let h5 (options : Option list) = title h5 (is5 :: options)
    let h6 (options : Option list) = title h6 (is6 :: options)
    let p = title p
