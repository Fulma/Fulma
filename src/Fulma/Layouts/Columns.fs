namespace Fulma.Layouts

open Fulma.BulmaClasses
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
        module Display =
            let [<Literal>] IsMobile = "is-mobile"
            let [<Literal>] IsDesktop = "is-desktop"

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
        | CustomClass of string
        | Props of IHTMLProp list

    type internal Options =
        { Display : string option
          Spacing : string option
          Alignment : string option
          CustomClass : string option
          Props : IHTMLProp list }
        static member Empty =
            { Display = None
              Spacing = None
              Alignment = None
              CustomClass = None
              Props = [] }

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

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Alignment
                          opts.Display
                          opts.Spacing
                          opts.CustomClass ]
                        [ ]

        div (classes::opts.Props)
            children
