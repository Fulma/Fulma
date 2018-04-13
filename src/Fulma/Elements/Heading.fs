namespace Fulma

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
        /// Add `is-1` class
        | Is1
        /// Add `is-2` class
        | Is2
        /// Add `is-3` class
        | Is3
        /// Add `is-4` class
        | Is4
        /// Add `is-5` class
        | Is5
        /// Add `is-6` class
        | Is6
        /// Add `subtitle` class
        | IsSubtitle
        /// Add `title` class
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
    /// Generate <h1 class="title is-1"></h1>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h1 (options : Option list) = title h1 (Is1 :: options)
    /// Generate <h2 class="title is-2"></h2>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h2 (options : Option list) = title h2 (Is2 :: options)
    /// Generate <h3 class="title is-3"></h3>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h3 (options : Option list) = title h3 (Is3 :: options)
    /// Generate <h4 class="title is-4"></h4>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h4 (options : Option list) = title h4 (Is4 :: options)
    /// Generate <h5 class="title is-5"></h5>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h5 (options : Option list) = title h5 (Is5 :: options)
    /// Generate <h6 class="title is-6"></h6>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h6 (options : Option list) = title h6 (Is6 :: options)
    /// Generate <p class="title"></p>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let p opts children = title p opts children
