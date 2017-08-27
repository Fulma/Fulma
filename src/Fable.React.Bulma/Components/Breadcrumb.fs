namespace Fable.React.Bulma.Components

open Fable.React.Bulma.BulmaClasses
open Fable.React.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Breadcrumb =

    module Types =

        type IAlignment =
            | IsCentered
            | IsRight

        type ISeparator =
            | Arrow
            | Bullet
            | Dot
            | Succeeds

        let ofAlignment =
            function
            | IsCentered -> Bulma.Breadcrumb.Alignment.IsCentered
            | IsRight -> Bulma.Breadcrumb.Alignment.IsRight

        let ofSeparator =
            function
            | Arrow -> Bulma.Breadcrumb.Separator.Arrow
            | Bullet -> Bulma.Breadcrumb.Separator.Bullet
            | Dot -> Bulma.Breadcrumb.Separator.Dot
            | Succeeds -> Bulma.Breadcrumb.Separator.Succeeds

        type Option =
            | Alignment of IAlignment
            | Separator of ISeparator
            | Size of ISize
            | Props of IHTMLProp list
            | CustomClass of string

        type Options =
            { Props : IHTMLProp list
              Alignment : string option
              Separator : string option
              Size : string option
              CustomClass : string option }

            static member Empty =
                { Props = []
                  Alignment = None
                  Separator = None
                  Size = None
                  CustomClass = None }

        module Item =

            type Option =
                | IsActive
                | Props of IHTMLProp list
                | CustomClass of string

            type Options =
                { Props : IHTMLProp list
                  IsActive : bool
                  CustomClass : string option }

                static member Empty =
                    { Props = []
                      IsActive = false
                      CustomClass = None }

    open Types

    // Size
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    // Alignement
    let isCentered = Alignment IsCentered
    let isRight = Alignment IsRight
    // Separator
    let hasArrowSeparator = Separator Arrow
    let hasBulletSeparator = Separator Bullet
    let hasDotSeparator = Separator Dot
    let hasSucceedsSeparator = Separator Succeeds
    // Extra
    let props = Props
    let customClass = CustomClass

    let breadcrumb options children =
        let parseOptions result =
            function
            | Alignment alignment -> { result with Alignment = ofAlignment alignment |> Some }
            | Separator separator -> { result with Separator = ofSeparator separator |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty

        nav [ yield ClassName (Helpers.generateClassName Bulma.Breadcrumb.Container
                                [ opts.Alignment; opts.Separator; opts.Size; opts.CustomClass ]) :> IHTMLProp
              yield! opts.Props ]
            [ ul [ ] children ]

    module Item =

        let isActive = Item.IsActive
        let props = Item.Props
        let customClass = Item.CustomClass

    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive -> { result with IsActive = true }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        let className =
            [ if opts.IsActive then
                yield Bulma.Breadcrumb.State.IsActive
              if opts.CustomClass.IsSome then
                yield opts.CustomClass.Value
            ] |> String.concat " "


        li [ yield ClassName className :>  IHTMLProp
             yield! opts.Props ]
            children
