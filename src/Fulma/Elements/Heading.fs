namespace Fulma.Elements

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Heading =

    module Classes =
        let [<Literal>] Title = "title"
        let [<Literal>] Subtitle = "subtitle"
        module Size =
          let [<Literal>] Is1 = "is-1"
          let [<Literal>] Is2 = "is-2"
          let [<Literal>] Is3 = "is-3"
          let [<Literal>] Is4 = "is-4"
          let [<Literal>] Is5 = "is-5"
          let [<Literal>] Is6 = "is-6"
        module Spacing =
            let [<Literal>] IsNormal = "is-spaced"

    type Option =
        // Sies
        | Is1
        | Is2
        | Is3
        | Is4
        | Is5
        | Is6
        // Styles
        | IsSubtitle
        | IsSpaced
        // Extra
        | CustomClass of string
        | Props of IHTMLProp list

    type internal Options =
        { TitleSize : string option
          TitleType : string
          IsSpaced : bool
          CustomClass : string option
          Props : IHTMLProp list }
        static member Empty =
            { TitleSize = None
              TitleType = Classes.Title
              IsSpaced = false
              CustomClass = None
              Props = [] }

    let internal title (element : IHTMLProp list -> ReactElement list -> ReactElement) (options : Option list)
        (children) =
        let parseOption result opt =
            match opt with
            // Sizes
            | Is1 -> { result with TitleSize = Classes.Size.Is1 |> Some }
            | Is2 -> { result with TitleSize = Classes.Size.Is2 |> Some }
            | Is3 -> { result with TitleSize = Classes.Size.Is3 |> Some }
            | Is4 -> { result with TitleSize = Classes.Size.Is4 |> Some }
            | Is5 -> { result with TitleSize = Classes.Size.Is5 |> Some }
            | Is6 -> { result with TitleSize = Classes.Size.Is6 |> Some }
            // Styles
            | IsSubtitle -> { result with TitleType = Classes.Subtitle }
            | IsSpaced -> { result with IsSpaced = true }
            // Extra
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        opts.TitleType
                        [ opts.TitleSize; opts.CustomClass ]
                        [ Classes.Spacing.IsNormal, opts.IsSpaced ]

        element (classes::opts.Props)
            children

    // Alias
    let h1 (options : Option list) = title h1 (Is1 :: options)
    let h2 (options : Option list) = title h2 (Is2 :: options)
    let h3 (options : Option list) = title h3 (Is3 :: options)
    let h4 (options : Option list) = title h4 (Is4 :: options)
    let h5 (options : Option list) = title h5 (Is5 :: options)
    let h6 (options : Option list) = title h6 (Is6 :: options)
    let p opts children = title p opts children
