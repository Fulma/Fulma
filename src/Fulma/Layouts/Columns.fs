namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Columns =

    module Classes =
        let [<Literal>] Container = "columns"
        module Alignment =
            let [<Literal>] IsCentered = "is-centered"
            let [<Literal>] IsVCentered = "is-vcentered"
        module Spacing =
            let [<Literal>] IsMultiline = "is-multiline"
            let [<Literal>] IsGapless = "is-gapless"
            let [<Literal>] IsGrid = "is-grid"
            let [<Literal>] IsVariable = "is-variable"
        module Display =
            let [<Literal>] IsMobile = "is-mobile"
            let [<Literal>] IsDesktop = "is-desktop"

    type ISize =
        | Is1
        | Is2
        | Is3
        | Is4
        | Is5
        | Is6
        | Is7
        | Is8

        static member toString =
            function
            | Is1 -> "1"
            | Is2 -> "2"
            | Is3 -> "3"
            | Is4 -> "4"
            | Is5 -> "5"
            | Is6 -> "6"
            | Is7 -> "7"
            | Is8 -> "8"

    let inline private gapSizeGeneric (screen : Screen) (size : ISize) =
        "is-" + ISize.toString size + Screen.toString screen

    let inline private gapSizeOnly (screen : Screen) (size : ISize) =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-" + ISize.toString size + Screen.toString screen + "-only"
        | x ->
            let msg = sprintf "Screen `%s` does not support `is-%s-%s-only`." (Screen.toString x) (ISize.toString size) (Screen.toString x)
            Fable.Import.JS.console.warn(msg)
            ""

    type Option =
        /// Add `is-centered` class
        | IsCentered
        /// Add `is-vcentered` class
        | IsVCentered
        /// Add `is-multiline` class
        | IsMultiline
        /// Add `is-gapless` class
        | IsGapless
        /// Add `is-grid` class
        | IsGrid
        /// Add `is-mobile` class
        | IsMobile
        /// Add `is-desktop` class
        | IsDesktop
        /// Configure the gap size. You can configure the display and gap size
        /// Example: Columns.IsGap (Columns.Desktop, Columns.Is6)
        /// Becomes: `is-6-desktop`
        | IsGap of Screen * ISize
        /// Configure the gap size. You can configure the display and gap size
        /// Example: Columns.IsGapOnly (Columns.Tablet, Columns.Is6)
        /// Becomes: `is-6-tablet-only`
        | IsGapOnly of Screen * ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Display : string option
          Spacing : string option
          Alignment : string option
          CustomClass : string option
          IsGap : string option
          Props : IHTMLProp list
          Modifiers : string option list }

        static member Empty =
            { Display = None
              Spacing = None
              Alignment = None
              CustomClass = None
              IsGap = None
              Props = []
              Modifiers = [] }

    /// Generate <div class="columns"></div>
    let columns (options: Option list) children =
        let parseOptions (result: Options) =
            function
            | IsCentered -> { result with Alignment = Classes.Alignment.IsCentered |> Some }
            | IsVCentered -> { result with Alignment = Classes.Alignment.IsVCentered |> Some }
            | IsMultiline -> { result with Spacing = Classes.Spacing.IsMultiline |> Some }
            | IsGapless -> { result with Spacing = Classes.Spacing.IsGapless |> Some }
            | IsGrid -> { result with Spacing = Classes.Spacing.IsGrid |> Some }
            | IsMobile -> { result with Display = Classes.Display.IsMobile |> Some }
            | IsDesktop -> { result with Display = Classes.Display.IsDesktop |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }
            | IsGap (screen, size) ->
                let oldGap =
                    result.IsGap
                    |> Option.defaultValue Classes.Spacing.IsVariable
                { result with IsGap = oldGap + " " + gapSizeGeneric screen size |> Some }
            | IsGapOnly (screen, size) ->
                let oldGap =
                    result.IsGap
                    |> Option.defaultValue Classes.Spacing.IsVariable
                { result with IsGap = oldGap + " " + gapSizeOnly screen size |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.Alignment
                          ::opts.Display
                          ::opts.Spacing
                          ::opts.IsGap
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]

        div (classes::opts.Props)
            children
