namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Columns =

    module Types =

        type IDisplay =
            | Mobile
            | DesktopOnly

        type ISpacing =
            | IsMultiline
            | IsGapless
            | IsGrid

        type IAlignement =
            | IsCentered
            | IsVCentered

        type Option =
            | Display of IDisplay
            | Spacing of ISpacing
            | Alignment of IAlignement
            | CustomClass of string
            | Props of IHTMLProp list

        let ofAlignment =
            function
            | IsCentered -> Bulma.Grid.Columns.Alignment.IsCentered
            | IsVCentered -> Bulma.Grid.Columns.Alignment.IsVCentered

        let ofSpacing =
            function
            | IsMultiline -> Bulma.Grid.Columns.Spacing.IsMultiline
            | IsGapless -> Bulma.Grid.Columns.Spacing.IsGapless
            | IsGrid -> Bulma.Grid.Columns.Spacing.IsGrid

        let ofDisplay =
            function
            | Mobile -> Bulma.Grid.Columns.Display.OnMobile
            | DesktopOnly -> Bulma.Grid.Columns.Display.OnlyDesktop

        type Options =
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

    open Types

    // Alignment
    let inline isCentered<'T> = Alignment IsCentered
    let inline isVCentered<'T> = Alignment IsVCentered
    // Display
    let inline onMobile<'T> = Display Mobile
    let inline onDesktopOnly<'T> = Display DesktopOnly
    // Spacing
    let inline isMultiline<'T> = Spacing IsMultiline
    let inline isGapless<'T> = Spacing IsGapless
    let inline isGrid<'T> = Spacing IsGrid
    // Extra
    let inline customClass x = CustomClass x
    let inline props x = Props x

    let columns (options: Option list) children =
        let parseOptions (result: Options) =
            function
            | Display display ->
                { result with Display = ofDisplay display |> Some }

            | Spacing spacing ->
                { result with Spacing = ofSpacing spacing |> Some }

            | Alignment alignment ->
                { result with Alignment = ofAlignment alignment |> Some }

            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield ClassName ( Helpers.generateClassName Bulma.Grid.Columns.Container
                                                    [ opts.Alignment
                                                      opts.Display
                                                      opts.Spacing
                                                      opts.CustomClass ] ) :> IHTMLProp
              yield! opts.Props ]
            children
