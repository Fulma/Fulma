namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Level =

    module Types =

        module Level =

            type Option =
                | Props of IHTMLProp list
                | IsMobile
                | CustomClass of string

            type Options =
                { Props : IHTMLProp list
                  IsMobile : bool
                  CustomClass : string option }

                static member Empty =
                    { Props = []
                      IsMobile = false
                      CustomClass = None }

        module Item =

            type Option =
                | Props of IHTMLProp list
                | HasTextCentered
                | CustomClass of string

            type Options =
                { Props : IHTMLProp list
                  HasTextCentered : bool
                  CustomClass : string option }

                static member Empty =
                    { Props = []
                      HasTextCentered = false
                      CustomClass = None }

    open Types

    module Level =
        let isMobile = Level.IsMobile
        // Extra
        let props = Level.Props
        let customClass = Level.CustomClass

    let level (options : Level.Option list) children =
        let parseOptions (result: Level.Options ) opt =
            match opt with
            | Level.Option.Props props -> { result with Props = props }
            | Level.Option.IsMobile -> { result with IsMobile = true }
            | Level.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Level.Options.Empty

        nav [ yield classBaseList
                        Bulma.Level.Container
                        [ Bulma.Level.Mobile.IsHorizontal, opts.IsMobile
                          opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let props = GenericOption.Props
    let customClass = GenericOption.CustomClass

    let left (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Level.Left
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let right (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Level.Right
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    module Item =
        let hasTextCentered = Item.HasTextCentered
        // Extra
        let props = Item.Props
        let customClass = Item.CustomClass

    module Heading =
        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

    module Title =
        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

    let item (options : Item.Option list) children =
        let parseOptions (result: Item.Options ) opt =
            match opt with
            | Item.Props props -> { result with Props = props }
            | Item.HasTextCentered -> { result with HasTextCentered = true }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        nav [ yield classBaseList
                        Bulma.Level.Item.Container
                        [ Bulma.Level.Item.HasTextCentered, opts.HasTextCentered
                          opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let heading (options: GenericOption list) children =
        let opts = genericParse options

        p [ yield classBaseList Bulma.Level.Item.Heading
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children

    let title (options: GenericOption list) children =
        let opts = genericParse options

        p [ yield classBaseList Bulma.Level.Item.Title
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children
