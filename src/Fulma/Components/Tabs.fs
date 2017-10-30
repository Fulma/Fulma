namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tabs =

    module Types =

        type IAlignment =
            | Center
            | Right

        let ofAlignment =
            function
            | Center -> Bulma.Tabs.Alignment.Center
            | right -> Bulma.Tabs.Alignment.Right

        type Option =
            | Alignment of IAlignment
            | Size of ISize
            | IsBoxed
            | IsToggle
            | IsFullwidth
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { Alignment : string option
              Size : string option
              IsBoxed : bool
              IsToggle : bool
              IsFullwidth : bool
              CustomClass : string option
              Props : IHTMLProp list }

            static member Empty =
                { Alignment = None
                  IsBoxed = false
                  IsToggle = false
                  IsFullwidth = false
                  Size = None
                  CustomClass = None
                  Props = [] }

        module Tab =

            type Option =
                | IsActive
                | CustomClass of string
                | Props of IHTMLProp list

            type Options =
                { IsActive : bool
                  CustomClass : string option
                  Props : IHTMLProp list }

                static member Empty =
                    { IsActive = false
                      CustomClass = None
                      Props = [] }

    open Types

    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    let inline isCentered<'T> = Alignment Center
    let inline isRight<'T> = Alignment Right
    let inline isBoxed<'T> = IsBoxed
    let inline isToggle<'T> = IsToggle
    let inline isFullwidth<'T> = IsFullwidth
    let inline customClass x = CustomClass x
    let inline props x = Props x

    module Tab =
        let isActive= Tab.IsActive
        let inline customClass x = Tab.CustomClass x
        let inline props x = Tab.Props x

    let tabs (options: Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | Alignment alignment -> { result with Alignment = ofAlignment alignment |> Some }
            | IsBoxed -> { result with IsBoxed = true }
            | IsToggle -> { result with IsToggle = true }
            | IsFullwidth -> { result with IsFullwidth = true }
            | Size size -> { result with Size = ofSize size |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        div [ yield Helpers.classes Bulma.Tabs.Container [opts.Alignment; opts.Size] [Bulma.Tabs.Style.IsBoxed, opts.IsBoxed; Bulma.Tabs.Style.IsFullwidth, opts.IsFullwidth; Bulma.Tabs.Style.IsToggle, opts.IsToggle]
              yield! opts.Props ]
            [ ul [ ]
                 children ]

    let tab (options: Tab.Option list) children =
        let parseOptions (result: Tab.Options) opt =
            match opt with
            | Tab.IsActive -> { result with IsActive = true }
            | Tab.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Tab.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Tab.Options.Empty
        li [ yield (classList [ Bulma.Tabs.State.IsActive, opts.IsActive ]) :> IHTMLProp
             yield! opts.Props ]
            children
