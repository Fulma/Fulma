namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Modal =

    module Types =

        type Option =
            | Props of IHTMLProp list
            | IsActive
            | CustomClass of string

        type Options =
            { Props : IHTMLProp list
              IsActive : bool
              CustomClass : string option }

            static member Empty =
                { Props = []
                  IsActive = false
                  CustomClass = None }

        module Close =
            type Option =
                | Props of IHTMLProp list
                | Size of ISize
                | CustomClass of string
                | OnClick of (MouseEvent -> unit)

            type Options =
                { Props : IHTMLProp list
                  Size : string option
                  CustomClass : string option
                  OnClick : (MouseEvent -> unit) option }

                static member Empty =
                    { Props = []
                      Size = None
                      CustomClass = None
                      OnClick = None }

    open Types

    let inline isActive<'T> = IsActive
    let inline props x = Props x
    let inline customClass x = CustomClass x

    module Background =
        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

    module Content =
        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

    module Close =
        let inline isSmall<'T> = Close.Size IsSmall
        let inline isMedium<'T> = Close.Size IsMedium
        let inline isLarge<'T> = Close.Size IsLarge
        let inline onClick x = Close.OnClick x
        let inline props x = Close.Props x
        let inline customClass x = Close.CustomClass x

    let modal options children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | IsActive -> { result with IsActive = true }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield (classBaseList Bulma.Modal.Container
                                   [ Bulma.Modal.State.IsActive, opts.IsActive ] ) :> IHTMLProp
              yield! opts.Props ]
            children

    let close (options : Close.Option list) children =
        let parseOptions (result: Close.Options ) opt =
            match opt with
            | Close.Props props -> { result with Props = props }
            | Close.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Close.Size size -> { result with Size = ofSize size |> Some }
            | Close.OnClick cb -> { result with OnClick = Some cb }

        let opts = options |> List.fold parseOptions Close.Options.Empty
        let class' = Helpers.classes Bulma.Modal.Close.Container [opts.Size] []
        let opts =
            match opts.OnClick with
            | Some v -> class'::(DOMAttr.OnClick v :> IHTMLProp)::opts.Props
            | None -> class'::opts.Props

        button opts children

    let background (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Modal.Background [opts.CustomClass] []
        div (class'::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Modal.Content [opts.CustomClass] []
        div (class'::opts.Props) children

    module Card =

        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

        module Head =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Foot =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Title =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Body =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        let card (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Modal.Card.Container [opts.CustomClass] []
            div (class'::opts.Props) children

        let head (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Modal.Card.Head [opts.CustomClass] []
            header (class'::opts.Props) children

        let foot (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Modal.Card.Foot [opts.CustomClass] []
            footer (class'::opts.Props) children

        let title (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Modal.Card.Title [opts.CustomClass] []
            div (class'::opts.Props) children

        let body (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Modal.Card.Body [opts.CustomClass] []
            section (class'::opts.Props) children
