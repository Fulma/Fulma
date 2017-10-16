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

    let isActive = IsActive
    let props = Props
    let customClass = CustomClass

    module Background =
        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

    module Content =
        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

    module Close =
        let isSmall = Close.Size IsSmall
        let isMedium = Close.Size IsMedium
        let isLarge = Close.Size IsLarge
        let onClick = Close.OnClick
        let props = Close.Props
        let customClass = Close.CustomClass

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

        button [ yield (classBaseList Bulma.Modal.Close.Container
                                   [ opts.Size.Value, opts.Size.IsSome ] ) :> IHTMLProp
                 if opts.OnClick.IsSome then
                    yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
                 yield! opts.Props ]
            children

    let background (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Modal.Background
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let content (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Modal.Content
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    module Card =

        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

        module Head =
            let props = GenericOption.Props
            let customClass = GenericOption.CustomClass

        module Foot =
            let props = GenericOption.Props
            let customClass = GenericOption.CustomClass

        module Title =
            let props = GenericOption.Props
            let customClass = GenericOption.CustomClass

        module Body =
            let props = GenericOption.Props
            let customClass = GenericOption.CustomClass

        let card (options: GenericOption list) children =
            let opts = genericParse options

            div [ yield classBaseList Bulma.Modal.Card.Container
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

        let head (options: GenericOption list) children =
            let opts = genericParse options

            header [ yield classBaseList Bulma.Modal.Card.Head
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                     yield! opts.Props ]
                children

        let foot (options: GenericOption list) children =
            let opts = genericParse options

            footer [ yield classBaseList Bulma.Modal.Card.Foot
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                     yield! opts.Props ]
                children

        let title (options: GenericOption list) children =
            let opts = genericParse options

            div [ yield classBaseList Bulma.Modal.Card.Title
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

        let body (options: GenericOption list) children =
            let opts = genericParse options

            section [ yield classBaseList Bulma.Modal.Card.Body
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                      yield! opts.Props ]
                children
