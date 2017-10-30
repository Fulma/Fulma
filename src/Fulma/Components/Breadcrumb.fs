namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
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
    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    // Alignement
    let inline isCentered<'T> = Alignment IsCentered
    let inline isRight<'T> = Alignment IsRight
    // Separator
    let inline hasArrowSeparator<'T> = Separator Arrow
    let inline hasBulletSeparator<'T> = Separator Bullet
    let inline hasDotSeparator<'T> = Separator Dot
    let inline hasSucceedsSeparator<'T> = Separator Succeeds
    // Extra
    let inline props x = Props x
    let inline customClass x = CustomClass x

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

        let inline isActive<'T> = Item.IsActive
        let inline props x = Item.Props x
        let inline customClass x = Item.CustomClass x

    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive -> { result with IsActive = true }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        li [ yield Helpers.classes "" [opts.CustomClass]
                        [Bulma.Breadcrumb.State.IsActive, opts.IsActive]
             yield! opts.Props ]
            children
