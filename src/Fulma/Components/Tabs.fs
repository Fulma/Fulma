namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

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

    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    let isCentered = Alignment Center
    let isRight = Alignment Right
    let isBoxed = IsBoxed
    let isToggle = IsToggle
    let isFullwidth = IsFullwidth
    let customClass = CustomClass
    let props = Props

    module Tab =
        let isActive= Tab.IsActive
        let customClass = Tab.CustomClass
        let props = Tab.Props

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
        div [ yield (classBaseList Bulma.Tabs.Container
                                    [ opts.Alignment.Value, opts.Alignment.IsSome
                                      opts.Size.Value, opts.Size.IsSome
                                      Bulma.Tabs.Style.IsBoxed, opts.IsBoxed
                                      Bulma.Tabs.Style.IsFullwidth, opts.IsFullwidth
                                      Bulma.Tabs.Style.IsToggle, opts.IsToggle ]) :> IHTMLProp
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
